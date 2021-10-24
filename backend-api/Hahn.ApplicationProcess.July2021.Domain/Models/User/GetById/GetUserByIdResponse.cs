using System.Collections.Generic;

namespace Hahn.ApplicationProcess.July2021.Domain.Models.User.GetById
{
    public class GetUserByIdResponse
    {
        public UserModel User { get; set; }

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
            public List<AssetModel> Assets { get; set; }
        }

        public class AssetModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Symbol { get; set; }
        }
    }
}
