using Gym_Manager_System.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member?> GetByIdAsync(int memberId);
        Task<Member?> GetByEmailAsync(string email);
        Task<IEnumerable<Member>> GetAllAsync();
        Task<IEnumerable<Member>> GetByStatusAsync(string status);
        Task<int> CreateAsync(Member member);
        Task<bool> UpdateAsync(Member member);
        Task<bool> UpdateFaceIdAsync(int memberId, Guid faceId);
        Task<bool> DeleteAsync(int memberId);
        Task<bool> ExistsAsync(int memberId);
    }
}



