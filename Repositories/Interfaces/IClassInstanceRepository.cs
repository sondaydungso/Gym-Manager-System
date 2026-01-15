using Gym_Manager_System.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface IClassInstanceRepository
    {
        Task<ClassInstance?> GetByIdAsync(int instanceId);
        Task<IEnumerable<ClassInstance>> GetAllAsync();
        Task<IEnumerable<ClassInstance>> GetByDateAsync(DateTime date);
        Task<IEnumerable<ClassInstance>> GetUpcomingInstancesAsync(int daysAhead);
        Task<IEnumerable<ClassInstance>> GetAvailableInstancesAsync(DateTime fromDate, DateTime toDate);
        Task<IEnumerable<ClassInstance>> GetInstancesByScheduleAsync(int scheduleId);
        Task<IEnumerable<ClassInstance>> GetInstancesByInstructorAsync(int instructorId, DateTime? fromDate, DateTime? toDate);
        Task<int> CreateAsync(ClassInstance instance);
        Task<bool> UpdateAsync(ClassInstance instance);
        Task<bool> IncrementBookingsAsync(int instanceId);
        Task<bool> DecrementBookingsAsync(int instanceId);
        Task<bool> DeleteAsync(int instanceId);
        Task<bool> IsClassFullAsync(int instanceId);
    }
}



