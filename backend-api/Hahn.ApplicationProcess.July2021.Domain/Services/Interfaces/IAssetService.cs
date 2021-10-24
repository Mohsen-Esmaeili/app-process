using Hahn.ApplicationProcess.July2021.Domain.Models;

namespace Hahn.ApplicationProcess.July2021.Domain.Services
{
    public interface IAssetService
    {
        GetAssetResponse Get();
        PostAssetResponse Post(PostAssetRequest request);
        void Put(PutAssetRequest request);
        void Delete(DeleteAssetRequest request);
    }
}
