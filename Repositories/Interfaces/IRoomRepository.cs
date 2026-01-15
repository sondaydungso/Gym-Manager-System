using Gym_Manager_System.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room?> GetByIdAsync(int roomId);
        Task<IEnumerable<Room>> GetAllAsync();
        Task<IEnumerable<Room>> GetAvailableRoomsAsync();
        Task<int> CreateAsync(Room room);
        Task<bool> UpdateAsync(Room room);
        Task<bool> DeleteAsync(int roomId);
        Task<bool> ExistsAsync(int roomId);
        Task<bool> IsRoomAvailableAsync(int roomId);
    }
}



