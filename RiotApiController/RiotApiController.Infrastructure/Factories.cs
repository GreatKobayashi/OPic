using RiotApiController.Domain.Repositories;
using RiotApiController.Infrastructure.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApiController.Infrastructure
{
    public static class Factories
    {
        public static IDatabaseAccessRepository CreateDatabaseAccessRepository()
        {
            return new ScrapedMatchResultSqlite();
        }
    }
}
