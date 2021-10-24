using Hahn.ApplicationProcess.July2021.Domain.Models.UserAsset.Delete;
using Hahn.ApplicationProcess.July2021.Domain.Models.UserAsset.GetByUserId;
using Hahn.ApplicationProcess.July2021.Domain.Models.UserAsset.Post;

namespace Hahn.ApplicationProcess.July2021.Domain.Services.Interfaces
{
    public interface IUserAssetService
    {
        GetUserAssetByUserIdResponse GetByUserId(GetUserAssetByUserIdRequest request);
        PostUserAssetResponse Post(PostUserAssetRequest request);
        void Delete(DeleteUserAssetRequest request);
    }
}
