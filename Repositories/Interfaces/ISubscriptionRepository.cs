using Gym_Manager_System.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<Subscription?> GetByIdAsync(int subscriptionId);
        Task<IEnumerable<Subscription>> GetByMemberIdAsync(int memberId);
        Task<Subscription?> GetActiveSubscriptionByMemberIdAsync(int memberId);
        Task<IEnumerable<Subscription>> GetExpiringSubscriptionsAsync(int daysAhead);
        Task<IEnumerable<Subscription>> GetExpiredSubscriptionsAsync();
        Task<int> CreateAsync(Subscription subscription);
        Task<bool> UpdateAsync(Subscription subscription);
        Task<bool> DeleteAsync(int subscriptionId);
        Task<bool> HasActiveSubscriptionAsync(int memberId);
    }
}



