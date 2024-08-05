using EduTime.DataAccess.Database;

namespace EduTime.Domain.Services
{
    public class DatabaseService
    {
        private readonly DatabaseManager _databaseManager;

        public DatabaseService(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public void InitializeDatabase()
        {
            _databaseManager.InitializeDatabase();
        }

        public void DeleteDatabase()
        {
            _databaseManager.DeleteDatabase();
        }
    }
}
