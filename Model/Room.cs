using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class Room
    {
        private int _roomId;
        private string? _roomName;
        private int _capacity;
        private string? _equipmentAvailable;
        private string _status;
        
        private DateTime _createdAt;

        public string Status { get => _status; set => _status = value; }
        public int RoomId { get => _roomId; set => _roomId = value; }
        public string? RoomName { get => _roomName; set => _roomName = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public string? EquipmentAvailable { get => _equipmentAvailable; set => _equipmentAvailable = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }


    }
}
