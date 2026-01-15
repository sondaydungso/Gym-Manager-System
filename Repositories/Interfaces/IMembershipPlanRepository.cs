using Gym_Manager_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface IMembershipPlanRepository
    {
        Task<MembershipPlan?> GetByIdAsync(int planId);
        Task<IEnumerable<MembershipPlan>> GetAllAsync();
        Task<IEnumerable<MembershipPlan>> GetActivePlansAsync();
        Task<int> CreateAsync(MembershipPlan plan);
        Task<bool> UpdateAsync(MembershipPlan plan);
        Task<bool> DeleteAsync(int planId);
        Task<bool> ExistsAsync(int planId);
    }
}



