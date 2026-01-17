using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class ClassScheduleRepository : IClassScheduleRepository
    {
        private readonly DatabaseContext _context;

        public ClassScheduleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<ClassSchedule?> GetByIdAsync(int scheduleId)
        {
            string query = "SELECT * FROM class_schedules WHERE schedule_id = @ScheduleID";
            using (var connection = _context.CreateConnection()) // Open a connection to the database
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
                        if (reader.Read())
                        {
                            var schedule = new ClassSchedule
                            {
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassTypeId = Convert.ToInt32(reader["class_type_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                DayOfWeek = Convert.ToInt32(reader["day_of_week"]),
                                StartTime = reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero,
                                IsActive = Convert.ToBoolean(reader["is_active"]),
                                EffectiveFrom = Convert.ToDateTime(reader["effective_from"]),
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            return Task.FromResult<ClassSchedule?>(schedule); //Static method by .NET
                        }
                    }
                }
            }

            return Task.FromResult<ClassSchedule?>(null);
        }

        public Task<IEnumerable<ClassSchedule>> GetAllAsync()
        {
            var query = "SELECT * FROM class_schedules";
            var schedules = new List<ClassSchedule>();
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
                            var schedule = new ClassSchedule
                            {
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassTypeId = Convert.ToInt32(reader["class_type_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                DayOfWeek = Convert.ToInt32(reader["day_of_week"]),
                                StartTime = reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero,
                                IsActive = Convert.ToBoolean(reader["is_active"]),
                                EffectiveFrom = Convert.ToDateTime(reader["effective_from"]),
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            schedules.Add(schedule);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassSchedule>>(schedules); //return a list of schedule
        }

        public Task<IEnumerable<ClassSchedule>> GetActiveSchedulesAsync()
        {
            var query = "SELECT * FROM class_schedules WHERE is_active = 1";
            var schedules = new List<ClassSchedule>();
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
                            var schedule = new ClassSchedule
                            {
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassTypeId = Convert.ToInt32(reader["class_type_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                DayOfWeek = Convert.ToInt32(reader["day_of_week"]),
                                StartTime = reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero,
                                IsActive = Convert.ToBoolean(reader["is_active"]),
                                EffectiveFrom = Convert.ToDateTime(reader["effective_from"]),
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            schedules.Add(schedule);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassSchedule>>(schedules); //return a list of schedule
        }

        public Task<IEnumerable<ClassSchedule>> GetSchedulesByDayAsync(int dayOfWeek)
        {
            var query = "SELECT * FROM class_schedules WHERE day_of_week = @DayOfWeek AND is_active = 1";
            var schedules = new List<ClassSchedule>();
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@DayOfWeek";
                    parameter.Value = dayOfWeek;
                    command.Parameters.Add(parameter);
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var schedule = new ClassSchedule
                            {
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassTypeId = Convert.ToInt32(reader["class_type_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                DayOfWeek = Convert.ToInt32(reader["day_of_week"]),
                                StartTime = reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero,
                                IsActive = Convert.ToBoolean(reader["is_active"]),
                                EffectiveFrom = Convert.ToDateTime(reader["effective_from"]),
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            schedules.Add(schedule);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassSchedule>>(schedules); //return a list of schedule
        }

        public Task<IEnumerable<ClassSchedule>> GetSchedulesByClassTypeAsync(int classTypeId)
        {
            var query = "SELECT * FROM class_schedules WHERE class_type_id = @ClassTypeID";
            var schedules = new List<ClassSchedule>();
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
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var schedule = new ClassSchedule
                            {
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassTypeId = Convert.ToInt32(reader["class_type_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                DayOfWeek = Convert.ToInt32(reader["day_of_week"]),
                                StartTime = reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero,
                                IsActive = Convert.ToBoolean(reader["is_active"]),
                                EffectiveFrom = Convert.ToDateTime(reader["effective_from"]),
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            schedules.Add(schedule);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassSchedule>>(schedules); //return a list of schedule
        }

        public Task<IEnumerable<ClassSchedule>> GetSchedulesByInstructorAsync(int instructorId)
        {
            var query = "SELECT * FROM class_schedules WHERE instructor_id = @InstructorID";
            var schedules = new List<ClassSchedule>();
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
                    using (var reader = command.ExecuteReader()) // Execute the command and read the results
                    {
                        while (reader.Read())
                        {
                            var schedule = new ClassSchedule
                            {
                                ClassScheduleId = Convert.ToInt32(reader["schedule_id"]),
                                ClassTypeId = Convert.ToInt32(reader["class_type_id"]),
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                InstructorId = Convert.ToInt32(reader["instructor_id"]),
                                DayOfWeek = Convert.ToInt32(reader["day_of_week"]),
                                StartTime = reader["start_time"] != DBNull.Value ? ((TimeSpan)reader["start_time"]) : TimeSpan.Zero,
                                IsActive = Convert.ToBoolean(reader["is_active"]),
                                EffectiveFrom = Convert.ToDateTime(reader["effective_from"]),
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            schedules.Add(schedule);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<ClassSchedule>>(schedules); //return a list of schedule
        }

        public Task<int> CreateAsync(ClassSchedule schedule)
        {
            var query = "INSERT INTO class_schedules (class_type_id, instructor_id, room_id, day_of_week, start_time, is_active, effective_from, effective_until, created_at) " +
                        "VALUES (@ClassTypeID, @InstructorID, @RoomID, @DayOfWeek, @StartTime, @IsActive, @EffectiveFrom, @EffectiveUntil, @CreatedAt);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@ClassTypeID", schedule.ClassTypeId },
                        { "@InstructorID", schedule.InstructorId },
                        { "@RoomID", schedule.RoomId },
                        { "@DayOfWeek", schedule.DayOfWeek },
                        { "@StartTime", schedule.StartTime },
                        { "@IsActive", schedule.IsActive },
                        { "@EffectiveFrom", schedule.EffectiveFrom },
                        { "@EffectiveUntil", schedule.EffectiveUntil == default ? (object)DBNull.Value : schedule.EffectiveUntil },
                        { "@CreatedAt", schedule.CreatedAt }
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

        public Task<bool> UpdateAsync(ClassSchedule schedule)
        {
            var query = "UPDATE class_schedules SET class_type_id = @ClassTypeID, instructor_id = @InstructorID, " +
                        "room_id = @RoomID, day_of_week = @DayOfWeek, start_time = @StartTime, " +
                        "is_active = @IsActive, effective_from = @EffectiveFrom, effective_until = @EffectiveUntil " +
                        "WHERE schedule_id = @ScheduleID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand()) // Create a command to execute the query
                {
                    command.CommandText = query;

                    // Use a dictionary to map parameter names to values
                    var parameters = new Dictionary<string, object>
                    {
                        { "@ClassTypeID", schedule.ClassTypeId },
                        { "@InstructorID", schedule.InstructorId },
                        { "@RoomID", schedule.RoomId },
                        { "@DayOfWeek", schedule.DayOfWeek },
                        { "@StartTime", schedule.StartTime },
                        { "@IsActive", schedule.IsActive },
                        { "@EffectiveFrom", schedule.EffectiveFrom },
                        { "@EffectiveUntil", schedule.EffectiveUntil == default ? (object)DBNull.Value : schedule.EffectiveUntil },
                        { "@ScheduleID", schedule.ClassScheduleId }
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

        public Task<bool> DeleteAsync(int scheduleId)
        {
            var query = "DELETE FROM class_schedules WHERE schedule_id = @ScheduleID";

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

                    var result = command.ExecuteNonQuery(); // Execute the command
                    return Task.FromResult(result > 0); // Return true if at least one row was deleted
                }
            }
        }

        public Task<bool> ExistsAsync(int scheduleId)
        {
            var query = "SELECT COUNT(*) FROM class_schedules WHERE schedule_id = @ScheduleID";
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

                    var result = command.ExecuteScalar(); // Execute the command
                    var count = Convert.ToInt32(result);
                    return Task.FromResult(count > 0);
                }
            }
        }
    }
}
