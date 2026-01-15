using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DatabaseContext _context;

        public MemberRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Member?> GetByIdAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<Member?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Member>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Member>> GetByStatusAsync(string status)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Member member)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Member member)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
