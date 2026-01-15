using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class MembershipPlanRepository : IMembershipPlanRepository
    {
        private readonly DatabaseContext _context;

        public MembershipPlanRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<MembershipPlan?> GetByIdAsync(int planId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MembershipPlan>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MembershipPlan>> GetActivePlansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(MembershipPlan plan)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(MembershipPlan plan)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int planId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int planId)
        {
            throw new NotImplementedException();
        }
    }
}
