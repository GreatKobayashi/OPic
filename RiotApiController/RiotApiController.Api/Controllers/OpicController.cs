using Microsoft.AspNetCore.Mvc;
using RiotApiController.Domain.Entities;
using RiotApiController.Infrastructure;
using RiotSharp;
using RiotSharp.Misc;
using System.Text.Json;

namespace RiotApiController.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpicController : ControllerBase
    {
        private string _apiKey = "RGAPI-53c86770-511a-43a6-8826-999deacd0239";

        // Duster PuuID
        private string _puuId = "1YJ96H5Z9Gy7XVs-KlceM--D_GdxTmReFllNRQjdZPMNrcnJDTnBM3_c9SJ9oenNQTJL4i5vtbI7tg";

        [HttpGet]
        public string PostStartScraping()
        {
            try
            {
                var api = RiotApi.GetDevelopmentInstance(_apiKey);
                var matchs = api.Match.GetMatchListAsync(Region.Asia, _puuId).Result;

                var match = api.Match.GetMatchAsync(Region.Asia, matchs[0]).Result;
                var participants = match.Info.Participants.Select(x => x.ChampionName).ToArray();

                var matchResult = new ScrapedMatchResultEntity(match.Info.GameId, match.Info.GameVersion)
                {
                    Team1Champions = participants[0..5],
                    Team2Champions = participants[5..10],
                    WonTeam = match.Info.Teams[0].Win ? 100 : 200
                };

                var database = Factories.CreateDatabaseAccessRepository();
                database.Update();

                return JsonSerializer.Serialize(matchResult);
            }
            catch (RiotSharpException)
            {
                throw;
            }
        }
    }
}
