using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.July2021.Data.DataContext
{
    public class Asset
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public ICollection<UserAsset> UserAssets { get; set; }
    }
}
