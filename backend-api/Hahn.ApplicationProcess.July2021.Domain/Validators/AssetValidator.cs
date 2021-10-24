using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Hahn.ApplicationProcess.July2021.Domain.Models;
using RestSharp;

namespace Hahn.ApplicationProcess.July2021.Domain.Validators
{
    public class AssetValidator: AbstractValidator<AssetBase>
    {
        public AssetValidator()
        {
            RuleFor(a => a.Name).NotNull().NotEmpty().WithMessage("Asset name is required");
            RuleFor(a => a.Symbol).NotNull().NotEmpty().WithMessage("Asset symbol is required");
        }

        private bool BeAValidAsset(string name, string symbol)
        {
            var client = new RestClient("https://api.coincap.io/v2/assets");
            var request = new RestRequest(Method.GET);
            var response = client.Execute<ValidAsset>(request);

            return response.Data.data.Any(x => x.name == name && x.symbol == symbol);
        }
    }

    public class ValidAsset
    {
        public List<coreData> data { get; set; }

        public class coreData
        {
            public string id { get; set; }
            public string symbol { get; set; }
            public string name { get; set; }
        }
    }
}
