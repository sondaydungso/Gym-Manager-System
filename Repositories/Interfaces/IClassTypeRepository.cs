using Gym_Manager_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface IClassTypeRepository
    {
        Task<ClassType?> GetByIdAsync(int classTypeId);
        Task<IEnumerable<ClassType>> GetAllAsync();
        Task<int> CreateAsync(ClassType classType);
        Task<bool> UpdateAsync(ClassType classType);
        Task<bool> DeleteAsync(int classTypeId);
        Task<bool> ExistsAsync(int classTypeId);
    }
}



