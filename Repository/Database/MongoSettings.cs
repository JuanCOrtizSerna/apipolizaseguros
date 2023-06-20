
namespace Repository.Database
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public int MaxConnectionIdleTime { get; set; }
        public int SocketTimeout { get; set; }
        public int ConnectTimeout { get; set; }
    }
}
