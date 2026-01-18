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
                                HireDate = reader["hire_date"] != DBNull.Value ? Convert.ToDateTime(reader["hire_date"]) : default,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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
                                HireDate = reader["hire_date"] != DBNull.Value ? Convert.ToDateTime(reader["hire_date"]) : default,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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

                    // Bind parameters directly
                    var firstNameParam = command.CreateParameter();
                    firstNameParam.ParameterName = "@FirstName";
                    firstNameParam.Value = instructor.FirstName ?? (object)DBNull.Value;
                    command.Parameters.Add(firstNameParam);

                    var lastNameParam = command.CreateParameter();
                    lastNameParam.ParameterName = "@LastName";
                    lastNameParam.Value = instructor.LastName ?? (object)DBNull.Value;
                    command.Parameters.Add(lastNameParam);

                    var emailParam = command.CreateParameter();
                    emailParam.ParameterName = "@Email";
                    emailParam.Value = instructor.Email ?? (object)DBNull.Value;
                    command.Parameters.Add(emailParam);

                    var phoneParam = command.CreateParameter();
                    phoneParam.ParameterName = "@Phone";
                    phoneParam.Value = instructor.PhoneNumber ?? (object)DBNull.Value;
                    command.Parameters.Add(phoneParam);

                    var certificationsParam = command.CreateParameter();
                    certificationsParam.ParameterName = "@Certifications";
                    certificationsParam.Value = instructor.Certifications ?? (object)DBNull.Value;
                    command.Parameters.Add(certificationsParam);

                    var specializationsParam = command.CreateParameter();
                    specializationsParam.ParameterName = "@Specializations";
                    specializationsParam.Value = instructor.Specializations ?? (object)DBNull.Value;
                    command.Parameters.Add(specializationsParam);

                    var hireDateParam = command.CreateParameter();
                    hireDateParam.ParameterName = "@HireDate";
                    hireDateParam.Value = instructor.HireDate;
                    command.Parameters.Add(hireDateParam);

                    var statusParam = command.CreateParameter();
                    statusParam.ParameterName = "@Status";
                    statusParam.Value = "active";
                    command.Parameters.Add(statusParam);

                    var createdAtParam = command.CreateParameter();
                    createdAtParam.ParameterName = "@CreatedAt";
                    createdAtParam.Value = instructor.CreatedAt;
                    command.Parameters.Add(createdAtParam);

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

                    // Bind parameters directly
                    var firstNameParam = command.CreateParameter();
                    firstNameParam.ParameterName = "@FirstName";
                    firstNameParam.Value = instructor.FirstName ?? (object)DBNull.Value;
                    command.Parameters.Add(firstNameParam);

                    var lastNameParam = command.CreateParameter();
                    lastNameParam.ParameterName = "@LastName";
                    lastNameParam.Value = instructor.LastName ?? (object)DBNull.Value;
                    command.Parameters.Add(lastNameParam);

                    var emailParam = command.CreateParameter();
                    emailParam.ParameterName = "@Email";
                    emailParam.Value = instructor.Email ?? (object)DBNull.Value;
                    command.Parameters.Add(emailParam);

                    var phoneParam = command.CreateParameter();
                    phoneParam.ParameterName = "@Phone";
                    phoneParam.Value = instructor.PhoneNumber ?? (object)DBNull.Value;
                    command.Parameters.Add(phoneParam);

                    var certificationsParam = command.CreateParameter();
                    certificationsParam.ParameterName = "@Certifications";
                    certificationsParam.Value = instructor.Certifications ?? (object)DBNull.Value;
                    command.Parameters.Add(certificationsParam);

                    var specializationsParam = command.CreateParameter();
                    specializationsParam.ParameterName = "@Specializations";
                    specializationsParam.Value = instructor.Specializations ?? (object)DBNull.Value;
                    command.Parameters.Add(specializationsParam);

                    var hireDateParam = command.CreateParameter();
                    hireDateParam.ParameterName = "@HireDate";
                    hireDateParam.Value = instructor.HireDate;
                    command.Parameters.Add(hireDateParam);

                    var instructorIdParam = command.CreateParameter();
                    instructorIdParam.ParameterName = "@InstructorID";
                    instructorIdParam.Value = instructor.InstructorId;
                    command.Parameters.Add(instructorIdParam);

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
