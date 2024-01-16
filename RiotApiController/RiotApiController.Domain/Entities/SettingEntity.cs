using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
