using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gym_Manager_System.DataFolder
{
    public class DatabaseContext
    {
        private readonly string _connectionString = "Server=54.252.85.7;Database=gym_management_system;User ID=admin_son;Password=son16012005;";
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        
        
       
    }
}
