using Repository.Database;
using Repository.Entities;
using MongoDB.Driver;

namespace Repository.Repositories
{
    public class UserRepository : BaseCRUDMongoRepository<User>, IUserRepository
    {
        public DbContext Context
        {
            get
            {
                return (DbContext)_Database;
            }
        }

        public UserRepository(IMongoDbContext dbContext)
            : base(dbContext)
        {
        }

        public User FindUserByEmail(string email)
        {
            var filter = Builders<User>.Filter.Eq("Email", email);

            var user = _Table.Find(filter).FirstOrDefault();

            return user;
        }
    }
}
