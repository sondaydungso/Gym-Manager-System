using Gym_Manager_System.DataFolder;
using Gym_Manager_System.Model;
using Gym_Manager_System.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Gym_Manager_System.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DatabaseContext _context;

        public RoomRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Room?> GetByIdAsync(int roomId)
        {
            string query = "SELECT * FROM rooms WHERE room_id = @RoomID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@RoomID";
                    parameter.Value = roomId;
                    command.Parameters.Add(parameter);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var room = new Room
                            {
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                RoomName = reader["room_name"]?.ToString(),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                EquipmentAvailable = reader["equipment_available"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
                            };
                            return Task.FromResult<Room?>(room);
                        }
                    }
                }
            }

            return Task.FromResult<Room?>(null);
        }

        public Task<IEnumerable<Room>> GetAllAsync()
        {
            var query = "SELECT * FROM rooms";
            var rooms = new List<Room>();
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
                            var room = new Room
                            {
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                RoomName = reader["room_name"]?.ToString(),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                EquipmentAvailable = reader["equipment_available"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
                            };
                            rooms.Add(room);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Room>>(rooms);
        }

        public Task<IEnumerable<Room>> GetAvailableRoomsAsync()
        {
            var query = "SELECT * FROM rooms WHERE status = 'available'";
            var rooms = new List<Room>();
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
                            var room = new Room
                            {
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                RoomName = reader["room_name"]?.ToString(),
                                Capacity = Convert.ToInt32(reader["capacity"]),
                                EquipmentAvailable = reader["equipment_available"]?.ToString(),
                                Status = reader["status"] != DBNull.Value ? reader["status"].ToString() : string.Empty,
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : default
                            };
                            rooms.Add(room);
                        }
                    }
                }
            }
            return Task.FromResult<IEnumerable<Room>>(rooms);
        }

        public Task<int> CreateAsync(Room room)
        {
            var query = "INSERT INTO rooms (room_name, capacity, equipment_available, status, created_at) " +
                        "VALUES (@RoomName, @Capacity, @EquipmentAvailable, @Status, @CreatedAt);";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    var roomNameParam = command.CreateParameter();
                    roomNameParam.ParameterName = "@RoomName";
                    roomNameParam.Value = room.RoomName ?? (object)DBNull.Value;
                    command.Parameters.Add(roomNameParam);

                    var capacityParam = command.CreateParameter();
                    capacityParam.ParameterName = "@Capacity";
                    capacityParam.Value = room.Capacity;
                    command.Parameters.Add(capacityParam);

                    var equipmentAvailableParam = command.CreateParameter();
                    equipmentAvailableParam.ParameterName = "@EquipmentAvailable";
                    equipmentAvailableParam.Value = room.EquipmentAvailable ?? (object)DBNull.Value;
                    command.Parameters.Add(equipmentAvailableParam);

                    var statusParam = command.CreateParameter();
                    statusParam.ParameterName = "@Status";
                    statusParam.Value = "available";
                    command.Parameters.Add(statusParam);

                    var createdAtParam = command.CreateParameter();
                    createdAtParam.ParameterName = "@CreatedAt";
                    createdAtParam.Value = room.CreatedAt;
                    command.Parameters.Add(createdAtParam);

                    var result = command.ExecuteNonQuery();
                    return Task.FromResult<int>(result);
                }
            }
        }

        public Task<bool> UpdateAsync(Room room)
        {
            var query = "UPDATE rooms SET room_name = @RoomName, capacity = @Capacity, " +
                        "equipment_available = @EquipmentAvailable, status = @Status " +
                        "WHERE room_id = @RoomID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    var roomNameParam = command.CreateParameter();
                    roomNameParam.ParameterName = "@RoomName";
                    roomNameParam.Value = room.RoomName ?? (object)DBNull.Value;
                    command.Parameters.Add(roomNameParam);

                    var capacityParam = command.CreateParameter();
                    capacityParam.ParameterName = "@Capacity";
                    capacityParam.Value = room.Capacity;
                    command.Parameters.Add(capacityParam);

                    var equipmentAvailableParam = command.CreateParameter();
                    equipmentAvailableParam.ParameterName = "@EquipmentAvailable";
                    equipmentAvailableParam.Value = room.EquipmentAvailable ?? (object)DBNull.Value;
                    command.Parameters.Add(equipmentAvailableParam);

                    var statusParam = command.CreateParameter();
                    statusParam.ParameterName = "@Status";
                    statusParam.Value = room.Status ?? "available";
                    command.Parameters.Add(statusParam);

                    var roomIdParam = command.CreateParameter();
                    roomIdParam.ParameterName = "@RoomID";
                    roomIdParam.Value = room.RoomId;
                    command.Parameters.Add(roomIdParam);

                    var result = command.ExecuteNonQuery();
                    return Task.FromResult(result > 0);
                }
            }
        }

        public Task<bool> DeleteAsync(int roomId)
        {
            var query = "DELETE FROM rooms WHERE room_id = @RoomID";

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@RoomID";
                    parameter.Value = roomId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteNonQuery();
                    return Task.FromResult(result > 0);
                }
            }
        }

        public Task<bool> ExistsAsync(int roomId)
        {
            var query = "SELECT COUNT(*) FROM rooms WHERE room_id = @RoomID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@RoomID";
                    parameter.Value = roomId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteScalar();
                    var count = Convert.ToInt32(result);
                    return Task.FromResult(count > 0);
                }
            }
        }

        public Task<bool> IsRoomAvailableAsync(int roomId)
        {
            var query = "SELECT status FROM rooms WHERE room_id = @RoomID";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@RoomID";
                    parameter.Value = roomId;
                    command.Parameters.Add(parameter);

                    var result = command.ExecuteScalar();
                    return Task.FromResult(result != null && result.ToString() == "available");
                }
            }
        }
    }
}
