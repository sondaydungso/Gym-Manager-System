using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class ClassSchedule
    {
        private int _classScheduleId;
        private int _classTypeId;
        private int _roomId;
        private int _instructorId;
        private int _dayOfWeek; // 0 = Sunday, 1 = Monday, ..., 6 = Saturday  
        private TimeSpan _startTime;
        private bool _isActive = true; // Default value set to true  
        private DateTime _effectiveFrom;
        private DateTime _effectiveUntil;
        private DateTime _createdAt;

        public int ClassScheduleId { get => _classScheduleId; set => _classScheduleId = value; }
        public int ClassTypeId { get => _classTypeId; set => _classTypeId = value; }
        public int RoomId { get => _roomId; set => _roomId = value; }
        public int InstructorId { get => _instructorId; set => _instructorId = value; }
        public int DayOfWeek { get => _dayOfWeek; set => _dayOfWeek = value; }
        public TimeSpan StartTime { get => _startTime; set => _startTime = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public DateTime EffectiveFrom { get => _effectiveFrom; set => _effectiveFrom = value; }
        public DateTime EffectiveUntil { get => _effectiveUntil; set => _effectiveUntil = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }

    }
}
