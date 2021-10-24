using Hahn.ApplicationProcess.July2021.Domain.Models;

namespace Hahn.ApplicationProcess.July2021.Domain.Services
{
    public interface IUserAssetService
    {
        GetUserAssetByUserIdResponse GetByUserId(GetUserAssetByUserIdRequest request);
        PostUserAssetResponse Post(PostUserAssetRequest request);
        void Delete(DeleteUserAssetRequest request);
    }
}
