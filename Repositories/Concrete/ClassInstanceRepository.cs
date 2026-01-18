using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class ClassInstanceRepository : IClassInstanceRepository
    {
        private readonly DatabaseContext _context;

        public ClassInstanceRepository(DatabaseContext context)
        {
            _context = context;
        }

        
        public Task<ClassInstance?> GetByIdAsync(int instanceId)
        {
            string query = "SELECT * FROM class_instances WHERE instance_id = @InstanceID";
            using (var connection = _context.CreateConnection()) // Open a connection to the database
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
                        if (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassDate = Convert.ToDateTime(reader["class_date"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                CurrentBookings = Convert.ToInt32(reader["current_bookings"]),
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"]?.ToString()
                            };
                            return Task.FromResult<ClassInstance?>(instance); //Static method by .NET
                        }
                    }
                }
            }

            return Task.FromResult<ClassInstance?>(null);
        }

        public Task<IEnumerable<ClassInstance>> GetAllAsync()
        {
            var query = "SELECT * FROM class_instances";
            var instances = new List<ClassInstance>();
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
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassDate = Convert.ToDateTime(reader["class_date"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                CurrentBookings = Convert.ToInt32(reader["current_bookings"]),
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"]?.ToString()
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances); //return a list of instance
        }

        public Task<IEnumerable<ClassInstance>> GetByDateAsync(DateTime date)
        {
            var query = "SELECT * FROM class_instances WHERE DATE(class_date) = @Date";
            var instances = new List<ClassInstance>();
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
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassDate = Convert.ToDateTime(reader["class_date"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                CurrentBookings = Convert.ToInt32(reader["current_bookings"]),
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"]?.ToString()
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances); //return a list of instance
        }

        public Task<IEnumerable<ClassInstance>> GetUpcomingInstancesAsync(int daysAhead)
        {
            var query = "SELECT * FROM class_instances WHERE class_date >= CURDATE() AND class_date <= DATE_ADD(CURDATE(), INTERVAL @DaysAhead DAY) AND status = 'scheduled'";
            var instances = new List<ClassInstance>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@DaysAhead";
                    parameter.Value = daysAhead;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassDate = Convert.ToDateTime(reader["class_date"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                CurrentBookings = Convert.ToInt32(reader["current_bookings"]),
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"]?.ToString()
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances); //return a list of instance
        }

        public Task<IEnumerable<ClassInstance>> GetAvailableInstancesAsync(DateTime fromDate, DateTime toDate)
        {
            var query = "SELECT * FROM class_instances WHERE class_date >= @FromDate AND class_date <= @ToDate AND status = 'scheduled' AND current_bookings < capacity";
            var instances = new List<ClassInstance>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var fromParam = command.CreateParameter();
                    fromParam.ParameterName = "@FromDate";
                    fromParam.Value = fromDate.Date;
                    command.Parameters.Add(fromParam);
                    var toParam = command.CreateParameter();
                    toParam.ParameterName = "@ToDate";
                    toParam.Value = toDate.Date;
                    command.Parameters.Add(toParam);
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassDate = Convert.ToDateTime(reader["class_date"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                CurrentBookings = Convert.ToInt32(reader["current_bookings"]),
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"]?.ToString()
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances); //return a list of instance
        }

        public Task<IEnumerable<ClassInstance>> GetInstancesByScheduleAsync(int scheduleId)
        {
            var query = "SELECT * FROM class_instances WHERE schedule_id = @ScheduleID";
            var instances = new List<ClassInstance>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@ScheduleID";
                    parameter.Value = scheduleId;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassDate = Convert.ToDateTime(reader["class_date"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                CurrentBookings = Convert.ToInt32(reader["current_bookings"]),
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"]?.ToString()
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances); //return a list of instance
        }

        public Task<IEnumerable<ClassInstance>> GetInstancesByInstructorAsync(int instructorId, DateTime? fromDate, DateTime? toDate)
        {
            var query = "SELECT * FROM class_instances WHERE instructor_id = @InstructorID";
            if (fromDate.HasValue)
            {
                query += " AND class_date >= @FromDate";
            }
            if (toDate.HasValue)
            {
                query += " AND class_date <= @ToDate";
            }
            var instances = new List<ClassInstance>();
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
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassDate = Convert.ToDateTime(reader["class_date"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                CurrentBookings = Convert.ToInt32(reader["current_bookings"]),
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"]?.ToString()
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances); //return a list of instance
        }

        public Task<int> CreateAsync(ClassInstance instance)
        {
            var query = "INSERT INTO class_instances (schedule_id, class_date, start_time, end_time, instructor_id, room_id, capacity, current_bookings, status, cancellation_reason, created_at) " +
                        "VALUES (@ScheduleID, @ClassDate, @StartTime, @EndTime, @InstructorID, @RoomID, @Capacity, @CurrentBookings, @Status, @CancellationReason, @CreatedAt);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@ScheduleID", instance.ClassScheduleId },
                        { "@ClassDate", instance.ClassDate },
                        { "@StartTime", instance.StartTime.ToTimeSpan() },
                        { "@EndTime", instance.EndTime.ToTimeSpan() },
                        { "@InstructorID", instance.InstructorId },
                        { "@RoomID", instance.RoomId },
                        { "@Capacity", instance.Capacity },
                        { "@CurrentBookings", instance.CurrentBookings },
                        { "@Status", instance.Status },
                        { "@CancellationReason", instance.CancelationReason ?? (object)DBNull.Value },
                        { "@CreatedAt", instance.CreatedAt }
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

        public Task<bool> UpdateAsync(ClassInstance instance)
        {
            var query = "UPDATE class_instances SET schedule_id = @ScheduleID, class_date = @ClassDate, " +
                        "start_time = @StartTime, end_time = @EndTime, instructor_id = @InstructorID, " +
                        "room_id = @RoomID, capacity = @Capacity, current_bookings = @CurrentBookings, " +
                        "status = @Status, cancellation_reason = @CancellationReason " +
                        "WHERE instance_id = @InstanceID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@ScheduleID", instance.ClassScheduleId },
                        { "@ClassDate", instance.ClassDate },
                        { "@StartTime", instance.StartTime.ToTimeSpan() },
                        { "@EndTime", instance.EndTime.ToTimeSpan() },
                        { "@InstructorID", instance.InstructorId },
                        { "@RoomID", instance.RoomId },
                        { "@Capacity", instance.Capacity },
                        { "@CurrentBookings", instance.CurrentBookings },
                        { "@Status", instance.Status },
                        { "@CancellationReason", instance.CancelationReason ?? (object)DBNull.Value },
                        { "@InstanceID", instance.ClassInstanceId }
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

        public Task<bool> IncrementBookingsAsync(int instanceId)
        {
            var query = "UPDATE class_instances SET current_bookings = current_bookings + 1 WHERE instance_id = @InstanceID AND current_bookings < capacity";

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

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was updated
                }
            }
        }

        public Task<bool> DecrementBookingsAsync(int instanceId)
        {
            var query = "UPDATE class_instances SET current_bookings = current_bookings - 1 WHERE instance_id = @InstanceID AND current_bookings > 0";

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

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was updated
                }
            }
        }

        public Task<bool> DeleteAsync(int instanceId)
        {
            var query = "DELETE FROM class_instances WHERE instance_id = @InstanceID";

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

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was deleted
                }
            }
        }

        public Task<bool> IsClassFullAsync(int instanceId)
        {
            var query = "SELECT current_bookings >= capacity FROM class_instances WHERE instance_id = @InstanceID";
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
                    return Task.FromResult(result != null && Convert.ToBoolean(result));
                }
            }
        }
    }
}
