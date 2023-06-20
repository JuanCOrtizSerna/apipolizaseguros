using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Repository.Database
{
    public class DbContext : IMongoDbContext
    {
        public IMongoDatabase Database { get; private set; }

        public IMongoClient Client { get; private set; }

        public DbContext(IOptions<MongoSettings> settings, IMongoClient client)
        {
            MongoDefaults.MaxConnectionIdleTime = TimeSpan.FromSeconds(settings.Value.MaxConnectionIdleTime);
            MongoDefaults.SocketTimeout = TimeSpan.FromSeconds(settings.Value.SocketTimeout);
            MongoDefaults.ConnectTimeout = TimeSpan.FromSeconds(settings.Value.ConnectTimeout);
            this.Client = client;
            Database = Client.GetDatabase(settings.Value.Database);
        }
    }
}
