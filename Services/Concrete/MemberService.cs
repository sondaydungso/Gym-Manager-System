using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using Gym_Manager_System.Services.Interfaces;

namespace Gym_Manager_System.Services.Concrete
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Task<Member?> GetMemberByIdAsync(int memberId)
        {
            return _memberRepository.GetByIdAsync(memberId);
        }

        public Task<Member?> GetMemberByEmailAsync(string email)
        {
            return _memberRepository.GetByEmailAsync(email);
        }

        public Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return _memberRepository.GetAllAsync();
        }

        public Task<IEnumerable<Member>> GetMembersByStatusAsync(string status)
        {
            return _memberRepository.GetByStatusAsync(status);
        }

        public async Task<Member> CreateMemberAsync(Member member)
        {
            // Validate member data
            if (!await ValidateMemberDataAsync(member))
            {
                throw new ArgumentException("Invalid member data");
            }

            // Check if email already exists
            var existingMember = await _memberRepository.GetByEmailAsync(member.Email);
            if (existingMember != null)
            {
                throw new InvalidOperationException("Member with this email already exists");
            }

            // Set default values
            if (member.JoinDate == default)
            {
                member.JoinDate = DateTime.Now;
            }

            // Create member
            var result = await _memberRepository.CreateAsync(member);
            if (result > 0)
            {
                // Return the created member (you might want to fetch it by email or ID)
                return await _memberRepository.GetByEmailAsync(member.Email) ?? member;
            }

            throw new Exception("Failed to create member");
        }

        public Task<bool> UpdateMemberAsync(Member member)
        {
            // Validate member data
            if (!ValidateMemberDataAsync(member).Result)
            {
                return Task.FromResult(false);
            }

            return _memberRepository.UpdateAsync(member);
        }

        public Task<bool> DeleteMemberAsync(int memberId)
        {
            return _memberRepository.DeleteAsync(memberId);
        }

        public Task<bool> UpdateMemberFaceIdAsync(int memberId, Guid faceId)
        {
            return _memberRepository.UpdateFaceIdAsync(memberId, faceId);
        }

        public async Task<bool> IsMemberActiveAsync(int memberId)
        {
            var member = await _memberRepository.GetByIdAsync(memberId);
            return member != null && member.Status?.ToLower() == "active";
        }

        public Task<bool> ValidateMemberDataAsync(Member member)
        {
            // Basic validation
            if (member == null)
            {
                return Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(member.FirstName))
            {
                return Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(member.LastName))
            {
                return Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(member.Email))
            {
                return Task.FromResult(false);
            }

            // Email format validation (basic)
            if (!member.Email.Contains("@") || !member.Email.Contains("."))
            {
                return Task.FromResult(false);
            }

            // Date of birth validation
            if (member.DateOfBirth > DateTime.Now.AddYears(-18))
            {
                // Member must be at least 18 years old
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
