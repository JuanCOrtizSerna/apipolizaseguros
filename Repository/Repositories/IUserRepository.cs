using Repository.Entities;

namespace Repository.Repositories
{
    public interface IUserRepository : IBaseCRUDRepository<User>
    {
        User FindUserByEmail(string email);
    }
}
