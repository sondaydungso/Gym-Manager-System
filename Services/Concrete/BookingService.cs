using Gym_Manager_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym_Manager_System.Model;

namespace Gym_Manager_System.Services.Concrete
{
    public class BookingService : IBookingService
    {
        public BookingService()
        {
        }

        public Task<Booking?> GetBookingByIdAsync(int bookingId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Booking>> GetMemberBookingsAsync(int memberId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Booking>> GetUpcomingMemberBookingsAsync(int memberId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Booking>> GetPastMemberBookingsAsync(int memberId)
        {
            throw new NotImplementedException();
        }
        public Task<Booking> CreateBookingAsync(int memberId, int instanceId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CancelBookingAsync(int bookingId, string? reason = null)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CanMemberBookClassAsync(int memberId, int instanceId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CheckInMemberAsync(int bookingId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> MarkNoShowAsync(int bookingId)
        {
            throw new NotImplementedException();
        }
        public Task<Dictionary<string, object>> ValidateBookingRequestAsync(int memberId, int instanceId)
        {
            throw new NotImplementedException();
        }


    }
}
