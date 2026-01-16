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
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Member member)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
