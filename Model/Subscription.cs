using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class Subscription
    {
        private int _subscriptionId;
        private int _memberId;
        private int _planId;
        private DateTime _startDate;
        private DateTime _endDate;
        public enum Status { Active, Expired, Cancelled, Paused }
        public enum PaymentStatus { Paid, Unpaid, Pending }
        private DateTime _createdAt;
        private DateTime _updatedAt;

        public int SubscriptionId { get => _subscriptionId; set => _subscriptionId = value; }
        public int MemberId { get => _memberId; set => _memberId = value; }
        public int PlanId { get => _planId; set => _planId = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
        public DateTime UpdatedAt { get => _updatedAt; set => _updatedAt = value; }

    }
}
