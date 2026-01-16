using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Services.Concrete
{
    public class ClassService : IClassService
    {
        public ClassService()
        {
        }

        public Task<ClassInstance?> GetClassInstanceByIdAsync(int instanceId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ClassInstance>> GetAvailableClassesAsync(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ClassInstance>> GetUpcomingClassesAsync(int daysAhead)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ClassInstance>> GetClassesByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ClassInstance>> GetClassesByInstructorAsync(int instructorId, DateTime? fromDate, DateTime? toDate)
        {
            throw new NotImplementedException();
        }
        public Task<ClassInstance> CreateClassInstanceAsync(ClassInstance instance)
        {
            throw new NotImplementedException();
        }
        public Task<bool> GenerateClassInstancesFromScheduleAsync(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CancelClassInstanceAsync(int instanceId, string reason)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateClassStatusAsync(int instanceId, string status)
        {
            throw new NotImplementedException();
        }
        public Task<bool> IsClassAvailableForBookingAsync(int instanceId)
        {
            throw new NotImplementedException();
        }



    }
}
