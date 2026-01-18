using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DatabaseContext _context;

        public MemberRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Member?> GetByIdAsync(int memberId)
        {
            string query = "SELECT * FROM Members WHERE MemberID = @MemberID";
            using (var connection = _context.CreateConnection()) // Open a connection to the database
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
                            var member = new Member
                            {
                                FirstName = reader["FirstName"]?.ToString(),
                                LastName = reader["LastName"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                PhoneNumber = reader["PhoneNumber"]?.ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                                Emergency_contact_name = reader["Emergency_contact_name"]?.ToString(),
                                Emergency_contact_phone = reader["Emergency_contact_phone"]?.ToString(),
                                Medical_notes = reader["Medical_notes"]?.ToString()
                            };
                            return Task.FromResult<Member?>(member); //Static method by .NET
                        }
                    }
                }
            }

            return Task.FromResult<Member?>(null);

        }

        public Task<Member?> GetByEmailAsync(string email)
        {
            var query = "SELECT * FROM Members WHERE Email = @Email";
            using (var connection = _context.CreateConnection()) 
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@Email";
                    parameter.Value = email;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var member = new Member
                            {
                                FirstName = reader["FirstName"]?.ToString(),
                                LastName = reader["LastName"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                PhoneNumber = reader["PhoneNumber"]?.ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                                Emergency_contact_name = reader["Emergency_contact_name"]?.ToString(),
                                Emergency_contact_phone = reader["Emergency_contact_phone"]?.ToString(),
                                Medical_notes = reader["Medical_notes"]?.ToString()
                            };
                            return Task.FromResult<Member?>(member); //Static method by .NET
                        }
                    }
                }

            }
            return Task.FromResult<Member?>(null);
        }

        public Task<IEnumerable<Member>> GetAllAsync()
        {
            var query = "SELECT * FROM Members";
            var members = new List<Member>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var member = new Member
                            {
                                FirstName = reader["FirstName"]?.ToString(),
                                LastName = reader["LastName"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                PhoneNumber = reader["PhoneNumber"]?.ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                                Emergency_contact_name = reader["Emergency_contact_name"]?.ToString(),
                                Emergency_contact_phone = reader["Emergency_contact_phone"]?.ToString(),
                                Medical_notes = reader["Medical_notes"]?.ToString()
                            };
                            members.Add(member);
                        }
                    }
                }

            }
            return Task.FromResult<IEnumerable<Member>>(members); //return a list of member
        }

        public Task<IEnumerable<Member>> GetByStatusAsync(string status)
        {
            var query = "SELECT * FROM Members WHERE Status = @Status";
            var members = new List<Member>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@Status";
                    parameter.Value = status;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var member = new Member
                            {
                                FirstName = reader["FirstName"]?.ToString(),
                                LastName = reader["LastName"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                PhoneNumber = reader["PhoneNumber"]?.ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                                Emergency_contact_name = reader["Emergency_contact_name"]?.ToString(),
                                Emergency_contact_phone = reader["Emergency_contact_phone"]?.ToString(),
                                Medical_notes = reader["Medical_notes"]?.ToString()
                            };
                            members.Add(member);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Member>>(members); //return a list of member
        }

        public Task<int> CreateAsync(Member member)
        {
            var query = "INSERT INTO Members (FirstName, LastName, Email, PhoneNumber, DateOfBirth, JoinDate, Emergency_contact_name, Emergency_contact_phone, Medical_notes) " +
                        "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @DateOfBirth, @JoinDate, @Emergency_contact_name, @Emergency_contact_phone, @Medical_notes);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@FirstName", member.FirstName },
                        { "@LastName", member.LastName },
                        { "@Email", member.Email },
                        { "@PhoneNumber", member.PhoneNumber },
                        { "@DateOfBirth", member.DateOfBirth },
                        { "@JoinDate", member.JoinDate },
                        { "@Emergency_contact_name", member.Emergency_contact_name },
                        { "@Emergency_contact_phone", member.Emergency_contact_phone },
                        { "@Medical_notes", member.Medical_notes }
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

        public Task<bool> UpdateAsync(Member member)
        {
            var query = "UPDATE Members SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, " +
                        "DateOfBirth = @DateOfBirth, JoinDate = @JoinDate, Emergency_contact_name = @Emergency_contact_name, " +
                        "Emergency_contact_phone = @Emergency_contact_phone, Medical_notes = @Medical_notes, Status = @Status " +
                        "WHERE MemberID = @MemberID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@FirstName", member.FirstName },
                        { "@LastName", member.LastName },
                        { "@Email", member.Email },
                        { "@PhoneNumber", member.PhoneNumber },
                        { "@DateOfBirth", member.DateOfBirth },
                        { "@JoinDate", member.JoinDate },
                        { "@Emergency_contact_name", member.Emergency_contact_name },
                        { "@Emergency_contact_phone", member.Emergency_contact_phone },
                        { "@Medical_notes", member.Medical_notes },
                        { "@Status", member.Status },
                        
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

        public Task<bool> DeleteAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFieldsAsync(int memberId, Dictionary<string, object> fieldsToUpdate)
        {
            if (fieldsToUpdate == null || fieldsToUpdate.Count == 0)
                throw new ArgumentException("No fields provided to update.", nameof(fieldsToUpdate));

            var setClause = string.Join(", ", fieldsToUpdate.Keys.Select(field => $"{field} = @{field}"));
            var query = $"UPDATE Members SET {setClause} WHERE MemberID = @MemberID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query  
                {
                    command.CommandText = query;

                    // Add parameters for each field  
                    foreach (var field in fieldsToUpdate)
                    {
                        var parameter = command.CreateParameter();
                        parameter.ParameterName = $"@{field.Key}";
                        parameter.Value = field.Value;
                        command.Parameters.Add(parameter);
                    }

                    // Add the MemberID parameter  
                    var idParameter = command.CreateParameter();
                    idParameter.ParameterName = "@MemberID";
                    idParameter.Value = memberId;
                    command.Parameters.Add(idParameter);

                    var result = command.ExecuteNonQuery(); // Execute the command  
                    return Task.FromResult(result > 0); // Return true if at least one row was updated  
                }
            }
        }
    }
}
