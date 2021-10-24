using System;
using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.July2021.Data.DataContext
{
    public class UserAsset
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid AssetId { get; set; }

        public User User { get; set; }
        public Asset Asset { get; set; }
    }
}
