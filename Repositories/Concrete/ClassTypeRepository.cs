using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class ClassTypeRepository : IClassTypeRepository
    {
        private readonly DatabaseContext _context;

        public ClassTypeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<ClassType?> GetByIdAsync(int classTypeId)
        {
            string query = "SELECT * FROM class_types WHERE class_type_id = @ClassTypeID";
            using (var connection = _context.CreateConnection()) // Open a connection to the database
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@ClassTypeID";
                    parameter.Value = classTypeId;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var classType = new ClassType
                            {
                                ClassTypeId = Convert.ToInt32(reader["class_type_id"]),
                                ClassTypeName = reader["class_name"]?.ToString(),
                                ClassTypeDescription = reader["description"]?.ToString(),
                                DurationInMinutes = Convert.ToInt32(reader["duration_minutes"]),
                                Capacity = Convert.ToInt32(reader["default_capacity"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            return Task.FromResult<ClassType?>(classType); //Static method by .NET
                        }
                    }
                }
            }

            return Task.FromResult<ClassType?>(null);
        }

        public Task<IEnumerable<ClassType>> GetAllAsync()
        {
            var query = "SELECT * FROM class_types";
            var classTypes = new List<ClassType>();
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
                            var classType = new ClassType
                            {
                                ClassTypeId = Convert.ToInt32(reader["class_type_id"]),
                                ClassTypeName = reader["class_name"]?.ToString(),
                                ClassTypeDescription = reader["description"]?.ToString(),
                                DurationInMinutes = Convert.ToInt32(reader["duration_minutes"]),
                                Capacity = Convert.ToInt32(reader["default_capacity"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            classTypes.Add(classType);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassType>>(classTypes); //return a list of classType
        }

        public Task<int> CreateAsync(ClassType classType)
        {
            var query = "INSERT INTO class_types (class_name, description, duration_minutes, default_capacity, created_at) " +
                        "VALUES (@ClassName, @Description, @DurationMinutes, @DefaultCapacity, @CreatedAt);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@ClassName", classType.ClassTypeName ?? (object)DBNull.Value },
                        { "@Description", classType.ClassTypeDescription ?? (object)DBNull.Value },
                        { "@DurationMinutes", classType.DurationInMinutes },
                        { "@DefaultCapacity", classType.Capacity },
                        { "@CreatedAt", classType.CreatedAt }
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

        public Task<bool> UpdateAsync(ClassType classType)
        {
            var query = "UPDATE class_types SET class_name = @ClassName, description = @Description, " +
                        "duration_minutes = @DurationMinutes, default_capacity = @DefaultCapacity " +
                        "WHERE class_type_id = @ClassTypeID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@ClassName", classType.ClassTypeName ?? (object)DBNull.Value },
                        { "@Description", classType.ClassTypeDescription ?? (object)DBNull.Value },
                        { "@DurationMinutes", classType.DurationInMinutes },
                        { "@DefaultCapacity", classType.Capacity },
                        { "@ClassTypeID", classType.ClassTypeId }
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

        public Task<bool> DeleteAsync(int classTypeId)
        {
            var query = "DELETE FROM class_types WHERE class_type_id = @ClassTypeID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@ClassTypeID";
                    parameter.Value = classTypeId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was deleted
                }
            }
        }

        public Task<bool> ExistsAsync(int classTypeId)
        {
            var query = "SELECT COUNT(*) FROM class_types WHERE class_type_id = @ClassTypeID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@ClassTypeID";
                    parameter.Value = classTypeId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteScalar(); // Execute the command
                    var count = Convert.ToInt32(result);
                    return Task.FromResult(count > 0);
                }
            }
        }
    }
}
