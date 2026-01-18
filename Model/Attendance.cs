using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class Attendance
    {
        private int _attendanceId;
        private int _bookingId;
        private DateTime _checkInTime;
        private bool _attended;
        private string _note = string.Empty;

        public int AttendanceId { get => _attendanceId; set => _attendanceId = value; }
        public int BookingId { get => _bookingId; set => _bookingId = value; }
        public DateTime CheckInTime { get => _checkInTime; set => _checkInTime = value; }
        public bool Attended { get => _attended; set => _attended = value; }
        public string Note { get => _note; set => _note = value; }

    }
}
