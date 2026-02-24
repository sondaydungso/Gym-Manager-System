using Gym_Manager_System.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Services.Interfaces
{
    public interface IMemberService
    {
        Task<Member?> GetMemberByIdAsync(int memberId);
        Task<Member?> GetMemberByEmailAsync(string email);
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<IEnumerable<Member>> GetMembersByStatusAsync(string status);
        Task<Member> CreateMemberAsync(Member member);
        Task<bool> UpdateMemberAsync(Member member);
        Task<bool> DeleteMemberAsync(int memberId);
        Task<bool> UpdateMemberFaceIdAsync(int memberId, Guid faceId);
        Task<bool> IsMemberActiveAsync(int memberId);
        Task<bool> ValidateMemberDataAsync(Member member);
    }
}



