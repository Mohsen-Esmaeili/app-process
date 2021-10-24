using System;
using System.Linq;
using Hahn.ApplicationProcess.July2021.Data.DataContext;
using Hahn.ApplicationProcess.July2021.Data.Implementations;
using Hahn.ApplicationProcess.July2021.Domain.Models;

namespace Hahn.ApplicationProcess.July2021.Domain.Services
{
    public class AssetService: IAssetService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly GenericRepository<Asset> _repository;

        public AssetService(ApplicationProcessDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _repository = _unitOfWork.AssetRepository;
        }

        public GetAssetResponse Get()
        {
            var response = new GetAssetResponse
            {
                Assets = _repository.Get()
                    .Select(a => new GetAssetResponse.AssetModel
                    {
                        Id = a.Id.ToString(), 
                        Name = a.Name, 
                        Symbol = a.Symbol
                    }).ToList()
            };

            return response;
        }

        public PostAssetResponse Post(PostAssetRequest request)
        {
            var result = _repository.Insert(new Asset
            {
                Name = request.Name,
                Symbol = request.Symbol
            });

            _unitOfWork.Save();

            return new PostAssetResponse { AssetId = result.Id.ToString() };
        }

        public void Put(PutAssetRequest request)
        {
            _repository.Update(new Asset
            {
                Id = Guid.Parse(request.Id),
                Name = request.Name,
                Symbol = request.Symbol
            });

            _unitOfWork.Save();
        }

        public void Delete(DeleteAssetRequest request)
        {
            _repository.Delete(Guid.Parse(request.AssetId));

            _unitOfWork.Save();
        }
    }
}
