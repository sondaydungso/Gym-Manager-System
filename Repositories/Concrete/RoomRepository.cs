using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DatabaseContext _context;

        public RoomRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Room?> GetByIdAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetAvailableRoomsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Room room)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Room room)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsRoomAvailableAsync(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
