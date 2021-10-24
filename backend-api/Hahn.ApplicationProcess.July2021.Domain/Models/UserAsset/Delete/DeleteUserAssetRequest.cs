using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.July2021.Domain.Models
{
    public class DeleteUserAssetRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
    }
}
