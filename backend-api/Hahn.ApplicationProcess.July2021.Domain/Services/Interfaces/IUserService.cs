using Hahn.ApplicationProcess.July2021.Domain.Models.User.Delete;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Get;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.GetById;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Post;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Put;

namespace Hahn.ApplicationProcess.July2021.Domain.Services.Interfaces
{
    public interface IUserService
    {
        GetUserResponse Get();
        PostUserResponse Post(PostUserRequest request);
        void Put(PutUserRequest request);
        void Delete(DeleteUserRequest request);
    }
}
