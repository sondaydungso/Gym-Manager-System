using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly DatabaseContext _context;

        public InstructorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Instructor?> GetByIdAsync(int instructorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Instructor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Instructor>> GetActiveInstructorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int instructorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int instructorId)
        {
            throw new NotImplementedException();
        }
    }
}
