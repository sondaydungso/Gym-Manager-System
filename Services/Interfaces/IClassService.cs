using Gym_Manager_System.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Services.Interfaces
{
    public interface IClassService
    {
        Task<ClassInstance?> GetClassInstanceByIdAsync(int instanceId);
        Task<IEnumerable<ClassInstance>> GetAvailableClassesAsync(DateTime fromDate, DateTime toDate);
        Task<IEnumerable<ClassInstance>> GetUpcomingClassesAsync(int daysAhead);
        Task<IEnumerable<ClassInstance>> GetClassesByDateAsync(DateTime date);
        Task<IEnumerable<ClassInstance>> GetClassesByInstructorAsync(int instructorId, DateTime? fromDate, DateTime? toDate);
        Task<ClassInstance> CreateClassInstanceAsync(ClassInstance instance);
        Task<bool> GenerateClassInstancesFromScheduleAsync(DateTime fromDate, DateTime toDate);
        Task<bool> CancelClassInstanceAsync(int instanceId, string reason);
        Task<bool> UpdateClassStatusAsync(int instanceId, string status);
        Task<bool> IsClassAvailableForBookingAsync(int instanceId);
    }
}



