using Microsoft.AspNetCore.Mvc;
using RiotApiController.Domain.Logics;
using RiotApiController.Infrastructure;
using RiotSharp;
using System.Text.Json;

namespace RiotApiController.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpicController : ControllerBase
    {
        private string _apiKey = "RGAPI-32c8f53f-d108-4e35-9aaa-9d480a7d862c";

        // Duster PuuID
        private string _puuId = "1YJ96H5Z9Gy7XVs-KlceM--D_GdxTmReFllNRQjdZPMNrcnJDTnBM3_c9SJ9oenNQTJL4i5vtbI7tg";

        [HttpGet]
        public string PostStartScraping()
        {
            try
            {
                var api = RiotApi.GetDevelopmentInstance(_apiKey);
                var databaseRepository = Factories.CreateDatabaseAccessRepository();
                ScrapingLogics.GetAndSaveMatchs(10, api, _puuId, databaseRepository);

                return JsonSerializer.Serialize("Done");
            }
            catch (RiotSharpException)
            {
                throw;
            }
        }
    }
}
