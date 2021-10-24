using Hahn.ApplicationProcess.July2021.Domain.Models;

namespace Hahn.ApplicationProcess.July2021.Domain.Services
{
    public interface IUserService
    {
        GetUserResponse Get();
        PostUserResponse Post(PostUserRequest request);
        void Put(PutUserRequest request);
        void Delete(DeleteUserRequest request);
    }
}
