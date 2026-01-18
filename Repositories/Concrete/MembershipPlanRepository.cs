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
                                PlanPrice = reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]) : 0,
                                MaxClassPerMonth = reader["max_classes_per_month"] != DBNull.Value ? Convert.ToInt32(reader["max_classes_per_month"]) : 0,
                                PlanDescription = reader["description"]?.ToString(),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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
                                PlanPrice = reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]) : 0,
                                MaxClassPerMonth = reader["max_classes_per_month"] != DBNull.Value ? Convert.ToInt32(reader["max_classes_per_month"]) : 0,
                                PlanDescription = reader["description"]?.ToString(),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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
                                PlanPrice = reader["price"] != DBNull.Value ? Convert.ToDecimal(reader["price"]) : 0,
                                MaxClassPerMonth = reader["max_classes_per_month"] != DBNull.Value ? Convert.ToInt32(reader["max_classes_per_month"]) : 0,
                                PlanDescription = reader["description"]?.ToString(),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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

                    // Bind parameters directly
                    var planNameParam = command.CreateParameter();
                    planNameParam.ParameterName = "@PlanName";
                    planNameParam.Value = plan.PlanName ?? (object)DBNull.Value;
                    command.Parameters.Add(planNameParam);

                    var durationMonthsParam = command.CreateParameter();
                    durationMonthsParam.ParameterName = "@DurationMonths";
                    durationMonthsParam.Value = plan.PlanDurationInMonths;
                    command.Parameters.Add(durationMonthsParam);

                    var priceParam = command.CreateParameter();
                    priceParam.ParameterName = "@Price";
                    priceParam.Value = plan.PlanPrice;
                    command.Parameters.Add(priceParam);

                    var maxClassesPerMonthParam = command.CreateParameter();
                    maxClassesPerMonthParam.ParameterName = "@MaxClassesPerMonth";
                    maxClassesPerMonthParam.Value = plan.MaxClassPerMonth;
                    command.Parameters.Add(maxClassesPerMonthParam);

                    var descriptionParam = command.CreateParameter();
                    descriptionParam.ParameterName = "@Description";
                    descriptionParam.Value = plan.PlanDescription ?? (object)DBNull.Value;
                    command.Parameters.Add(descriptionParam);

                    var isActiveParam = command.CreateParameter();
                    isActiveParam.ParameterName = "@IsActive";
                    isActiveParam.Value = 1;
                    command.Parameters.Add(isActiveParam);

                    var createdAtParam = command.CreateParameter();
                    createdAtParam.ParameterName = "@CreatedAt";
                    createdAtParam.Value = plan.CreatedAt;
                    command.Parameters.Add(createdAtParam);

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

                    // Bind parameters directly
                    var planNameParam = command.CreateParameter();
                    planNameParam.ParameterName = "@PlanName";
                    planNameParam.Value = plan.PlanName ?? (object)DBNull.Value;
                    command.Parameters.Add(planNameParam);

                    var durationMonthsParam = command.CreateParameter();
                    durationMonthsParam.ParameterName = "@DurationMonths";
                    durationMonthsParam.Value = plan.PlanDurationInMonths;
                    command.Parameters.Add(durationMonthsParam);

                    var priceParam = command.CreateParameter();
                    priceParam.ParameterName = "@Price";
                    priceParam.Value = plan.PlanPrice;
                    command.Parameters.Add(priceParam);

                    var maxClassesPerMonthParam = command.CreateParameter();
                    maxClassesPerMonthParam.ParameterName = "@MaxClassesPerMonth";
                    maxClassesPerMonthParam.Value = plan.MaxClassPerMonth;
                    command.Parameters.Add(maxClassesPerMonthParam);

                    var descriptionParam = command.CreateParameter();
                    descriptionParam.ParameterName = "@Description";
                    descriptionParam.Value = plan.PlanDescription ?? (object)DBNull.Value;
                    command.Parameters.Add(descriptionParam);

                    var planIdParam = command.CreateParameter();
                    planIdParam.ParameterName = "@PlanID";
                    planIdParam.Value = plan.PlanId;
                    command.Parameters.Add(planIdParam);

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
