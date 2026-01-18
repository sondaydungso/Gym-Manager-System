using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly DatabaseContext _context;

        public InstructorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Instructor?> GetByIdAsync(int instructorId)
        {
            string query = "SELECT * FROM instructors WHERE instructor_id = @InstructorID";
            using (var connection = _context.CreateConnection()) // Open a connection to the database
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstructorID";
                    parameter.Value = instructorId;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var instructor = new Instructor
                            {
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                FirstName = reader["first_name"]?.ToString(),
                                LastName = reader["last_name"]?.ToString(),
                                Email = reader["email"]?.ToString(),
                                PhoneNumber = reader["phone"]?.ToString(),
                                Certifications = reader["certifications"]?.ToString(),
                                Specializations = reader["specializations"]?.ToString(),
                                HireDate = Convert.ToDateTime(reader["hire_date"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            return Task.FromResult<Instructor?>(instructor); //Static method by .NET
                        }
                    }
                }
            }

            return Task.FromResult<Instructor?>(null);
        }

        public Task<IEnumerable<Instructor>> GetAllAsync()
        {
            var query = "SELECT * FROM instructors";
            var instructors = new List<Instructor>();
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
                            var instructor = new Instructor
                            {
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                FirstName = reader["first_name"]?.ToString(),
                                LastName = reader["last_name"]?.ToString(),
                                Email = reader["email"]?.ToString(),
                                PhoneNumber = reader["phone"]?.ToString(),
                                Certifications = reader["certifications"]?.ToString(),
                                Specializations = reader["specializations"]?.ToString(),
                                HireDate = Convert.ToDateTime(reader["hire_date"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                Status = reader["status"]?.ToString()
                            };
                            instructors.Add(instructor);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Instructor>>(instructors); //return a list of instructor
        }

        public Task<IEnumerable<Instructor>> GetActiveInstructorsAsync()
        {
            var query = "SELECT * FROM instructors WHERE status = 'active'";
            var instructors = new List<Instructor>();
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
                            var instructor = new Instructor
                            {
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                FirstName = reader["first_name"]?.ToString(),
                                LastName = reader["last_name"]?.ToString(),
                                Email = reader["email"]?.ToString(),
                                PhoneNumber = reader["phone"]?.ToString(),
                                Certifications = reader["certifications"]?.ToString(),
                                Specializations = reader["specializations"]?.ToString(),
                                HireDate = Convert.ToDateTime(reader["hire_date"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            instructors.Add(instructor);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Instructor>>(instructors); //return a list of instructor
        }

        public Task<int> CreateAsync(Instructor instructor)
        {
            var query = "INSERT INTO instructors (first_name, last_name, email, phone, certifications, specializations, hire_date, status, created_at) " +
                        "VALUES (@FirstName, @LastName, @Email, @Phone, @Certifications, @Specializations, @HireDate, @Status, @CreatedAt);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@FirstName", instructor.FirstName ?? (object)DBNull.Value },
                        { "@LastName", instructor.LastName ?? (object)DBNull.Value },
                        { "@Email", instructor.Email ?? (object)DBNull.Value },
                        { "@Phone", instructor.PhoneNumber ?? (object)DBNull.Value },
                        { "@Certifications", instructor.Certifications ?? (object)DBNull.Value },
                        { "@Specializations", instructor.Specializations ?? (object)DBNull.Value },
                        { "@HireDate", instructor.HireDate },
                        { "@Status", "active" },
                        { "@CreatedAt", instructor.CreatedAt }
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

        public Task<bool> UpdateAsync(Instructor instructor)
        {
            var query = "UPDATE instructors SET first_name = @FirstName, last_name = @LastName, " +
                        "email = @Email, phone = @Phone, certifications = @Certifications, " +
                        "specializations = @Specializations, hire_date = @HireDate " +
                        "WHERE instructor_id = @InstructorID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@FirstName", instructor.FirstName ?? (object)DBNull.Value },
                        { "@LastName", instructor.LastName ?? (object)DBNull.Value },
                        { "@Email", instructor.Email ?? (object)DBNull.Value },
                        { "@Phone", instructor.PhoneNumber ?? (object)DBNull.Value },
                        { "@Certifications", instructor.Certifications ?? (object)DBNull.Value },
                        { "@Specializations", instructor.Specializations ?? (object)DBNull.Value },
                        { "@HireDate", instructor.HireDate },
                        { "@InstructorID", instructor.InstructorId }
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

        public Task<bool> DeleteAsync(int instructorId)
        {
            var query = "DELETE FROM instructors WHERE instructor_id = @InstructorID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstructorID";
                    parameter.Value = instructorId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was deleted
                }
            }
        }

        public Task<bool> ExistsAsync(int instructorId)
        {
            var query = "SELECT COUNT(*) FROM instructors WHERE instructor_id = @InstructorID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstructorID";
                    parameter.Value = instructorId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteScalar(); // Execute the command
                    var count = Convert.ToInt32(result);
                    return Task.FromResult(count > 0);
                }
            }
        }
    }
}
