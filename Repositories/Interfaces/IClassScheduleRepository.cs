using Gym_Manager_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface IClassScheduleRepository
    {
        Task<ClassSchedule?> GetByIdAsync(int scheduleId);
        Task<IEnumerable<ClassSchedule>> GetAllAsync();
        Task<IEnumerable<ClassSchedule>> GetActiveSchedulesAsync();
        Task<IEnumerable<ClassSchedule>> GetSchedulesByDayAsync(int dayOfWeek);
        Task<IEnumerable<ClassSchedule>> GetSchedulesByClassTypeAsync(int classTypeId);
        Task<IEnumerable<ClassSchedule>> GetSchedulesByInstructorAsync(int instructorId);
        Task<int> CreateAsync(ClassSchedule schedule);
        Task<bool> UpdateAsync(ClassSchedule schedule);
        Task<bool> DeleteAsync(int scheduleId);
        Task<bool> ExistsAsync(int scheduleId);
    }
}



