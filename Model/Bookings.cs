using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class Booking
    {
        private int _bookingId;
        private int _memberId;
        private int _instanceId;
        private DateTime _bookingDate;
        private DateTime _cancelledAt;
        private string? _cancelReason;
        public enum Status { Booked, Cancelled, Attended, NoShow }

        public int BookingId { get => _bookingId; set => _bookingId = value; }
        public int MemberId { get => _memberId; set => _memberId = value; }
        public int InstanceId { get => _instanceId; set => _instanceId = value; }
        public DateTime BookingDate { get => _bookingDate; set => _bookingDate = value; }
        public DateTime CancelledAt { get => _cancelledAt; set => _cancelledAt = value; }
        public string? CancelReason { get => _cancelReason; set => _cancelReason = value; }

    }
}
