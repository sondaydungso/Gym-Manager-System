using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Model
{
    public class MembershipPlan
    {
        private int _planId;
        private string? _planName;
        private int _planDurationInMonths;
        private decimal _planPrice;
        private int _maxClassPerMonth;
        private string? _planDescription;
        public enum IsActive { Yes, No }
        private DateTime _createdAt;

        public int PlanId { get => _planId; set => _planId = value; }
        public string? PlanName { get => _planName; set => _planName = value; }
        public int PlanDurationInMonths { get => _planDurationInMonths; set => _planDurationInMonths = value; }
        public decimal PlanPrice { get => _planPrice; set => _planPrice = value; }

        public int MaxClassPerMonth { get => _maxClassPerMonth; set => _maxClassPerMonth = value; }
        public string? PlanDescription { get => _planDescription; set => _planDescription = value; }
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }


    }
}
