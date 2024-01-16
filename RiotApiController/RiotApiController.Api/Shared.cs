using RiotApiController.Domain.Entities;
using System.Text.Json.Serialization;

namespace RiotApiController.Api
{
    public static class Shared
    {
        [JsonInclude]
        public static SettingEntity? SettingEntity { get; set; }
    }
}
