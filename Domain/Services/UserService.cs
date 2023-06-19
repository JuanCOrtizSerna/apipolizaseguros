using AutoMapper;
using Common.Models;
using Microsoft.Extensions.Configuration;
using Repository.Entities;
using Repository.Repositories;

namespace Domain.Services
{
    public class UserService : BaseService<UserDTO, User>, IUserService
    {
        IUserRepository UserRepository;

        public UserService(
            IBaseCRUDRepository<User> repository,
            IMapper mapper,
            IConfiguration configuration,
            IUserRepository userRepository
            )
            : base(repository, mapper, configuration)
        {
            UserRepository = userRepository;
        }

        public UserDTO FindUserByEmail(string email)
        {
            return _mapperDependency.Map<UserDTO>(UserRepository.FindUserByEmail(email));
        }
    }
}
