using Microsoft.EntityFrameworkCore;
using RiotApiController.Domain.Entities;
using RiotApiController.Domain.Repositories;

namespace RiotApiController.Infrastructure.Sqlite
{
    public class ScrapedMatchResultSqlite : IDatabaseAccessRepository
    {
        public void Add(ScrapedMatchResultEntity scrapedMatchResultEntity)
        {
            using (var context = new LolDbContext())
            {
                context.Database.EnsureCreated();
                try
                {
                    context.Matchs.Add(scrapedMatchResultEntity);
                    context.SaveChanges();
                }
                catch (InvalidOperationException)
                {
                    // 同一試合を取得すると主キー被りでエラー発生
                    // do nothing
                }
                catch (DbUpdateException)
                {
                    // do nothing
                }
            }
        }

        public void AddRange(List<ScrapedMatchResultEntity> scrapedMatchResultEntities)
        {
            using (var context = new LolDbContext())
            {
                context.Database.EnsureCreated();
                context.Matchs.AddRange(scrapedMatchResultEntities);
                context.SaveChanges();
            }
        }
    }
}
