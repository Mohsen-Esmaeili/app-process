using System.Collections.Generic;

namespace Hahn.ApplicationProcess.July2021.Domain.Models
{
    public class GetUserAssetByUserIdResponse
    {
        public List<UserAssetModel> UserAssets { get; set; }

        public class UserAssetModel
        {
            public int Id { get; set; }
            public string AssetId { get; set; }
            public string AssetName { get; set; }
            public string AssetSymbol { get; set; }
        }
    }
}
