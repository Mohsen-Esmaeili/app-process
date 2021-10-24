using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.July2021.Domain.Models
{
    public class DeleteUserRequest
    {
        [Required(ErrorMessage = "UserId is required")]
        public int Id { get; set; }
    }
}
