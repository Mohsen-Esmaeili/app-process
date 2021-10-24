using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicationProcess.July2021.Data.DataContext
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public ICollection<UserAsset> UserAssets { get; set; }
    }
}
