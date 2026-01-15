using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class ClassScheduleRepository : IClassScheduleRepository
    {
        private readonly DatabaseContext _context;

        public ClassScheduleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<ClassSchedule?> GetByIdAsync(int scheduleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassSchedule>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassSchedule>> GetActiveSchedulesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassSchedule>> GetSchedulesByDayAsync(int dayOfWeek)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassSchedule>> GetSchedulesByClassTypeAsync(int classTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassSchedule>> GetSchedulesByInstructorAsync(int instructorId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(ClassSchedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ClassSchedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int scheduleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int scheduleId)
        {
            throw new NotImplementedException();
        }
    }
}
