using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.July2021.Domain.Models
{
    public class GetUserAssetByUserIdRequest
    {
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }
    }
}
