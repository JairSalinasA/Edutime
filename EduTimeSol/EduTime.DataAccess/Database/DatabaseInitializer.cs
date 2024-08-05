using System;
using System.IO;
using System.Data.SqlClient;

namespace EduTime.DataAccess.Database
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Initialize()
        {
            var scriptsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations");

            ExecuteScript(Path.Combine(scriptsPath, "01_CreateTables.sql"));
            ExecuteScript(Path.Combine(scriptsPath, "02_CreateStoredProcedures.sql"));
            ExecuteScript(Path.Combine(scriptsPath, "03_InsertAdminUser.sql"));
        }

        private void ExecuteScript(string scriptFilePath)
        {
            var script = File.ReadAllText(scriptFilePath);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(script, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
