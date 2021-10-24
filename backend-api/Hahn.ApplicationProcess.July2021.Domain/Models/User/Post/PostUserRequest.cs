using System.Collections.Generic;
using FluentValidation;

namespace Hahn.ApplicationProcess.July2021.Domain.Models.User.Post
{
    public class PostUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public List<string> Assets { get; set; }
    }

    //public class PostUserValidator : AbstractValidator<PostUserRequest>
    //{
    //    public PostUserValidator()
    //    {
    //        RuleFor(x => x.FirstName).Length(3, 50);
    //        RuleFor(x => x.LastName).Length(3, 50);
    //        RuleFor(x => x.Age).GreaterThanOrEqualTo(18);
    //        RuleFor(x => x.HouseNumber).NotNull().NotEmpty();
    //        RuleFor(x => x.Street).NotNull().NotEmpty();
    //        RuleFor(x => x.PostalCode).NotNull().NotEmpty();
    //        RuleFor(x => x.Email).EmailAddress();
    //    }
    //}
}
