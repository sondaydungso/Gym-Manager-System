using Gym_Manager_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Services.Concrete
{
    public class SubscriptionService
    {
        public SubscriptionService()
        {
        }
        public Task<Subscription?> GetSubscriptionByIdAsync(int subscriptionId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Subscription>> GetMemberSubscriptionsAsync(int memberId)
        {
            throw new NotImplementedException();
        }
        public Task<Subscription?> GetActiveSubscriptionAsync(int memberId)
        {
            throw new NotImplementedException();
        }
        public Task<Subscription> CreateSubscriptionAsync(int memberId, int planId, DateTime? startDate = null)
        {
            throw new NotImplementedException();
        }
        public Task<bool> RenewSubscriptionAsync(int subscriptionId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CancelSubscriptionAsync(int subscriptionId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> PauseSubscriptionAsync(int subscriptionId)
        {
            throw new NotImplementedException();
        }
        Task<bool> ResumeSubscriptionAsync(int subscriptionId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> IsSubscriptionActiveAsync(int memberId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> IsSubscriptionValidForDateAsync(int memberId, DateTime date)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Subscription>> GetExpiringSubscriptionsAsync(int daysAhead)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CheckMembershipLimitsAsync(int memberId, int classInstanceId)
        {
            throw new NotImplementedException();
        }
    }
}
