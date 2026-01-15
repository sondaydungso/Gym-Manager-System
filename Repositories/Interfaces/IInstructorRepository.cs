using Gym_Manager_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        Task<Instructor?> GetByIdAsync(int instructorId);
        Task<IEnumerable<Instructor>> GetAllAsync();
        Task<IEnumerable<Instructor>> GetActiveInstructorsAsync();
        Task<int> CreateAsync(Instructor instructor);
        Task<bool> UpdateAsync(Instructor instructor);
        Task<bool> DeleteAsync(int instructorId);
        Task<bool> ExistsAsync(int instructorId);
    }
}



