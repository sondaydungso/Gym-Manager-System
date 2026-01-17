using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class MembershipPlanRepository : IMembershipPlanRepository
    {
        private readonly DatabaseContext _context;

        public MembershipPlanRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<MembershipPlan?> GetByIdAsync(int planId)
        {
            string query = "SELECT * FROM membership_plans WHERE plan_id = @PlanID";
            using (var connection = _context.CreateConnection()) // Open a connection to the database
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@PlanID";
                    parameter.Value = planId;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var plan = new MembershipPlan
                            {
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                PlanName = reader["plan_name"]?.ToString(),
                                PlanDurationInMonths = Convert.ToInt32(reader["duration_months"]),
                                PlanPrice = Convert.ToDecimal(reader["price"]),
                                MaxClassPerMonth = reader["max_classes_per_month"] != DBNull.Value ? Convert.ToInt32(reader["max_classes_per_month"]) : 0,
                                PlanDescription = reader["description"]?.ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            return Task.FromResult<MembershipPlan?>(plan); //Static method by .NET
                        }
                    }
                }
            }

            return Task.FromResult<MembershipPlan?>(null);
        }

        public Task<IEnumerable<MembershipPlan>> GetAllAsync()
        {
            var query = "SELECT * FROM membership_plans";
            var plans = new List<MembershipPlan>();
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
                            var plan = new MembershipPlan
                            {
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                PlanName = reader["plan_name"]?.ToString(),
                                PlanDurationInMonths = Convert.ToInt32(reader["duration_months"]),
                                PlanPrice = Convert.ToDecimal(reader["price"]),
                                MaxClassPerMonth = reader["max_classes_per_month"] != DBNull.Value ? Convert.ToInt32(reader["max_classes_per_month"]) : 0,
                                PlanDescription = reader["description"]?.ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            plans.Add(plan);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<MembershipPlan>>(plans); //return a list of plan
        }

        public Task<IEnumerable<MembershipPlan>> GetActivePlansAsync()
        {
            var query = "SELECT * FROM membership_plans WHERE is_active = 1";
            var plans = new List<MembershipPlan>();
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
                            var plan = new MembershipPlan
                            {
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                PlanName = reader["plan_name"]?.ToString(),
                                PlanDurationInMonths = Convert.ToInt32(reader["duration_months"]),
                                PlanPrice = Convert.ToDecimal(reader["price"]),
                                MaxClassPerMonth = reader["max_classes_per_month"] != DBNull.Value ? Convert.ToInt32(reader["max_classes_per_month"]) : 0,
                                PlanDescription = reader["description"]?.ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            plans.Add(plan);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<MembershipPlan>>(plans); //return a list of plan
        }

        public Task<int> CreateAsync(MembershipPlan plan)
        {
            var query = "INSERT INTO membership_plans (plan_name, duration_months, price, max_classes_per_month, description, is_active, created_at) " +
                        "VALUES (@PlanName, @DurationMonths, @Price, @MaxClassesPerMonth, @Description, @IsActive, @CreatedAt);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@PlanName", plan.PlanName ?? (object)DBNull.Value },
                        { "@DurationMonths", plan.PlanDurationInMonths },
                        { "@Price", plan.PlanPrice },
                        { "@MaxClassesPerMonth", plan.MaxClassPerMonth },
                        { "@Description", plan.PlanDescription ?? (object)DBNull.Value },
                        { "@IsActive", 1 },
                        { "@CreatedAt", plan.CreatedAt }
                    };

                    // Add parameters to the command
                    foreach (var param in parameters)
                    {
                        var parameter = command.CreateParameter();
                        parameter.ParameterName = param.Key;
                        parameter.Value = param.Value;
                        command.Parameters.Add(parameter);
                    }

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult<int>(result);
                }
            }
        }

        public Task<bool> UpdateAsync(MembershipPlan plan)
        {
            var query = "UPDATE membership_plans SET plan_name = @PlanName, duration_months = @DurationMonths, " +
                        "price = @Price, max_classes_per_month = @MaxClassesPerMonth, description = @Description " +
                        "WHERE plan_id = @PlanID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@PlanName", plan.PlanName ?? (object)DBNull.Value },
                        { "@DurationMonths", plan.PlanDurationInMonths },
                        { "@Price", plan.PlanPrice },
                        { "@MaxClassesPerMonth", plan.MaxClassPerMonth },
                        { "@Description", plan.PlanDescription ?? (object)DBNull.Value },
                        { "@PlanID", plan.PlanId }
                    };

                    // Add parameters to the command
                    foreach (var param in parameters)
                    {
                        var parameter = command.CreateParameter();
                        parameter.ParameterName = param.Key;
                        parameter.Value = param.Value;
                        command.Parameters.Add(parameter);
                    }

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was updated
                }
            }
        }

        public Task<bool> DeleteAsync(int planId)
        {
            var query = "DELETE FROM membership_plans WHERE plan_id = @PlanID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@PlanID";
                    parameter.Value = planId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was deleted
                }
            }
        }

        public Task<bool> ExistsAsync(int planId)
        {
            var query = "SELECT COUNT(*) FROM membership_plans WHERE plan_id = @PlanID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@PlanID";
                    parameter.Value = planId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteScalar(); // Execute the command
                    var count = Convert.ToInt32(result);
                    return Task.FromResult(count > 0);
                }
            }
        }
    }
}
