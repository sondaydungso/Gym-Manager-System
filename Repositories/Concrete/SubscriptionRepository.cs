using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly DatabaseContext _context;

        public SubscriptionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Subscription?> GetByIdAsync(int subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Subscription>> GetByMemberIdAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription?> GetActiveSubscriptionByMemberIdAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Subscription>> GetExpiringSubscriptionsAsync(int daysAhead)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Subscription>> GetExpiredSubscriptionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasActiveSubscriptionAsync(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
