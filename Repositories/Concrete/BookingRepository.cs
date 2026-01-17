using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DatabaseContext _context;

        public BookingRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Booking?> GetByIdAsync(int bookingId)
        {
            string query = "SELECT * FROM bookings WHERE booking_id = @BookingID";
            using (var connection = _context.CreateConnection()) // Open a connection to the database
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
                            var booking = new Booking
                            {
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                InstanceId = Convert.ToInt32(reader["instance_id"]),
                                BookingDate = Convert.ToDateTime(reader["booking_time"]),
                                CancelledAt = reader["cancelled_at"] != DBNull.Value ? Convert.ToDateTime(reader["cancelled_at"]) : default,
                                CancelReason = reader["cancellation_reason"]?.ToString()
                            };
                            return Task.FromResult<Booking?>(booking); //Static method by .NET
                        }
                    }
                }
            }

            return Task.FromResult<Booking?>(null);
        }

        public Task<IEnumerable<Booking>> GetByMemberIdAsync(int memberId)
        {
            var query = "SELECT * FROM bookings WHERE member_id = @MemberID";
            var bookings = new List<Booking>();
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
                            var booking = new Booking
                            {
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                InstanceId = Convert.ToInt32(reader["instance_id"]),
                                BookingDate = Convert.ToDateTime(reader["booking_time"]),
                                CancelledAt = reader["cancelled_at"] != DBNull.Value ? Convert.ToDateTime(reader["cancelled_at"]) : default,
                                CancelReason = reader["cancellation_reason"]?.ToString()
                            };
                            bookings.Add(booking);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Booking>>(bookings); //return a list of booking
        }

        public Task<IEnumerable<Booking>> GetByInstanceIdAsync(int instanceId)
        {
            var query = "SELECT * FROM bookings WHERE instance_id = @InstanceID";
            var bookings = new List<Booking>();
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
                            var booking = new Booking
                            {
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                InstanceId = Convert.ToInt32(reader["instance_id"]),
                                BookingDate = Convert.ToDateTime(reader["booking_time"]),
                                CancelledAt = reader["cancelled_at"] != DBNull.Value ? Convert.ToDateTime(reader["cancelled_at"]) : default,
                                CancelReason = reader["cancellation_reason"]?.ToString()
                            };
                            bookings.Add(booking);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Booking>>(bookings); //return a list of booking
        }

        public Task<Booking?> GetMemberBookingForInstanceAsync(int memberId, int instanceId)
        {
            var query = "SELECT * FROM bookings WHERE member_id = @MemberID AND instance_id = @InstanceID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var memberParam = command.CreateParameter();
                    memberParam.ParameterName = "@MemberID";
                    memberParam.Value = memberId;
                    command.Parameters.Add(memberParam);
                    var instanceParam = command.CreateParameter();
                    instanceParam.ParameterName = "@InstanceID";
                    instanceParam.Value = instanceId;
                    command.Parameters.Add(instanceParam);

                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        if (reader.Read())
                        {
                            var booking = new Booking
                            {
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                InstanceId = Convert.ToInt32(reader["instance_id"]),
                                BookingDate = Convert.ToDateTime(reader["booking_time"]),
                                CancelledAt = reader["cancelled_at"] != DBNull.Value ? Convert.ToDateTime(reader["cancelled_at"]) : default,
                                CancelReason = reader["cancellation_reason"]?.ToString()
                            };
                            return Task.FromResult<Booking?>(booking); //Static method by .NET
                        }
                    }
                }
            }
            return Task.FromResult<Booking?>(null);
        }

        public Task<IEnumerable<Booking>> GetUpcomingBookingsByMemberAsync(int memberId)
        {
            var query = "SELECT b.* FROM bookings b INNER JOIN class_instances ci ON b.instance_id = ci.instance_id WHERE b.member_id = @MemberID AND ci.class_date >= CURDATE() AND b.status != 'cancelled'";
            var bookings = new List<Booking>();
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
                            var booking = new Booking
                            {
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                InstanceId = Convert.ToInt32(reader["instance_id"]),
                                BookingDate = Convert.ToDateTime(reader["booking_time"]),
                                CancelledAt = reader["cancelled_at"] != DBNull.Value ? Convert.ToDateTime(reader["cancelled_at"]) : default,
                                CancelReason = reader["cancellation_reason"]?.ToString()
                            };
                            bookings.Add(booking);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Booking>>(bookings); //return a list of booking
        }

        public Task<IEnumerable<Booking>> GetPastBookingsByMemberAsync(int memberId)
        {
            var query = "SELECT b.* FROM bookings b INNER JOIN class_instances ci ON b.instance_id = ci.instance_id WHERE b.member_id = @MemberID AND ci.class_date < CURDATE()";
            var bookings = new List<Booking>();
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
                            var booking = new Booking
                            {
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                InstanceId = Convert.ToInt32(reader["instance_id"]),
                                BookingDate = Convert.ToDateTime(reader["booking_time"]),
                                CancelledAt = reader["cancelled_at"] != DBNull.Value ? Convert.ToDateTime(reader["cancelled_at"]) : default,
                                CancelReason = reader["cancellation_reason"]?.ToString()
                            };
                            bookings.Add(booking);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Booking>>(bookings); //return a list of booking
        }

        public Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date)
        {
            var query = "SELECT b.* FROM bookings b INNER JOIN class_instances ci ON b.instance_id = ci.instance_id WHERE DATE(ci.class_date) = @Date";
            var bookings = new List<Booking>();
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
                            var booking = new Booking
                            {
                                BookingId = Convert.ToInt32(reader["booking_id"]),
                                MemberId = Convert.ToInt32(reader["member_id"]),
                                InstanceId = Convert.ToInt32(reader["instance_id"]),
                                BookingDate = Convert.ToDateTime(reader["booking_time"]),
                                CancelledAt = reader["cancelled_at"] != DBNull.Value ? Convert.ToDateTime(reader["cancelled_at"]) : default,
                                CancelReason = reader["cancellation_reason"]?.ToString()
                            };
                            bookings.Add(booking);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Booking>>(bookings); //return a list of booking
        }

        public Task<int> CreateAsync(Booking booking)
        {
            var query = "INSERT INTO bookings (member_id, instance_id, booking_time, status, cancelled_at, cancellation_reason) " +
                        "VALUES (@MemberID, @InstanceID, @BookingTime, @Status, @CancelledAt, @CancellationReason);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@MemberID", booking.MemberId },
                        { "@InstanceID", booking.InstanceId },
                        { "@BookingTime", booking.BookingDate },
                        { "@Status", "confirmed" },
                        { "@CancelledAt", booking.CancelledAt == default ? (object)DBNull.Value : booking.CancelledAt },
                        { "@CancellationReason", booking.CancelReason ?? (object)DBNull.Value }
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

        public Task<bool> UpdateAsync(Booking booking)
        {
            var query = "UPDATE bookings SET member_id = @MemberID, instance_id = @InstanceID, " +
                        "booking_time = @BookingTime, status = @Status, cancelled_at = @CancelledAt, " +
                        "cancellation_reason = @CancellationReason " +
                        "WHERE booking_id = @BookingID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@MemberID", booking.MemberId },
                        { "@InstanceID", booking.InstanceId },
                        { "@BookingTime", booking.BookingDate },
                        { "@Status", "confirmed" },
                        { "@CancelledAt", booking.CancelledAt == default ? (object)DBNull.Value : booking.CancelledAt },
                        { "@CancellationReason", booking.CancelReason ?? (object)DBNull.Value },
                        { "@BookingID", booking.BookingId }
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

        public Task<bool> CancelBookingAsync(int bookingId, string reason)
        {
            var query = "UPDATE bookings SET status = 'cancelled', cancelled_at = @CancelledAt, cancellation_reason = @CancellationReason " +
                        "WHERE booking_id = @BookingID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@CancelledAt", DateTime.Now },
                        { "@CancellationReason", reason ?? (object)DBNull.Value },
                        { "@BookingID", bookingId }
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

        public Task<bool> DeleteAsync(int bookingId)
        {
            var query = "DELETE FROM bookings WHERE booking_id = @BookingID";

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

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was deleted
                }
            }
        }

        public Task<bool> MemberHasBookingForInstanceAsync(int memberId, int instanceId)
        {
            var query = "SELECT COUNT(*) FROM bookings WHERE member_id = @MemberID AND instance_id = @InstanceID AND status != 'cancelled'";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var memberParam = command.CreateParameter();
                    memberParam.ParameterName = "@MemberID";
                    memberParam.Value = memberId;
                    command.Parameters.Add(memberParam);
                    var instanceParam = command.CreateParameter();
                    instanceParam.ParameterName = "@InstanceID";
                    instanceParam.Value = instanceId;
                    command.Parameters.Add(instanceParam);

                    var result = command.ExecuteScalar(); // Execute the command
                    var count = Convert.ToInt32(result);
                    return Task.FromResult(count > 0);
                }
            }
        }

        public Task<int> GetBookingCountForInstanceAsync(int instanceId)
        {
            var query = "SELECT COUNT(*) FROM bookings WHERE instance_id = @InstanceID AND status != 'cancelled'";
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
