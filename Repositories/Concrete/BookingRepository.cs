using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DatabaseContext _context;

        public BookingRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Booking?> GetByIdAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetByMemberIdAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetByInstanceIdAsync(int instanceId)
        {
            throw new NotImplementedException();
        }

        public Task<Booking?> GetMemberBookingForInstanceAsync(int memberId, int instanceId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetUpcomingBookingsByMemberAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetPastBookingsByMemberAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelBookingAsync(int bookingId, string reason)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MemberHasBookingForInstanceAsync(int memberId, int instanceId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetBookingCountForInstanceAsync(int instanceId)
        {
            throw new NotImplementedException();
        }
    }
}
