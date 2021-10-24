using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.July2021.Domain.Models
{
    public class DeleteAssetRequest
    {
        [Required(ErrorMessage = "AssetId is required")]
        public string AssetId { get; set; }
    }
}
