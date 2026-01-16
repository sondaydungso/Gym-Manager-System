using Gym_Manager_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<Booking>> GetMemberBookingsAsync(int memberId);
        Task<IEnumerable<Booking>> GetUpcomingMemberBookingsAsync(int memberId);
        Task<IEnumerable<Booking>> GetPastMemberBookingsAsync(int memberId);
        Task<Booking> CreateBookingAsync(int memberId, int instanceId);
        Task<bool> CancelBookingAsync(int bookingId, string? reason = null);
        Task<bool> CanMemberBookClassAsync(int memberId, int instanceId);
        Task<bool> CheckInMemberAsync(int bookingId);
        Task<bool> MarkNoShowAsync(int bookingId);
        Task<Dictionary<string, object>> ValidateBookingRequestAsync(int memberId, int instanceId);
    }
}



