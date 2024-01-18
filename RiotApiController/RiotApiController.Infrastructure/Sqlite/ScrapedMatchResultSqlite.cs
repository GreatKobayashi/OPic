using Microsoft.Data.Sqlite;
using RiotApiController.Domain.Repositories;

namespace RiotApiController.Infrastructure.Sqlite
{
    public class ScrapedMatchResultSqlite : IDatabaseAccessRepository
    {
        private string _connectionString;

        public ScrapedMatchResultSqlite(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Update()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                connection.Close();
            }
        }
    }
}
