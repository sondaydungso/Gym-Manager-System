using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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
            string query = "SELECT * FROM subscriptions WHERE subscription_id = @SubscriptionID";
            using (var connection = _context.CreateConnection()) // Open a connection to the database
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@SubscriptionID";
                    parameter.Value = subscriptionId;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var subscription = new Subscription
                            {
                                SubscriptionId = Convert.ToInt32(reader["subscription_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                StartDate = reader["start_date"] != DBNull.Value ? Convert.ToDateTime(reader["start_date"]) : default,
                                EndDate = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : default,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : default
                            };
                            return Task.FromResult<Subscription?>(subscription); //Static method by .NET
                        }
                    }
                }
            }

            return Task.FromResult<Subscription?>(null);
        }

        public Task<IEnumerable<Subscription>> GetByMemberIdAsync(int memberId)
        {
            var query = "SELECT * FROM subscriptions WHERE member_id = @MemberID";
            var subscriptions = new List<Subscription>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@MemberID";
                    parameter.Value = memberId;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var subscription = new Subscription
                            {
                                SubscriptionId = Convert.ToInt32(reader["subscription_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                StartDate = reader["start_date"] != DBNull.Value ? Convert.ToDateTime(reader["start_date"]) : default,
                                EndDate = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : default,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : default
                            };
                            subscriptions.Add(subscription);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Subscription>>(subscriptions); //return a list of subscription
        }

        public Task<IEnumerable<Subscription>> GetAllMemberIdAsync()
        {
            var query = "SELECT * FROM subscriptions";
            var subscriptions = new List<Subscription>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var subscription = new Subscription
                            {
                                SubscriptionId = Convert.ToInt32(reader["subscription_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                StartDate = reader["start_date"] != DBNull.Value ? Convert.ToDateTime(reader["start_date"]) : default,
                                EndDate = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : default,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : default
                            };
                            subscriptions.Add(subscription);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Subscription>>(subscriptions); //return a list of subscription
        }
        public Task<Subscription?> GetActiveSubscriptionByMemberIdAsync(int memberId)
        {
            var query = "SELECT * FROM subscriptions WHERE member_id = @MemberID AND status = 'active' AND end_date >= CURDATE()";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@MemberID";
                    parameter.Value = memberId;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var subscription = new Subscription
                            {
                                SubscriptionId = Convert.ToInt32(reader["subscription_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                StartDate = reader["start_date"] != DBNull.Value ? Convert.ToDateTime(reader["start_date"]) : default,
                                EndDate = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : default,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : default
                            };
                            return Task.FromResult<Subscription?>(subscription); //Static method by .NET
                        }
                    }
                }
            }
            return Task.FromResult<Subscription?>(null);
        }

        public Task<IEnumerable<Subscription>> GetExpiringSubscriptionsAsync(int daysAhead)
        {
            var query = "SELECT * FROM subscriptions WHERE status = 'active' AND end_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL @DaysAhead DAY)";
            var subscriptions = new List<Subscription>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@DaysAhead";
                    parameter.Value = daysAhead;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var subscription = new Subscription
                            {
                                SubscriptionId = Convert.ToInt32(reader["subscription_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                StartDate = reader["start_date"] != DBNull.Value ? Convert.ToDateTime(reader["start_date"]) : default,
                                EndDate = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : default,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : default
                            };
                            subscriptions.Add(subscription);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Subscription>>(subscriptions); //return a list of subscription
        }

        public Task<IEnumerable<Subscription>> GetExpiredSubscriptionsAsync()
        {
            var query = "SELECT * FROM subscriptions WHERE status = 'active' AND end_date < CURDATE()";
            var subscriptions = new List<Subscription>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var subscription = new Subscription
                            {
                                SubscriptionId = Convert.ToInt32(reader["subscription_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                StartDate = reader["start_date"] != DBNull.Value ? Convert.ToDateTime(reader["start_date"]) : default,
                                EndDate = reader["end_date"] != DBNull.Value ? Convert.ToDateTime(reader["end_date"]) : default,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                UpdatedAt = reader["updated_at"] != DBNull.Value ? Convert.ToDateTime(reader["updated_at"]) : default
                            };
                            subscriptions.Add(subscription);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Subscription>>(subscriptions); //return a list of subscription
        }

        public Task<int> CreateAsync(Subscription subscription)
        {
            var query = "INSERT INTO subscriptions (member_id, plan_id, start_date, end_date, status, payment_status, created_at, updated_at) " +
                        "VALUES (@MemberID, @PlanID, @StartDate, @EndDate, @Status, @PaymentStatus, @CreatedAt, @UpdatedAt);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Bind parameters directly
                    var memberIdParam = command.CreateParameter();
                    memberIdParam.ParameterName = "@MemberID";
                    memberIdParam.Value = subscription.MemberId;
                    command.Parameters.Add(memberIdParam);

                    var planIdParam = command.CreateParameter();
                    planIdParam.ParameterName = "@PlanID";
                    planIdParam.Value = subscription.PlanId;
                    command.Parameters.Add(planIdParam);

                    var startDateParam = command.CreateParameter();
                    startDateParam.ParameterName = "@StartDate";
                    startDateParam.Value = subscription.StartDate;
                    command.Parameters.Add(startDateParam);

                    var endDateParam = command.CreateParameter();
                    endDateParam.ParameterName = "@EndDate";
                    endDateParam.Value = subscription.EndDate;
                    command.Parameters.Add(endDateParam);

                    var statusParam = command.CreateParameter();
                    statusParam.ParameterName = "@Status";
                    statusParam.Value = "active";
                    command.Parameters.Add(statusParam);

                    var paymentStatusParam = command.CreateParameter();
                    paymentStatusParam.ParameterName = "@PaymentStatus";
                    paymentStatusParam.Value = "pending";
                    command.Parameters.Add(paymentStatusParam);

                    var createdAtParam = command.CreateParameter();
                    createdAtParam.ParameterName = "@CreatedAt";
                    createdAtParam.Value = subscription.CreatedAt;
                    command.Parameters.Add(createdAtParam);

                    var updatedAtParam = command.CreateParameter();
                    updatedAtParam.ParameterName = "@UpdatedAt";
                    updatedAtParam.Value = subscription.UpdatedAt;
                    command.Parameters.Add(updatedAtParam);

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult<int>(result);
                }
            }
        }

        public Task<bool> UpdateAsync(Subscription subscription)
        {
            var query = "UPDATE subscriptions SET member_id = @MemberID, plan_id = @PlanID, " +
                        "start_date = @StartDate, end_date = @EndDate, updated_at = @UpdatedAt " +
                        "WHERE subscription_id = @SubscriptionID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Bind parameters directly
                    var memberIdParam = command.CreateParameter();
                    memberIdParam.ParameterName = "@MemberID";
                    memberIdParam.Value = subscription.MemberId;
                    command.Parameters.Add(memberIdParam);

                    var planIdParam = command.CreateParameter();
                    planIdParam.ParameterName = "@PlanID";
                    planIdParam.Value = subscription.PlanId;
                    command.Parameters.Add(planIdParam);

                    var startDateParam = command.CreateParameter();
                    startDateParam.ParameterName = "@StartDate";
                    startDateParam.Value = subscription.StartDate;
                    command.Parameters.Add(startDateParam);

                    var endDateParam = command.CreateParameter();
                    endDateParam.ParameterName = "@EndDate";
                    endDateParam.Value = subscription.EndDate;
                    command.Parameters.Add(endDateParam);

                    var updatedAtParam = command.CreateParameter();
                    updatedAtParam.ParameterName = "@UpdatedAt";
                    updatedAtParam.Value = subscription.UpdatedAt;
                    command.Parameters.Add(updatedAtParam);

                    var subscriptionIdParam = command.CreateParameter();
                    subscriptionIdParam.ParameterName = "@SubscriptionID";
                    subscriptionIdParam.Value = subscription.SubscriptionId;
                    command.Parameters.Add(subscriptionIdParam);

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was updated
                }
            }
        }

        public Task<bool> DeleteAsync(int subscriptionId)
        {
            var query = "DELETE FROM subscriptions WHERE subscription_id = @SubscriptionID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@SubscriptionID";
                    parameter.Value = subscriptionId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was deleted
                }
            }
        }

        public Task<bool> HasActiveSubscriptionAsync(int memberId)
        {
            var query = "SELECT COUNT(*) FROM subscriptions WHERE member_id = @MemberID AND status = 'active' AND end_date >= CURDATE()";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@MemberID";
                    parameter.Value = memberId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteScalar(); // Execute the command
                    var count = Convert.ToInt32(result);
                    return Task.FromResult(count > 0);
                }
            }
        }
    }
}
