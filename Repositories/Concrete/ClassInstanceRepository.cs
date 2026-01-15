using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class ClassInstanceRepository : IClassInstanceRepository
    {
        private readonly DatabaseContext _context;

        public ClassInstanceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<ClassInstance?> GetByIdAsync(int instanceId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassInstance>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassInstance>> GetByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassInstance>> GetUpcomingInstancesAsync(int daysAhead)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassInstance>> GetAvailableInstancesAsync(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassInstance>> GetInstancesByScheduleAsync(int scheduleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassInstance>> GetInstancesByInstructorAsync(int instructorId, DateTime? fromDate, DateTime? toDate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(ClassInstance instance)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ClassInstance instance)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IncrementBookingsAsync(int instanceId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DecrementBookingsAsync(int instanceId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int instanceId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsClassFullAsync(int instanceId)
        {
            throw new NotImplementedException();
        }
    }
}
