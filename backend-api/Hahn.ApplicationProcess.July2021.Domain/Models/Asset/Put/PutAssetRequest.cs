﻿namespace Hahn.ApplicationProcess.July2021.Domain.Models
{
    public class PutAssetRequest: AssetBase
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
