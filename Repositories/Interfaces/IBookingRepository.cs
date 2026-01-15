using Gym_Manager_System.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking?> GetByIdAsync(int bookingId);
        Task<IEnumerable<Booking>> GetByMemberIdAsync(int memberId);
        Task<IEnumerable<Booking>> GetByInstanceIdAsync(int instanceId);
        Task<Booking?> GetMemberBookingForInstanceAsync(int memberId, int instanceId);
        Task<IEnumerable<Booking>> GetUpcomingBookingsByMemberAsync(int memberId);
        Task<IEnumerable<Booking>> GetPastBookingsByMemberAsync(int memberId);
        Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date);
        Task<int> CreateAsync(Booking booking);
        Task<bool> UpdateAsync(Booking booking);
        Task<bool> CancelBookingAsync(int bookingId, string reason);
        Task<bool> DeleteAsync(int bookingId);
        Task<bool> MemberHasBookingForInstanceAsync(int memberId, int instanceId);
        Task<int> GetBookingCountForInstanceAsync(int instanceId);
    }
}



