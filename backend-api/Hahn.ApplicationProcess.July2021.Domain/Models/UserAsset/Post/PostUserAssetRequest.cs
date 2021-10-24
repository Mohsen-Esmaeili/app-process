
using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.July2021.Domain.Models
{
    public class PostUserAssetRequest
    {
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "AssetId is required")] 
        public string AssetId { get; set; }
    }
}
