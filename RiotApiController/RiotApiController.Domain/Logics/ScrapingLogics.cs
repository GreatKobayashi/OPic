using RiotApiController.Domain.Entities;
using RiotApiController.Domain.Repositories;
using RiotSharp;
using RiotSharp.Endpoints.LeagueEndpoint;
using RiotSharp.Misc;

namespace RiotApiController.Domain.Logics
{
    public static class ScrapingLogics
    {
        private static Dictionary<string, int> tierValue = new()
        {
            {"IRON", 0},
            {"BRONZE", 4},
            {"SILVER", 8},
            {"GOLD", 12},
            {"PLATINUM", 16},
            {"EMERALD", 20},
            {"DIAMOND", 24},
            {"MASTER", 28},
            {"GRANDMASTER", 32},
            {"CHALLENGER", 36}
        };

        private static Dictionary<string, int> rankValue = new()
        {
            {"IV", 0},
            {"III", 1},
            {"II", 2},
            {"I", 3}
        };

        public static void GetAndSaveMatchs(int matchCount, RiotApi api, string startPuuid, IDatabaseAccessRepository databaseAccessRepository)
        {
            var matchList = new List<ScrapedMatchResultEntity>();

            var nextTargetParticipantPuuid = startPuuid;
            var rnd = new Random();

            for (int i = 0; i < matchCount; i++)
            {
                var matchs = api.Match.GetMatchListAsync(Region.Asia, nextTargetParticipantPuuid).Result;

                var match = api.Match.GetMatchAsync(Region.Asia, matchs[rnd.Next(10)]).Result;
                var champions = match.Info.Participants.Select(x => x.ChampionName).ToArray();

                var rankInts = new List<int>();
                foreach (var participant in match.Info.Participants)
                {
                    var summoner = api.Summoner.GetSummonerByPuuidAsync(Region.Jp, participant.Puuid).Result;
                    var leageue = api.League.GetLeagueEntriesBySummonerAsync(Region.Jp, summoner.Id).Result;
                    if (leageue.Any())
                    {
                        rankInts.Add(ConvertRateToInt(leageue));
                    }
                }

                var matchResult = new ScrapedMatchResultEntity(match.Info.GameId, match.Info.GameVersion)
                {
                    Team1Champions = champions[0..5],
                    Team2Champions = champions[5..10],
                    WonTeam = match.Info.Teams[0].Win ? 100 : 200,
                    AvarageRate = (int)rankInts.Average(),
                };
                matchList.Add(matchResult);

                nextTargetParticipantPuuid = match.Info.Participants[rnd.Next(10)].Puuid;
                databaseAccessRepository.Add(matchResult);
            }
        }

        private static int ConvertRateToInt(List<LeagueEntry> leagueEntries)
        {
            var rateInt = 0;
            rateInt += tierValue[leagueEntries[0].Tier];
            rateInt += rankValue[leagueEntries[0].Rank];

            return rateInt;
        }
    }
}
