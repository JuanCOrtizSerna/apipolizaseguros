using MongoDB.Driver;

namespace Repository.Database
{
    public interface IMongoDbContext
    {
        IMongoDatabase Database { get; }
        IMongoClient Client { get; }
    }
}
