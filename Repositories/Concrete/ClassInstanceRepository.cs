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
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstanceID";
                    parameter.Value = instanceId;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = reader["schedule_id"] != DBNull.Value ? Convert.ToInt32(reader["schedule_id"]) : 0,
                                ClassDate = reader["class_date"] != DBNull.Value ? Convert.ToDateTime(reader["class_date"]) : default,
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = reader["capacity"] != DBNull.Value ? Convert.ToInt32(reader["capacity"]) : 0,
                                CurrentBookings = reader["current_bookings"] != DBNull.Value ? Convert.ToInt32(reader["current_bookings"]) : 0,
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                            };
                            return Task.FromResult<ClassInstance?>(instance);
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
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = reader["schedule_id"] != DBNull.Value ? Convert.ToInt32(reader["schedule_id"]) : 0,
                                ClassDate = reader["class_date"] != DBNull.Value ? Convert.ToDateTime(reader["class_date"]) : default,
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = reader["capacity"] != DBNull.Value ? Convert.ToInt32(reader["capacity"]) : 0,
                                CurrentBookings = reader["current_bookings"] != DBNull.Value ? Convert.ToInt32(reader["current_bookings"]) : 0,
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances);
        }

        public Task<IEnumerable<ClassInstance>> GetByDateAsync(DateTime date)
        {
            var query = "SELECT * FROM class_instances WHERE DATE(class_date) = @Date";
            var instances = new List<ClassInstance>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@Date";
                    parameter.Value = date.Date;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = reader["schedule_id"] != DBNull.Value ? Convert.ToInt32(reader["schedule_id"]) : 0,
                                ClassDate = reader["class_date"] != DBNull.Value ? Convert.ToDateTime(reader["class_date"]) : default,
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = reader["capacity"] != DBNull.Value ? Convert.ToInt32(reader["capacity"]) : 0,
                                CurrentBookings = reader["current_bookings"] != DBNull.Value ? Convert.ToInt32(reader["current_bookings"]) : 0,
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances);
        }

        public Task<IEnumerable<ClassInstance>> GetUpcomingInstancesAsync(int daysAhead)
        {
            var query = "SELECT * FROM class_instances WHERE class_date >= CURDATE() AND class_date <= DATE_ADD(CURDATE(), INTERVAL @DaysAhead DAY) AND status = 'scheduled'";
            var instances = new List<ClassInstance>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@DaysAhead";
                    parameter.Value = daysAhead;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = reader["schedule_id"] != DBNull.Value ? Convert.ToInt32(reader["schedule_id"]) : 0,
                                ClassDate = reader["class_date"] != DBNull.Value ? Convert.ToDateTime(reader["class_date"]) : default,
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = reader["capacity"] != DBNull.Value ? Convert.ToInt32(reader["capacity"]) : 0,
                                CurrentBookings = reader["current_bookings"] != DBNull.Value ? Convert.ToInt32(reader["current_bookings"]) : 0,
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances);
        }

        public Task<IEnumerable<ClassInstance>> GetAvailableInstancesAsync(DateTime fromDate, DateTime toDate)
        {
            var query = "SELECT * FROM class_instances WHERE class_date >= @FromDate AND class_date <= @ToDate AND status = 'scheduled' AND current_bookings < capacity";
            var instances = new List<ClassInstance>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
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
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = reader["schedule_id"] != DBNull.Value ? Convert.ToInt32(reader["schedule_id"]) : 0,
                                ClassDate = reader["class_date"] != DBNull.Value ? Convert.ToDateTime(reader["class_date"]) : default,
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = reader["capacity"] != DBNull.Value ? Convert.ToInt32(reader["capacity"]) : 0,
                                CurrentBookings = reader["current_bookings"] != DBNull.Value ? Convert.ToInt32(reader["current_bookings"]) : 0,
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances);
        }

        public Task<IEnumerable<ClassInstance>> GetInstancesByScheduleAsync(int scheduleId)
        {
            var query = "SELECT * FROM class_instances WHERE schedule_id = @ScheduleID";
            var instances = new List<ClassInstance>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@ScheduleID";
                    parameter.Value = scheduleId;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = reader["schedule_id"] != DBNull.Value ? Convert.ToInt32(reader["schedule_id"]) : 0,
                                ClassDate = reader["class_date"] != DBNull.Value ? Convert.ToDateTime(reader["class_date"]) : default,
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = reader["capacity"] != DBNull.Value ? Convert.ToInt32(reader["capacity"]) : 0,
                                CurrentBookings = reader["current_bookings"] != DBNull.Value ? Convert.ToInt32(reader["current_bookings"]) : 0,
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances);
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
                using (var command = connection.CreateCommand())
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
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var instance = new ClassInstance
                            {
                                ClassInstanceId = Convert.ToInt32(reader["instance_id"]),
                                ClassScheduleId = reader["schedule_id"] != DBNull.Value ? Convert.ToInt32(reader["schedule_id"]) : 0,
                                ClassDate = reader["class_date"] != DBNull.Value ? Convert.ToDateTime(reader["class_date"]) : default,
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default,
                                StartTime = TimeOnly.FromTimeSpan(reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero),
                                EndTime = TimeOnly.FromTimeSpan(reader["end_time"] != DBNull.Value ? ((TimeSpan)reader["end_time"]) : TimeSpan.Zero),
                                Capacity = reader["capacity"] != DBNull.Value ? Convert.ToInt32(reader["capacity"]) : 0,
                                CurrentBookings = reader["current_bookings"] != DBNull.Value ? Convert.ToInt32(reader["current_bookings"]) : 0,
                                CancelationReason = reader["cancellation_reason"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty
                            };
                            instances.Add(instance);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassInstance>>(instances);
        }

        public Task<int> CreateAsync(ClassInstance instance)
        {
            var query = "INSERT INTO class_instances (schedule_id, class_date, start_time, end_time, instructor_id, room_id, capacity, current_bookings, status, cancellation_reason, created_at) " +
                        "VALUES (@ScheduleID, @ClassDate, @StartTime, @EndTime, @InstructorID, @RoomID, @Capacity, @CurrentBookings, @Status, @CancellationReason, @CreatedAt);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    var scheduleIdParam = command.CreateParameter();
                    scheduleIdParam.ParameterName = "@ScheduleID";
                    scheduleIdParam.Value = instance.ClassScheduleId <= 0
                        ? (object)DBNull.Value
                        : instance.ClassScheduleId;
                    command.Parameters.Add(scheduleIdParam);

                    var classDateParam = command.CreateParameter();
                    classDateParam.ParameterName = "@ClassDate";
                    classDateParam.Value = instance.ClassDate;
                    command.Parameters.Add(classDateParam);

                    var startTimeParam = command.CreateParameter();
                    startTimeParam.ParameterName = "@StartTime";
                    startTimeParam.Value = instance.StartTime.ToTimeSpan();
                    command.Parameters.Add(startTimeParam);

                    var endTimeParam = command.CreateParameter();
                    endTimeParam.ParameterName = "@EndTime";
                    endTimeParam.Value = instance.EndTime.ToTimeSpan();
                    command.Parameters.Add(endTimeParam);

                    var instructorIdParam = command.CreateParameter();
                    instructorIdParam.ParameterName = "@InstructorID";
                    instructorIdParam.Value = instance.InstructorId;
                    command.Parameters.Add(instructorIdParam);

                    var roomIdParam = command.CreateParameter();
                    roomIdParam.ParameterName = "@RoomID";
                    roomIdParam.Value = instance.RoomId;
                    command.Parameters.Add(roomIdParam);

                    var capacityParam = command.CreateParameter();
                    capacityParam.ParameterName = "@Capacity";
                    capacityParam.Value = instance.Capacity;
                    command.Parameters.Add(capacityParam);

                    var currentBookingsParam = command.CreateParameter();
                    currentBookingsParam.ParameterName = "@CurrentBookings";
                    currentBookingsParam.Value = instance.CurrentBookings;
                    command.Parameters.Add(currentBookingsParam);

                    var statusParam = command.CreateParameter();
                    statusParam.ParameterName = "@Status";
                    statusParam.Value = instance.Status ?? (object)DBNull.Value;
                    command.Parameters.Add(statusParam);

                    var cancellationReasonParam = command.CreateParameter();
                    cancellationReasonParam.ParameterName = "@CancellationReason";
                    cancellationReasonParam.Value = instance.CancelationReason ?? (object)DBNull.Value;
                    command.Parameters.Add(cancellationReasonParam);

                    var createdAtParam = command.CreateParameter();
                    createdAtParam.ParameterName = "@CreatedAt";
                    createdAtParam.Value = instance.CreatedAt;
                    command.Parameters.Add(createdAtParam);

                    var result = command.ExecuteNonQuery();
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
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    var scheduleIdParam = command.CreateParameter();
                    scheduleIdParam.ParameterName = "@ScheduleID";
                    scheduleIdParam.Value = instance.ClassScheduleId;
                    command.Parameters.Add(scheduleIdParam);

                    var classDateParam = command.CreateParameter();
                    classDateParam.ParameterName = "@ClassDate";
                    classDateParam.Value = instance.ClassDate;
                    command.Parameters.Add(classDateParam);

                    var startTimeParam = command.CreateParameter();
                    startTimeParam.ParameterName = "@StartTime";
                    startTimeParam.Value = instance.StartTime.ToTimeSpan();
                    command.Parameters.Add(startTimeParam);

                    var endTimeParam = command.CreateParameter();
                    endTimeParam.ParameterName = "@EndTime";
                    endTimeParam.Value = instance.EndTime.ToTimeSpan();
                    command.Parameters.Add(endTimeParam);

                    var instructorIdParam = command.CreateParameter();
                    instructorIdParam.ParameterName = "@InstructorID";
                    instructorIdParam.Value = instance.InstructorId;
                    command.Parameters.Add(instructorIdParam);

                    var roomIdParam = command.CreateParameter();
                    roomIdParam.ParameterName = "@RoomID";
                    roomIdParam.Value = instance.RoomId;
                    command.Parameters.Add(roomIdParam);

                    var capacityParam = command.CreateParameter();
                    capacityParam.ParameterName = "@Capacity";
                    capacityParam.Value = instance.Capacity;
                    command.Parameters.Add(capacityParam);

                    var currentBookingsParam = command.CreateParameter();
                    currentBookingsParam.ParameterName = "@CurrentBookings";
                    currentBookingsParam.Value = instance.CurrentBookings;
                    command.Parameters.Add(currentBookingsParam);

                    var statusParam = command.CreateParameter();
                    statusParam.ParameterName = "@Status";
                    statusParam.Value = instance.Status ?? (object)DBNull.Value;
                    command.Parameters.Add(statusParam);

                    var cancellationReasonParam = command.CreateParameter();
                    cancellationReasonParam.ParameterName = "@CancellationReason";
                    cancellationReasonParam.Value = instance.CancelationReason ?? (object)DBNull.Value;
                    command.Parameters.Add(cancellationReasonParam);

                    var instanceIdParam = command.CreateParameter();
                    instanceIdParam.ParameterName = "@InstanceID";
                    instanceIdParam.Value = instance.ClassInstanceId;
                    command.Parameters.Add(instanceIdParam);

                    var result = command.ExecuteNonQuery();
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
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstanceID";
                    parameter.Value = instanceId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteNonQuery();
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
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstanceID";
                    parameter.Value = instanceId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteNonQuery();
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
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstanceID";
                    parameter.Value = instanceId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteNonQuery();
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
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@InstanceID";
                    parameter.Value = instanceId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteScalar();
                    return Task.FromResult(result != null && Convert.ToBoolean(result));
                }
            }
        }
    }
}
