

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RiotApiController.Domain.Entities
{
    public class ScrapedMatchResultEntity
    {
        [Key]
        public long MatchId { get; set; }
        public string Version { get; set; }
        public int AvarageRate { get; set; }
        public string[] Team1Champions { get; set; } = new string[5];
        public string[] Team2Champions { get; set; } = new string[5];

        // team1=100, team2=200
        public int WonTeam { get; set; }

        public ScrapedMatchResultEntity(long matchId, string version)
        {
            MatchId = matchId;
            Version = version;
        }
    }

    public class LolDbContext : DbContext
    {
        public DbSet<ScrapedMatchResultEntity> Matchs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(Shared.SettingEntity.ConnectionString);
    }
}
