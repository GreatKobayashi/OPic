using RiotApiController.Domain.Entities;
using RiotApiController.Domain.Logics;

namespace RiotApiController.Infrastructure.Json
{
    public class SettingFileJson : ISettingFileRepository
    {
        public SettingEntity GetEntity()
        {
            try
            {
                return JsonSerializerHelper.Deserialize<SettingEntity>("RiotApiController.json");
            }
            catch (Exception ex)
            {
                throw new Exception("設定ファイル読み込み失敗", ex);
            }
        }
    }
}
