using System.Text.Json.Serialization;

namespace RiotApiController.Domain.Entities
{
    public class SettingEntity
    {
        [JsonInclude]
        public string ConnectionString { get; set; }

        public SettingEntity(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
