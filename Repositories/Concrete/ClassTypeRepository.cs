using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class ClassTypeRepository : IClassTypeRepository
    {
        private readonly DatabaseContext _context;

        public ClassTypeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<ClassType?> GetByIdAsync(int classTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClassType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(ClassType classType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ClassType classType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int classTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int classTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
