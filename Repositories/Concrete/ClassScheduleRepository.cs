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
                                IsActive = reader["is_active"] != DBNull.Value ? Convert.ToBoolean(reader["is_active"]) : false,
                                EffectiveFrom = reader["effective_from"] != DBNull.Value ? Convert.ToDateTime(reader["effective_from"]) : default,
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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
                                IsActive = reader["is_active"] != DBNull.Value ? Convert.ToBoolean(reader["is_active"]) : false,
                                EffectiveFrom = reader["effective_from"] != DBNull.Value ? Convert.ToDateTime(reader["effective_from"]) : default,
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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
                                IsActive = reader["is_active"] != DBNull.Value ? Convert.ToBoolean(reader["is_active"]) : false,
                                EffectiveFrom = reader["effective_from"] != DBNull.Value ? Convert.ToDateTime(reader["effective_from"]) : default,
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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
                                IsActive = reader["is_active"] != DBNull.Value ? Convert.ToBoolean(reader["is_active"]) : false,
                                EffectiveFrom = reader["effective_from"] != DBNull.Value ? Convert.ToDateTime(reader["effective_from"]) : default,
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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
                                IsActive = reader["is_active"] != DBNull.Value ? Convert.ToBoolean(reader["is_active"]) : false,
                                EffectiveFrom = reader["effective_from"] != DBNull.Value ? Convert.ToDateTime(reader["effective_from"]) : default,
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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
                                IsActive = reader["is_active"] != DBNull.Value ? Convert.ToBoolean(reader["is_active"]) : false,
                                EffectiveFrom = reader["effective_from"] != DBNull.Value ? Convert.ToDateTime(reader["effective_from"]) : default,
                                EffectiveUntil = reader["effective_until"] != DBNull.Value ? Convert.ToDateTime(reader["effective_until"]) : default,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
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

                    // Bind parameters directly
                    var classTypeIdParam = command.CreateParameter();
                    classTypeIdParam.ParameterName = "@ClassTypeID";
                    classTypeIdParam.Value = schedule.ClassTypeId;
                    command.Parameters.Add(classTypeIdParam);

                    var instructorIdParam = command.CreateParameter();
                    instructorIdParam.ParameterName = "@InstructorID";
                    instructorIdParam.Value = schedule.InstructorId;
                    command.Parameters.Add(instructorIdParam);

                    var roomIdParam = command.CreateParameter();
                    roomIdParam.ParameterName = "@RoomID";
                    roomIdParam.Value = schedule.RoomId;
                    command.Parameters.Add(roomIdParam);

                    var dayOfWeekParam = command.CreateParameter();
                    dayOfWeekParam.ParameterName = "@DayOfWeek";
                    dayOfWeekParam.Value = schedule.DayOfWeek;
                    command.Parameters.Add(dayOfWeekParam);

                    var startTimeParam = command.CreateParameter();
                    startTimeParam.ParameterName = "@StartTime";
                    startTimeParam.Value = schedule.StartTime;
                    command.Parameters.Add(startTimeParam);

                    var isActiveParam = command.CreateParameter();
                    isActiveParam.ParameterName = "@IsActive";
                    isActiveParam.Value = schedule.IsActive;
                    command.Parameters.Add(isActiveParam);

                    var effectiveFromParam = command.CreateParameter();
                    effectiveFromParam.ParameterName = "@EffectiveFrom";
                    effectiveFromParam.Value = schedule.EffectiveFrom;
                    command.Parameters.Add(effectiveFromParam);

                    var effectiveUntilParam = command.CreateParameter();
                    effectiveUntilParam.ParameterName = "@EffectiveUntil";
                    effectiveUntilParam.Value = schedule.EffectiveUntil == default ? (object)DBNull.Value : schedule.EffectiveUntil;
                    command.Parameters.Add(effectiveUntilParam);

                    var createdAtParam = command.CreateParameter();
                    createdAtParam.ParameterName = "@CreatedAt";
                    createdAtParam.Value = schedule.CreatedAt;
                    command.Parameters.Add(createdAtParam);

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

                    // Bind parameters directly
                    var classTypeIdParam = command.CreateParameter();
                    classTypeIdParam.ParameterName = "@ClassTypeID";
                    classTypeIdParam.Value = schedule.ClassTypeId;
                    command.Parameters.Add(classTypeIdParam);

                    var instructorIdParam = command.CreateParameter();
                    instructorIdParam.ParameterName = "@InstructorID";
                    instructorIdParam.Value = schedule.InstructorId;
                    command.Parameters.Add(instructorIdParam);

                    var roomIdParam = command.CreateParameter();
                    roomIdParam.ParameterName = "@RoomID";
                    roomIdParam.Value = schedule.RoomId;
                    command.Parameters.Add(roomIdParam);

                    var dayOfWeekParam = command.CreateParameter();
                    dayOfWeekParam.ParameterName = "@DayOfWeek";
                    dayOfWeekParam.Value = schedule.DayOfWeek;
                    command.Parameters.Add(dayOfWeekParam);

                    var startTimeParam = command.CreateParameter();
                    startTimeParam.ParameterName = "@StartTime";
                    startTimeParam.Value = schedule.StartTime;
                    command.Parameters.Add(startTimeParam);

                    var isActiveParam = command.CreateParameter();
                    isActiveParam.ParameterName = "@IsActive";
                    isActiveParam.Value = schedule.IsActive;
                    command.Parameters.Add(isActiveParam);

                    var effectiveFromParam = command.CreateParameter();
                    effectiveFromParam.ParameterName = "@EffectiveFrom";
                    effectiveFromParam.Value = schedule.EffectiveFrom;
                    command.Parameters.Add(effectiveFromParam);

                    var effectiveUntilParam = command.CreateParameter();
                    effectiveUntilParam.ParameterName = "@EffectiveUntil";
                    effectiveUntilParam.Value = schedule.EffectiveUntil == default ? (object)DBNull.Value : schedule.EffectiveUntil;
                    command.Parameters.Add(effectiveUntilParam);

                    var scheduleIdParam = command.CreateParameter();
                    scheduleIdParam.ParameterName = "@ScheduleID";
                    scheduleIdParam.Value = schedule.ClassScheduleId;
                    command.Parameters.Add(scheduleIdParam);

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
