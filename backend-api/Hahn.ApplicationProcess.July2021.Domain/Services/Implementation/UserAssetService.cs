using System;
using System.Linq;
using Hahn.ApplicationProcess.July2021.Data.DataContext;
using Hahn.ApplicationProcess.July2021.Data.Implementations;
using Hahn.ApplicationProcess.July2021.Domain.Models.UserAsset.Delete;
using Hahn.ApplicationProcess.July2021.Domain.Models.UserAsset.GetByUserId;
using Hahn.ApplicationProcess.July2021.Domain.Models.UserAsset.Post;
using Hahn.ApplicationProcess.July2021.Domain.Services.Interfaces;

namespace Hahn.ApplicationProcess.July2021.Domain.Services.Implementation
{
    public class UserAssetService : IUserAssetService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly GenericRepository<UserAsset> _repository;

        public UserAssetService(ApplicationProcessDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _repository = _unitOfWork.UserAssetRepository;
        }

        public GetUserAssetByUserIdResponse GetByUserId(GetUserAssetByUserIdRequest request)
        {
            var x = _repository.Get(includeProperties: "Asset,User").ToList();
            var response = new GetUserAssetByUserIdResponse
            {
                UserAssets = _repository.Get().Where(x => x.UserId == request.UserId)
                    .Select(x => new GetUserAssetByUserIdResponse.UserAssetModel
                    {
                        Id = x.Id,
                        AssetId = x.AssetId.ToString(),
                        AssetName = x.Asset?.Name,
                        AssetSymbol = x.Asset?.Symbol
                    }).ToList()
            };


            return response;
        }

        public PostUserAssetResponse Post(PostUserAssetRequest request)
        {
            var result = _repository.Insert(new UserAsset
            {
                UserId = request.UserId,
                AssetId = Guid.Parse(request.AssetId)
            });

            _unitOfWork.Save();

            return new PostUserAssetResponse() { Id = result.Id };
        }

        public void Delete(DeleteUserAssetRequest request)
        {
            _repository.Delete(request.Id);

            _unitOfWork.Save();
        }
    }
}
