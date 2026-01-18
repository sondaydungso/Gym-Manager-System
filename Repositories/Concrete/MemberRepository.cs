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
            string query = "SELECT * FROM members WHERE member_id = @MemberID";
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
                                MemberId = reader["member_id"] != DBNull.Value ? Convert.ToInt32(reader["member_id"]) : 0,
                                FirstName = reader["first_name"] != DBNull.Value ? reader["first_name"].ToString() : string.Empty,
                                LastName = reader["last_name"] != DBNull.Value ? reader["last_name"].ToString() : string.Empty,
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : string.Empty,
                                PhoneNumber = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : string.Empty,
                                DateOfBirth = reader["date_of_birth"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_birth"]) : default,
                                JoinDate = reader["join_date"] != DBNull.Value ? Convert.ToDateTime(reader["join_date"]) : default,
                                Emergency_contact_name = reader["emergency_contact_name"] != DBNull.Value ? reader["emergency_contact_name"].ToString() : string.Empty,
                                Emergency_contact_phone = reader["emergency_contact_phone"] != DBNull.Value ? reader["emergency_contact_phone"].ToString() : string.Empty,
                                Medical_notes = reader["medical_notes"] != DBNull.Value ? reader["medical_notes"].ToString() : string.Empty,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
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
            var query = "SELECT * FROM members WHERE email = @Email";
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
                                MemberId = reader["member_id"] != DBNull.Value ? Convert.ToInt32(reader["member_id"]) : 0,
                                FirstName = reader["first_name"] != DBNull.Value ? reader["first_name"].ToString() : string.Empty,
                                LastName = reader["last_name"] != DBNull.Value ? reader["last_name"].ToString() : string.Empty,
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : string.Empty,
                                PhoneNumber = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : string.Empty,
                                DateOfBirth = reader["date_of_birth"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_birth"]) : default,
                                JoinDate = reader["join_date"] != DBNull.Value ? Convert.ToDateTime(reader["join_date"]) : default,
                                Emergency_contact_name = reader["emergency_contact_name"] != DBNull.Value ? reader["emergency_contact_name"].ToString() : string.Empty,
                                Emergency_contact_phone = reader["emergency_contact_phone"] != DBNull.Value ? reader["emergency_contact_phone"].ToString() : string.Empty,
                                Medical_notes = reader["medical_notes"] != DBNull.Value ? reader["medical_notes"].ToString() : string.Empty,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
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
            var query = "SELECT * FROM members";
            var members = new List<Member>();
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
                            var member = new Member
                            {
                                MemberId = reader["member_id"] != DBNull.Value ? Convert.ToInt32(reader["member_id"]) : 0,
                                FirstName = reader["first_name"] != DBNull.Value ? reader["first_name"].ToString() : string.Empty,
                                LastName = reader["last_name"] != DBNull.Value ? reader["last_name"].ToString() : string.Empty,
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : string.Empty,
                                PhoneNumber = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : string.Empty,
                                DateOfBirth = reader["date_of_birth"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_birth"]) : default,
                                JoinDate = reader["join_date"] != DBNull.Value ? Convert.ToDateTime(reader["join_date"]) : default,
                                Emergency_contact_name = reader["emergency_contact_name"] != DBNull.Value ? reader["emergency_contact_name"].ToString() : string.Empty,
                                Emergency_contact_phone = reader["emergency_contact_phone"] != DBNull.Value ? reader["emergency_contact_phone"].ToString() : string.Empty,
                                Medical_notes = reader["medical_notes"] != DBNull.Value ? reader["medical_notes"].ToString() : string.Empty,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
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
            var query = "SELECT * FROM members WHERE status = @Status";
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
                        while (reader.Read())
                        {
                            var member = new Member
                            {
                                MemberId = reader["member_id"] != DBNull.Value ? Convert.ToInt32(reader["member_id"]) : 0,
                                FirstName = reader["first_name"] != DBNull.Value ? reader["first_name"].ToString() : string.Empty,
                                LastName = reader["last_name"] != DBNull.Value ? reader["last_name"].ToString() : string.Empty,
                                Email = reader["email"] != DBNull.Value ? reader["email"].ToString() : string.Empty,
                                PhoneNumber = reader["phone"] != DBNull.Value ? reader["phone"].ToString() : string.Empty,
                                DateOfBirth = reader["date_of_birth"] != DBNull.Value ? Convert.ToDateTime(reader["date_of_birth"]) : default,
                                JoinDate = reader["join_date"] != DBNull.Value ? Convert.ToDateTime(reader["join_date"]) : default,
                                Emergency_contact_name = reader["emergency_contact_name"] != DBNull.Value ? reader["emergency_contact_name"].ToString() : string.Empty,
                                Emergency_contact_phone = reader["emergency_contact_phone"] != DBNull.Value ? reader["emergency_contact_phone"].ToString() : string.Empty,
                                Medical_notes = reader["medical_notes"] != DBNull.Value ? reader["medical_notes"].ToString() : string.Empty,
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
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
            var query = "INSERT INTO members (first_name, last_name, email, phone, date_of_birth, join_date, emergency_contact_name, emergency_contact_phone, medical_notes) " +
                        "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @DateOfBirth, @JoinDate, @Emergency_contact_name, @Emergency_contact_phone, @Medical_notes);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Bind parameters directly
                    var firstNameParam = command.CreateParameter();
                    firstNameParam.ParameterName = "@FirstName";
                    firstNameParam.Value = member.FirstName ?? (object)DBNull.Value;
                    command.Parameters.Add(firstNameParam);

                    var lastNameParam = command.CreateParameter();
                    lastNameParam.ParameterName = "@LastName";
                    lastNameParam.Value = member.LastName ?? (object)DBNull.Value;
                    command.Parameters.Add(lastNameParam);

                    var emailParam = command.CreateParameter();
                    emailParam.ParameterName = "@Email";
                    emailParam.Value = member.Email ?? (object)DBNull.Value;
                    command.Parameters.Add(emailParam);

                    var phoneParam = command.CreateParameter();
                    phoneParam.ParameterName = "@PhoneNumber";
                    phoneParam.Value = member.PhoneNumber ?? (object)DBNull.Value;
                    command.Parameters.Add(phoneParam);

                    var dateOfBirthParam = command.CreateParameter();
                    dateOfBirthParam.ParameterName = "@DateOfBirth";
                    dateOfBirthParam.Value = member.DateOfBirth;
                    command.Parameters.Add(dateOfBirthParam);

                    var joinDateParam = command.CreateParameter();
                    joinDateParam.ParameterName = "@JoinDate";
                    joinDateParam.Value = member.JoinDate;
                    command.Parameters.Add(joinDateParam);

                    var emergencyContactNameParam = command.CreateParameter();
                    emergencyContactNameParam.ParameterName = "@Emergency_contact_name";
                    emergencyContactNameParam.Value = member.Emergency_contact_name ?? (object)DBNull.Value;
                    command.Parameters.Add(emergencyContactNameParam);

                    var emergencyContactPhoneParam = command.CreateParameter();
                    emergencyContactPhoneParam.ParameterName = "@Emergency_contact_phone";
                    emergencyContactPhoneParam.Value = member.Emergency_contact_phone ?? (object)DBNull.Value;
                    command.Parameters.Add(emergencyContactPhoneParam);

                    var medicalNotesParam = command.CreateParameter();
                    medicalNotesParam.ParameterName = "@Medical_notes";
                    medicalNotesParam.Value = member.Medical_notes ?? (object)DBNull.Value;
                    command.Parameters.Add(medicalNotesParam);

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult<int>(result);
                }
            }
        }

        public Task<bool> UpdateAsync(Member member)
        {
            var query = "UPDATE members SET first_name = @FirstName, last_name = @LastName, email = @Email, phone = @PhoneNumber, " +
                        "date_of_birth = @DateOfBirth, join_date = @JoinDate, emergency_contact_name = @Emergency_contact_name, " +
                        "emergency_contact_phone = @Emergency_contact_phone, medical_notes = @Medical_notes, status = @Status " +
                        "WHERE member_id = @MemberID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Bind parameters directly
                    var firstNameParam = command.CreateParameter();
                    firstNameParam.ParameterName = "@FirstName";
                    firstNameParam.Value = member.FirstName ?? (object)DBNull.Value;
                    command.Parameters.Add(firstNameParam);

                    var lastNameParam = command.CreateParameter();
                    lastNameParam.ParameterName = "@LastName";
                    lastNameParam.Value = member.LastName ?? (object)DBNull.Value;
                    command.Parameters.Add(lastNameParam);

                    var emailParam = command.CreateParameter();
                    emailParam.ParameterName = "@Email";
                    emailParam.Value = member.Email ?? (object)DBNull.Value;
                    command.Parameters.Add(emailParam);

                    var phoneParam = command.CreateParameter();
                    phoneParam.ParameterName = "@PhoneNumber";
                    phoneParam.Value = member.PhoneNumber ?? (object)DBNull.Value;
                    command.Parameters.Add(phoneParam);

                    var dateOfBirthParam = command.CreateParameter();
                    dateOfBirthParam.ParameterName = "@DateOfBirth";
                    dateOfBirthParam.Value = member.DateOfBirth;
                    command.Parameters.Add(dateOfBirthParam);

                    var joinDateParam = command.CreateParameter();
                    joinDateParam.ParameterName = "@JoinDate";
                    joinDateParam.Value = member.JoinDate;
                    command.Parameters.Add(joinDateParam);

                    var emergencyContactNameParam = command.CreateParameter();
                    emergencyContactNameParam.ParameterName = "@Emergency_contact_name";
                    emergencyContactNameParam.Value = member.Emergency_contact_name ?? (object)DBNull.Value;
                    command.Parameters.Add(emergencyContactNameParam);

                    var emergencyContactPhoneParam = command.CreateParameter();
                    emergencyContactPhoneParam.ParameterName = "@Emergency_contact_phone";
                    emergencyContactPhoneParam.Value = member.Emergency_contact_phone ?? (object)DBNull.Value;
                    command.Parameters.Add(emergencyContactPhoneParam);

                    var medicalNotesParam = command.CreateParameter();
                    medicalNotesParam.ParameterName = "@Medical_notes";
                    medicalNotesParam.Value = member.Medical_notes ?? (object)DBNull.Value;
                    command.Parameters.Add(medicalNotesParam);

                    var statusParam = command.CreateParameter();
                    statusParam.ParameterName = "@Status";
                    statusParam.Value = member.Status ?? (object)DBNull.Value;
                    command.Parameters.Add(statusParam);

                    var memberIdParam = command.CreateParameter();
                    memberIdParam.ParameterName = "@MemberID";
                    memberIdParam.Value = member.MemberId;
                    command.Parameters.Add(memberIdParam);

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
            var query = $"UPDATE members SET {setClause} WHERE member_id = @MemberID";

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
