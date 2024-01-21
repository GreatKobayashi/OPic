using RiotApiController.Domain.Entities;

namespace RiotApiController.Domain.Repositories
{
    public interface IDatabaseAccessRepository
    {
        public void Add(ScrapedMatchResultEntity scrapedMatchResultEntity);
        public void AddRange(List<ScrapedMatchResultEntity> scrapedMatchResultEntities);
    }
}
