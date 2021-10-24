using System.Collections.Generic;

namespace Hahn.ApplicationProcess.July2021.Domain.Models
{
    public class PutUserRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public List<string> Assets{ get; set; }
    }
}
