using System.Collections.Generic;

namespace Hahn.ApplicationProcess.July2021.Domain.Models
{
    public class GetUserResponse
    {
        public List<UserModel> Users { get; set; }

        public class UserModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public byte Age { get; set; }
            public string Email { get; set; }
            public string PostalCode { get; set; }
            public string Street { get; set; }
            public int? HouseNumber { get; set; }
        }
    }
}
