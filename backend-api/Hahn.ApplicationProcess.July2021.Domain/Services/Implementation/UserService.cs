using System.Linq;
using Hahn.ApplicationProcess.July2021.Data.DataContext;
using Hahn.ApplicationProcess.July2021.Data.Implementations;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Delete;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Get;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.GetById;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Post;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Put;
using Hahn.ApplicationProcess.July2021.Domain.Models.UserAsset.Post;
using Hahn.ApplicationProcess.July2021.Domain.Services.Interfaces;

namespace Hahn.ApplicationProcess.July2021.Domain.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly GenericRepository<User> _repository;

        public UserService(ApplicationProcessDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
            _repository = _unitOfWork.UserRepository;
        }

        public GetUserResponse Get()
        {
            var response = new GetUserResponse
            {
                Users = _repository.Get()
                    .Select(a => new GetUserResponse.UserModel
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Age = a.Age,
                        Email = a.Email,
                        Street = a.Street,
                        PostalCode = a.PostalCode,
                        HouseNumber = a.HouseNumber
                    }).ToList()
            };

            return response;
        }

        public PostUserResponse Post(PostUserRequest request)
        {
            var result = _repository.Insert(new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Email = request.Email,
                PostalCode = request.PostalCode,
                Street = request.Street,
                HouseNumber = request.HouseNumber
            });

            _unitOfWork.Save();

            return new PostUserResponse { UserId = result.Id };
        }

        public void Put(PutUserRequest request)
        {
            _repository.Update(new User
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Email = request.Email,
                Street = request.Street,
                PostalCode = request.PostalCode,
                HouseNumber = request.HouseNumber
            });
            
            _unitOfWork.Save();
        }

        public void Delete(DeleteUserRequest request)
        {
            _repository.Delete(request.Id);

            _unitOfWork.Save();
        }
    }
}
