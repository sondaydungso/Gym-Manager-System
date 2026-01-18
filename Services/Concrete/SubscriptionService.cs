using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using Gym_Manager_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager_System.Services.Concrete
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMembershipPlanRepository _membershipPlanRepository;
        private readonly IBookingRepository _bookingRepository;

        public SubscriptionService(
            ISubscriptionRepository subscriptionRepository,
            IMemberRepository memberRepository,
            IMembershipPlanRepository membershipPlanRepository,
            IBookingRepository bookingRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _memberRepository = memberRepository;
            _membershipPlanRepository = membershipPlanRepository;
            _bookingRepository = bookingRepository;
        }

        public Task<Subscription?> GetSubscriptionByIdAsync(int subscriptionId)
        {
            return _subscriptionRepository.GetByIdAsync(subscriptionId);
        }

        public Task<IEnumerable<Subscription>> GetMemberSubscriptionsAsync(int memberId)
        {
            return _subscriptionRepository.GetByMemberIdAsync(memberId);
        }

        public Task<Subscription?> GetActiveSubscriptionAsync(int memberId)
        {
            return _subscriptionRepository.GetActiveSubscriptionByMemberIdAsync(memberId);
        }

        public async Task<Subscription> CreateSubscriptionAsync(int memberId, int planId, DateTime? startDate = null)
        {
            // Validate member exists
            var member = await _memberRepository.GetByIdAsync(memberId);
            if (member == null)
            {
                throw new ArgumentException("Member not found");
            }

            // Validate plan exists
            var plan = await _membershipPlanRepository.GetByIdAsync(planId);
            if (plan == null)
            {
                throw new ArgumentException("Membership plan not found");
            }

            // Check if member already has an active subscription
            var activeSubscription = await _subscriptionRepository.GetActiveSubscriptionByMemberIdAsync(memberId);
            if (activeSubscription != null)
            {
                throw new InvalidOperationException("Member already has an active subscription");
            }

            // Set start date (default to today if not provided)
            var subscriptionStartDate = startDate ?? DateTime.Now.Date;

            // Calculate end date based on plan duration
            var endDate = subscriptionStartDate.AddMonths(plan.PlanDurationInMonths);

            // Create subscription
            var subscription = new Subscription
            {
                MemberId = memberId,
                PlanId = planId,
                StartDate = subscriptionStartDate,
                EndDate = endDate,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var result = await _subscriptionRepository.CreateAsync(subscription);
            if (result > 0)
            {
                // Return the created subscription
                return await _subscriptionRepository.GetActiveSubscriptionByMemberIdAsync(memberId) 
                    ?? subscription;
            }

            throw new Exception("Failed to create subscription");
        }

        public async Task<bool> RenewSubscriptionAsync(int subscriptionId)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);
            if (subscription == null)
            {
                return false;
            }

            // Get the plan to get duration
            var plan = await _membershipPlanRepository.GetByIdAsync(subscription.PlanId);
            if (plan == null)
            {
                return false;
            }

            // Extend the subscription by the plan duration
            subscription.EndDate = subscription.EndDate.AddMonths(plan.PlanDurationInMonths);
            subscription.UpdatedAt = DateTime.Now;

            return await _subscriptionRepository.UpdateAsync(subscription);
        }

        public async Task<bool> CancelSubscriptionAsync(int subscriptionId)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);
            if (subscription == null)
            {
                return false;
            }

            // Update subscription status to cancelled
            // Note: You might want to add a Status property to Subscription model
            // For now, we'll set the end date to today
            subscription.EndDate = DateTime.Now.Date;
            subscription.UpdatedAt = DateTime.Now;

            return await _subscriptionRepository.UpdateAsync(subscription);
        }

        public async Task<bool> PauseSubscriptionAsync(int subscriptionId)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);
            if (subscription == null)
            {
                return false;
            }

            // Pause subscription by extending end date
            // Calculate days remaining and add them to end date when resuming
            // For now, we'll just update the subscription
            subscription.UpdatedAt = DateTime.Now;
            // Note: You might want to add a Status property to handle paused state
            return await _subscriptionRepository.UpdateAsync(subscription);
        }

        public async Task<bool> ResumeSubscriptionAsync(int subscriptionId)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(subscriptionId);
            if (subscription == null)
            {
                return false;
            }

            // Resume subscription
            subscription.UpdatedAt = DateTime.Now;
            // Note: You might want to add a Status property to handle resumed state
            return await _subscriptionRepository.UpdateAsync(subscription);
        }

        public Task<bool> IsSubscriptionActiveAsync(int memberId)
        {
            return _subscriptionRepository.HasActiveSubscriptionAsync(memberId);
        }

        public async Task<bool> IsSubscriptionValidForDateAsync(int memberId, DateTime date)
        {
            var subscription = await _subscriptionRepository.GetActiveSubscriptionByMemberIdAsync(memberId);
            if (subscription == null)
            {
                return false;
            }

            // Check if date is within subscription period
            return date.Date >= subscription.StartDate.Date && date.Date <= subscription.EndDate.Date;
        }

        public Task<IEnumerable<Subscription>> GetExpiringSubscriptionsAsync(int daysAhead)
        {
            return _subscriptionRepository.GetExpiringSubscriptionsAsync(daysAhead);
        }

        public async Task<bool> CheckMembershipLimitsAsync(int memberId, int classInstanceId)
        {
            // Get active subscription
            var subscription = await _subscriptionRepository.GetActiveSubscriptionByMemberIdAsync(memberId);
            if (subscription == null)
            {
                return false;
            }

            // Get plan details
            var plan = await _membershipPlanRepository.GetByIdAsync(subscription.PlanId);
            if (plan == null)
            {
                return false;
            }

            // Check if plan has class limits
            if (plan.MaxClassPerMonth > 0)
            {
                // Get current month's bookings
                var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                var bookings = await _bookingRepository.GetByMemberIdAsync(memberId);
                var monthlyBookings = bookings.Where(b => 
                    b.BookingDate >= startOfMonth && 
                    b.BookingDate <= endOfMonth &&
                    b.CancelReason == null).Count();

                // Check if member has reached the limit
                if (monthlyBookings >= plan.MaxClassPerMonth)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
