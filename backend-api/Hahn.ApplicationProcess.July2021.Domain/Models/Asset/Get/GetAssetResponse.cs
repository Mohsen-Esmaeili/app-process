using System.Collections.Generic;

namespace Hahn.ApplicationProcess.July2021.Domain.Models.Asset.Get
{
    public class GetAssetResponse
    {
        public List<AssetModel> Assets { get; set; }

        public class AssetModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Symbol { get; set; }
        }
    }
}
