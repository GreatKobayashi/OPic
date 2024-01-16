using Microsoft.Data.Sqlite;
using RiotApiController.Domain.Repositories;

namespace RiotApiController.Infrastructure.Sqlite
{
    public class ScrapedMatchResultSqlite : IDatabaseAccessRepository
    {
        public void Update()
        {
            using (var connection = new SqliteConnection(""))
            {
                connection.Open();

                connection.Close();
            }
        }
    }
}
