using System;
using System.Data.SqlClient;
using System.IO;

namespace EduTime.DataAccess.Database
{
    public class DatabaseManager
    {
        private readonly string _masterConnectionString;
        private readonly string _databaseConnectionString;

        public DatabaseManager(string masterConnectionString, string databaseConnectionString)
        {
            _masterConnectionString = masterConnectionString;
            _databaseConnectionString = databaseConnectionString;
        }

        public void CreateDatabase()
        {
            var scriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "00_CreateDatabase.sql");
            var script = File.ReadAllText(scriptPath);

            using (var connection = new SqlConnection(_masterConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(script, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDatabase()
        {
            using (var connection = new SqlConnection(_masterConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DROP DATABASE IF EXISTS EduTimeDB", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InitializeDatabase()
        {
            CreateDatabase();
            var initializer = new DatabaseInitializer(_databaseConnectionString);
            initializer.Initialize();
        }
    }
}
