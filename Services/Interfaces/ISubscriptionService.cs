using Gym_Manager_System.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<Subscription?> GetSubscriptionByIdAsync(int subscriptionId);
        Task<IEnumerable<Subscription>> GetMemberSubscriptionsAsync(int memberId);
        Task<IEnumerable<Subscription>> GetAllMember();
        Task<Subscription?> GetActiveSubscriptionAsync(int memberId);
        Task<Subscription> CreateSubscriptionAsync(int memberId, int planId, DateTime? startDate = null);
        Task<bool> RenewSubscriptionAsync(int subscriptionId);
        Task<bool> CancelSubscriptionAsync(int subscriptionId);
        Task<bool> PauseSubscriptionAsync(int subscriptionId);
        Task<bool> ResumeSubscriptionAsync(int subscriptionId);
        Task<bool> IsSubscriptionActiveAsync(int memberId);
        Task<bool> IsSubscriptionValidForDateAsync(int memberId, DateTime date);
        Task<IEnumerable<Subscription>> GetExpiringSubscriptionsAsync(int daysAhead);
        Task<bool> CheckMembershipLimitsAsync(int memberId, int classInstanceId);
    }
}



