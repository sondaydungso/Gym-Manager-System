using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class ClassInstance
    {
        private int _classInstanceId;
        private int _classScheduleId;
        private DateTime _classDate;
        private int _instructorId;
        private int _roomId;
        private DateTime _createdAt;
        private TimeOnly _startTime;
        private TimeOnly _endTime;
        private int _capacity;
        private int _currentBookings;
        private string? _cancelationReason;
        public enum Status { Scheduled, Completed, Canceled }
        public int ClassInstanceId { get => _classInstanceId; set => _classInstanceId = value; }
        public int ClassScheduleId { get => _classScheduleId; set => _classScheduleId = value; }
        public DateTime ClassDate { get => _classDate; set => _classDate = value; }
        public int InstructorId { get => _instructorId; set => _instructorId = value; }
        public int RoomId { get => _roomId; set => _roomId = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
        public TimeOnly StartTime { get => _startTime; set => _startTime = value; }
        public TimeOnly EndTime { get => _endTime; set => _endTime = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public int CurrentBookings { get => _currentBookings; set => _currentBookings = value; }
        public string? CancelationReason { get => _cancelationReason; set => _cancelationReason = value; }

    }
}
