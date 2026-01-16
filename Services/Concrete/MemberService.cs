using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Manager_System.Model;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Services.Concrete
{
    public class MemberService : IMemberService
    {
        public MemberService()
        {
        }
        public Task<Member?> GetMemberByIdAsync(int memberId)
        {
            throw new NotImplementedException();
        }
        public Task<Member?> GetMemberByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Member>> GetMembersByStatusAsync(string status)
        {
            throw new NotImplementedException();
        }
        public Task<Member> CreateMemberAsync(Member member)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateMemberAsync(Member member)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteMemberAsync(int memberId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> IsMemberActiveAsync(int memberId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> ValidateMemberDataAsync(Member member)
        {
            throw new NotImplementedException();
        }

    }
}
