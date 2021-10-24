using Hahn.ApplicationProcess.July2021.Domain.Models.Asset.Delete;
using Hahn.ApplicationProcess.July2021.Domain.Models.Asset.Get;
using Hahn.ApplicationProcess.July2021.Domain.Models.Asset.Post;
using Hahn.ApplicationProcess.July2021.Domain.Models.Asset.Put;

namespace Hahn.ApplicationProcess.July2021.Domain.Services.Interfaces
{
    public interface IAssetService
    {
        GetAssetResponse Get();
        PostAssetResponse Post(PostAssetRequest request);
        void Put(PutAssetRequest request);
        void Delete(DeleteAssetRequest request);
    }
}
