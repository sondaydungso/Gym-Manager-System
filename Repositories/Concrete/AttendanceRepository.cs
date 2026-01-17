using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly DatabaseContext _context;

        public AttendanceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Attendance?> GetByIdAsync(int attendanceId)
        {
            string query = "SELECT * FROM attendance WHERE attendance_id = @AttendanceID";
            using (var connection = _context.CreateConnection()) // Open a connection to the database
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@AttendanceID";
                    parameter.Value = attendanceId;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var attendance = new Attendance
                            {
                                AttendanceId = Convert.ToInt32(reader["attendance_id"]),
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                CheckInTime = Convert.ToDateTime(reader["check_in_time"]),
                                Attended = Convert.ToBoolean(reader["attended"]),
                                Note = reader["notes"]?.ToString()
                            };
                            return Task.FromResult<Attendance?>(attendance); //Static method by .NET
                        }
                    }
                }
            }

            return Task.FromResult<Attendance?>(null);
        }

        public Task<Attendance?> GetByBookingIdAsync(int bookingId)
        {
            var query = "SELECT * FROM attendance WHERE booking_id = @BookingID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@BookingID";
                    parameter.Value = bookingId;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var attendance = new Attendance
                            {
                                AttendanceId = Convert.ToInt32(reader["attendance_id"]),
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                CheckInTime = Convert.ToDateTime(reader["check_in_time"]),
                                Attended = Convert.ToBoolean(reader["attended"]),
                                Note = reader["notes"]?.ToString()
                            };
                            return Task.FromResult<Attendance?>(attendance); //Static method by .NET
                        }
                    }
                }
            }
            return Task.FromResult<Attendance?>(null);
        }

        public Task<IEnumerable<Attendance>> GetByDateAsync(DateTime date)
        {
            var query = "SELECT * FROM attendance WHERE DATE(check_in_time) = @Date";
            var attendances = new List<Attendance>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@Date";
                    parameter.Value = date.Date;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var attendance = new Attendance
                            {
                                AttendanceId = Convert.ToInt32(reader["attendance_id"]),
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                CheckInTime = Convert.ToDateTime(reader["check_in_time"]),
                                Attended = Convert.ToBoolean(reader["attended"]),
                                Note = reader["notes"]?.ToString()
                            };
                            attendances.Add(attendance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Attendance>>(attendances); //return a list of attendance
        }

        public Task<IEnumerable<Attendance>> GetByMemberIdAsync(int memberId, DateTime? fromDate, DateTime? toDate)
        {
            var query = "SELECT a.* FROM attendance a INNER JOIN bookings b ON a.booking_id = b.booking_id WHERE b.member_id = @MemberID";
            if (fromDate.HasValue)
            {
                query += " AND DATE(a.check_in_time) >= @FromDate";
            }
            if (toDate.HasValue)
            {
                query += " AND DATE(a.check_in_time) <= @ToDate";
            }
            var attendances = new List<Attendance>();
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
                    if (fromDate.HasValue)
                    {
                        var fromParam = command.CreateParameter();
                        fromParam.ParameterName = "@FromDate";
                        fromParam.Value = fromDate.Value.Date;
                        command.Parameters.Add(fromParam);
                    }
                    if (toDate.HasValue)
                    {
                        var toParam = command.CreateParameter();
                        toParam.ParameterName = "@ToDate";
                        toParam.Value = toDate.Value.Date;
                        command.Parameters.Add(toParam);
                    }
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var attendance = new Attendance
                            {
                                AttendanceId = Convert.ToInt32(reader["attendance_id"]),
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                CheckInTime = Convert.ToDateTime(reader["check_in_time"]),
                                Attended = Convert.ToBoolean(reader["attended"]),
                                Note = reader["notes"]?.ToString()
                            };
                            attendances.Add(attendance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Attendance>>(attendances); //return a list of attendance
        }

        public Task<IEnumerable<Attendance>> GetByClassInstanceAsync(int instanceId)
        {
            var query = "SELECT a.* FROM attendance a INNER JOIN bookings b ON a.booking_id = b.booking_id WHERE b.instance_id = @InstanceID";
            var attendances = new List<Attendance>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstanceID";
                    parameter.Value = instanceId;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var attendance = new Attendance
                            {
                                AttendanceId = Convert.ToInt32(reader["attendance_id"]),
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                CheckInTime = Convert.ToDateTime(reader["check_in_time"]),
                                Attended = Convert.ToBoolean(reader["attended"]),
                                Note = reader["notes"]?.ToString()
                            };
                            attendances.Add(attendance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Attendance>>(attendances); //return a list of attendance
        }

        public Task<int> CreateAsync(Attendance attendance)
        {
            var query = "INSERT INTO attendance (booking_id, check_in_time, attended, notes) " +
                        "VALUES (@BookingID, @CheckInTime, @Attended, @Note);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@BookingID", attendance.BookingId },
                        { "@CheckInTime", attendance.CheckInTime },
                        { "@Attended", attendance.Attended },
                        { "@Note", attendance.Note ?? (object)DBNull.Value }
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

        public Task<bool> UpdateAsync(Attendance attendance)
        {
            var query = "UPDATE attendance SET booking_id = @BookingID, check_in_time = @CheckInTime, " +
                        "attended = @Attended, notes = @Note " +
                        "WHERE attendance_id = @AttendanceID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@BookingID", attendance.BookingId },
                        { "@CheckInTime", attendance.CheckInTime },
                        { "@Attended", attendance.Attended },
                        { "@Note", attendance.Note ?? (object)DBNull.Value },
                        { "@AttendanceID", attendance.AttendanceId }
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

        public Task<bool> DeleteAsync(int attendanceId)
        {
            var query = "DELETE FROM attendance WHERE attendance_id = @AttendanceID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@AttendanceID";
                    parameter.Value = attendanceId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was deleted
                }
            }
        }

        public Task<bool> HasAttendanceRecordAsync(int bookingId)
        {
            var query = "SELECT COUNT(*) FROM attendance WHERE booking_id = @BookingID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@BookingID";
                    parameter.Value = bookingId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteScalar(); // Execute the command
                    var count = Convert.ToInt32(result);
                    return Task.FromResult(count > 0);
                }
            }
        }

        public Task<int> GetAttendanceCountForInstanceAsync(int instanceId)
        {
            var query = "SELECT COUNT(*) FROM attendance a INNER JOIN bookings b ON a.booking_id = b.booking_id WHERE b.instance_id = @InstanceID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstanceID";
                    parameter.Value = instanceId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteScalar(); // Execute the command
                    return Task.FromResult(Convert.ToInt32(result));
                }
            }
        }
    }
}
