using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Services.Concrete
{
    public class ClassService : IClassService
    {
        private readonly IClassInstanceRepository _classInstanceRepository;
        private readonly IClassScheduleRepository _classScheduleRepository;
        private readonly IBookingRepository _bookingRepository;

        public ClassService(
            IClassInstanceRepository classInstanceRepository,
            IClassScheduleRepository classScheduleRepository,
            IBookingRepository bookingRepository)
        {
            _classInstanceRepository = classInstanceRepository;
            _classScheduleRepository = classScheduleRepository;
            _bookingRepository = bookingRepository;
        }

        public Task<ClassInstance?> GetClassInstanceByIdAsync(int instanceId)
        {
            return _classInstanceRepository.GetByIdAsync(instanceId);
        }

        public Task<IEnumerable<ClassInstance>> GetAvailableClassesAsync(DateTime fromDate, DateTime toDate)
        {
            return _classInstanceRepository.GetAvailableInstancesAsync(fromDate, toDate);
        }

        public Task<IEnumerable<ClassInstance>> GetUpcomingClassesAsync(int daysAhead)
        {
            return _classInstanceRepository.GetUpcomingInstancesAsync(daysAhead);
        }

        public Task<IEnumerable<ClassInstance>> GetClassesByDateAsync(DateTime date)
        {
            return _classInstanceRepository.GetByDateAsync(date);
        }

        public Task<IEnumerable<ClassInstance>> GetClassesByInstructorAsync(int instructorId, DateTime? fromDate, DateTime? toDate)
        {
            return _classInstanceRepository.GetInstancesByInstructorAsync(instructorId, fromDate, toDate);
        }

        public async Task<ClassInstance> CreateClassInstanceAsync(ClassInstance instance)
        {
            // Validate instance data
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (instance.ClassDate < DateTime.Now.Date)
            {
                throw new ArgumentException("Class date cannot be in the past");
            }

            if (instance.StartTime >= instance.EndTime)
            {
                throw new ArgumentException("Start time must be before end time");
            }

            if (instance.Capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than 0");
            }

            // Set default values
            if (instance.CreatedAt == default)
            {
                instance.CreatedAt = DateTime.Now;
            }

            if (string.IsNullOrEmpty(instance.Status))
            {
                instance.Status = "scheduled";
            }

            instance.CurrentBookings = 0;

            // Create instance
            var result = await _classInstanceRepository.CreateAsync(instance);
            if (result > 0)
            {
                // Return the created instance (you might want to fetch it by ID)
                return instance;
            }

            throw new Exception("Failed to create class instance");
        }

        public async Task<bool> GenerateClassInstancesFromScheduleAsync(DateTime fromDate, DateTime toDate)
        {
            // Get all active schedules
            var schedules = await _classScheduleRepository.GetActiveSchedulesAsync();
            var createdCount = 0;

            foreach (var schedule in schedules)
            {
                // Generate instances for each day in the date range
                var currentDate = fromDate.Date;
                while (currentDate <= toDate.Date)
                {
                    // Check if schedule is effective for this date
                    if (currentDate < schedule.EffectiveFrom.Date)
                    {
                        currentDate = currentDate.AddDays(1);
                        continue;
                    }

                    if (schedule.EffectiveUntil != default && currentDate > schedule.EffectiveUntil.Date)
                    {
                        currentDate = currentDate.AddDays(1);
                        continue;
                    }

                    // Get day of week (0 = Sunday, 1 = Monday, etc.)
                    var dayOfWeek = (int)currentDate.DayOfWeek;
                    // MySQL uses 1-7 (Monday-Sunday), C# uses 0-6 (Sunday-Saturday)
                    var mysqlDayOfWeek = dayOfWeek == 0 ? 7 : dayOfWeek;

                    // Check if schedule matches this day of week
                    if (schedule.DayOfWeek == mysqlDayOfWeek)
                    {
                        // Check if instance already exists
                        var existingInstances = await _classInstanceRepository.GetInstancesByScheduleAsync(schedule.ClassScheduleId);
                        var instanceExists = existingInstances.Any(i => i.ClassDate.Date == currentDate.Date);

                        if (!instanceExists)
                        {
                            // Calculate end time from start time and duration
                            var startTime = TimeOnly.FromTimeSpan(schedule.StartTime);
                            // You might need to get duration from class type, for now using 60 minutes default
                            var endTime = startTime.AddHours(1);

                            var instance = new ClassInstance
                            {
                                ClassScheduleId = schedule.ClassScheduleId,
                                ClassDate = currentDate,
                                StartTime = startTime,
                                EndTime = endTime,
                                InstructorId = schedule.InstructorId,
                                RoomId = schedule.RoomId,
                                Capacity = 20, // Default capacity, you might want to get this from class type
                                CurrentBookings = 0,
                                Status = "scheduled",
                                CreatedAt = DateTime.Now
                            };

                            var result = await _classInstanceRepository.CreateAsync(instance);
                            if (result > 0)
                            {
                                createdCount++;
                            }
                        }
                    }

                    currentDate = currentDate.AddDays(1);
                }
            }

            return createdCount > 0;
        }

        public async Task<bool> CancelClassInstanceAsync(int instanceId, string reason)
        {
            var instance = await _classInstanceRepository.GetByIdAsync(instanceId);
            if (instance == null)
            {
                return false;
            }

            // Update instance status to cancelled
            instance.Status = "cancelled";
            instance.CancelationReason = reason;

            var result = await _classInstanceRepository.UpdateAsync(instance);

            // Optionally, cancel all bookings for this instance
            if (result)
            {
                var bookings = await _bookingRepository.GetByInstanceIdAsync(instanceId);
                foreach (var booking in bookings)
                {
                    if (booking != null)
                    {
                        await _bookingRepository.CancelBookingAsync(booking.BookingId, $"Class cancelled: {reason}");
                    }
                }
            }

            return result;
        }

        public async Task<bool> UpdateClassStatusAsync(int instanceId, string status)
        {
            var instance = await _classInstanceRepository.GetByIdAsync(instanceId);
            if (instance == null)
            {
                return false;
            }

            // Validate status
            var validStatuses = new[] { "scheduled", "in_progress", "completed", "cancelled" };
            if (!validStatuses.Contains(status.ToLower()))
            {
                throw new ArgumentException($"Invalid status: {status}");
            }

            instance.Status = status.ToLower();
            return await _classInstanceRepository.UpdateAsync(instance);
        }

        public async Task<bool> IsClassAvailableForBookingAsync(int instanceId)
        {
            var instance = await _classInstanceRepository.GetByIdAsync(instanceId);
            if (instance == null)
            {
                return false;
            }

            // Check if class is scheduled
            if (instance.Status?.ToLower() != "scheduled")
            {
                return false;
            }

            // Check if class date is in the future
            if (instance.ClassDate.Date < DateTime.Now.Date)
            {
                return false;
            }

            // Check if class is full
            if (await _classInstanceRepository.IsClassFullAsync(instanceId))
            {
                return false;
            }

            return true;
        }
    }
}
