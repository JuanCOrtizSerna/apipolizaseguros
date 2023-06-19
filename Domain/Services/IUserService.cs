using Common.Models;

namespace Domain.Services
{
    public interface IUserService : IBaseService<UserDTO>
    {
        UserDTO FindUserByEmail(string email);
    }
}
