using RiotApiController.Domain.Entities;
using RiotApiController.Domain.Repositories;
using RiotApiController.Infrastructure.Json;
using RiotApiController.Infrastructure.Sqlite;

namespace RiotApiController.Infrastructure
{
    public static class Factories
    {
        public static IDatabaseAccessRepository CreateDatabaseAccessRepository(string connectionString)
        {
            return new ScrapedMatchResultSqlite(connectionString);
        }

        public static ISettingFileRepository CreateSettingFileRepository()
        {
            return new SettingFileJson();
        }
    }
}
