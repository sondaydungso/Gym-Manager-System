using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using Gym_Manager_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Services.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IClassInstanceRepository _classInstanceRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IAttendanceRepository _attendanceRepository;

        public BookingService(
            IBookingRepository bookingRepository,
            IClassInstanceRepository classInstanceRepository,
            IMemberRepository memberRepository,
            ISubscriptionRepository subscriptionRepository,
            IAttendanceRepository attendanceRepository)
        {
            _bookingRepository = bookingRepository;
            _classInstanceRepository = classInstanceRepository;
            _memberRepository = memberRepository;
            _subscriptionRepository = subscriptionRepository;
            _attendanceRepository = attendanceRepository;
        }

        public Task<Booking?> GetBookingByIdAsync(int bookingId)
        {
            return _bookingRepository.GetByIdAsync(bookingId);
        }

        public Task<IEnumerable<Booking>> GetMemberBookingsAsync(int memberId)
        {
            return _bookingRepository.GetByMemberIdAsync(memberId);
        }

        public Task<IEnumerable<Booking>> GetUpcomingMemberBookingsAsync(int memberId)
        {
            return _bookingRepository.GetUpcomingBookingsByMemberAsync(memberId);
        }

        public Task<IEnumerable<Booking>> GetPastMemberBookingsAsync(int memberId)
        {
            return _bookingRepository.GetPastBookingsByMemberAsync(memberId);
        }

        public async Task<Booking> CreateBookingAsync(int memberId, int instanceId)
        {
            // Validate booking request
            var validation = await ValidateBookingRequestAsync(memberId, instanceId);
            if (!(bool)validation["IsValid"])
            {
                throw new InvalidOperationException(validation["Message"]?.ToString() ?? "Invalid booking request");
            }

            // Check if member already has a booking for this instance
            var existingBooking = await _bookingRepository.GetMemberBookingForInstanceAsync(memberId, instanceId);
            if (existingBooking != null)
            {
                throw new InvalidOperationException("Member already has a booking for this class instance");
            }

            // Create booking
            var booking = new Booking
            {
                MemberId = memberId,
                InstanceId = instanceId,
                BookingDate = DateTime.Now
            };

            var result = await _bookingRepository.CreateAsync(booking);
            if (result > 0)
            {
                // Increment booking count for the class instance
                await _classInstanceRepository.IncrementBookingsAsync(instanceId);

                // Return the created booking
                return await _bookingRepository.GetMemberBookingForInstanceAsync(memberId, instanceId) 
                    ?? booking;
            }

            throw new Exception("Failed to create booking");
        }

        public async Task<bool> CancelBookingAsync(int bookingId, string? reason = null)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null)
            {
                return false;
            }

            // Cancel the booking
            var result = await _bookingRepository.CancelBookingAsync(bookingId, reason ?? "Cancelled by member");

            if (result)
            {
                // Decrement booking count for the class instance
                await _classInstanceRepository.DecrementBookingsAsync(booking.InstanceId);
            }

            return result;
        }

        public async Task<bool> CanMemberBookClassAsync(int memberId, int instanceId)
        {
            var validation = await ValidateBookingRequestAsync(memberId, instanceId);
            return (bool)validation["IsValid"];
        }

        public async Task<bool> CheckInMemberAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null)
            {
                return false;
            }

            // Check if attendance record already exists
            var existingAttendance = await _attendanceRepository.GetByBookingIdAsync(bookingId);
            if (existingAttendance != null)
            {
                // Update existing attendance
                existingAttendance.Attended = true;
                existingAttendance.CheckInTime = DateTime.Now;
                return await _attendanceRepository.UpdateAsync(existingAttendance);
            }

            // Create new attendance record
            var attendance = new Attendance
            {
                BookingId = bookingId,
                CheckInTime = DateTime.Now,
                Attended = true
            };

            var result = await _attendanceRepository.CreateAsync(attendance);
            return result > 0;
        }

        public async Task<bool> MarkNoShowAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null)
            {
                return false;
            }

            // Check if attendance record exists
            var existingAttendance = await _attendanceRepository.GetByBookingIdAsync(bookingId);
            if (existingAttendance != null)
            {
                // Update existing attendance
                existingAttendance.Attended = false;
                return await _attendanceRepository.UpdateAsync(existingAttendance);
            }

            // Create attendance record marked as no-show
            var attendance = new Attendance
            {
                BookingId = bookingId,
                CheckInTime = DateTime.Now,
                Attended = false
            };

            var result = await _attendanceRepository.CreateAsync(attendance);
            return result > 0;
        }

        public async Task<Dictionary<string, object>> ValidateBookingRequestAsync(int memberId, int instanceId)
        {
            var result = new Dictionary<string, object>
            {
                { "IsValid", false },
                { "Message", "" }
            };

            // Check if member exists
            var member = await _memberRepository.GetByIdAsync(memberId);
            if (member == null)
            {
                result["Message"] = "Member not found";
                return result;
            }

            // Check if member is active
            if (member.Status?.ToLower() != "active")
            {
                result["Message"] = "Member is not active";
                return result;
            }

            // Check if class instance exists
            var classInstance = await _classInstanceRepository.GetByIdAsync(instanceId);
            if (classInstance == null)
            {
                result["Message"] = "Class instance not found";
                return result;
            }

            // Check if class is available for booking
            if (classInstance.Status?.ToLower() != "scheduled")
            {
                result["Message"] = "Class is not available for booking";
                return result;
            }

            // Check if class date is in the future
            if (classInstance.ClassDate.Date < DateTime.Now.Date)
            {
                result["Message"] = "Class date has passed";
                return result;
            }

            // Check if class is full
            if (await _classInstanceRepository.IsClassFullAsync(instanceId))
            {
                result["Message"] = "Class is full";
                return result;
            }

            // Check if member has active subscription
            var hasActiveSubscription = await _subscriptionRepository.HasActiveSubscriptionAsync(memberId);
            if (!hasActiveSubscription)
            {
                result["Message"] = "Member does not have an active subscription";
                return result;
            }

            // Check if member already has a booking for this instance
            var hasBooking = await _bookingRepository.MemberHasBookingForInstanceAsync(memberId, instanceId);
            if (hasBooking)
            {
                result["Message"] = "Member already has a booking for this class";
                return result;
            }

            result["IsValid"] = true;
            result["Message"] = "Booking request is valid";
            return result;
        }
    }
}
