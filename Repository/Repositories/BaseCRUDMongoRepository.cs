using MongoDB.Bson;
using MongoDB.Driver;
using Repository.Database;

namespace Repository.Repositories
{
    public abstract class BaseCRUDMongoRepository<TEntity> : IBaseCRUDRepository<TEntity>
        where TEntity : class
    {
        protected IMongoDbContext _DbContext;

        protected IMongoDatabase _Database;

        protected IMongoCollection<TEntity> _Table;

        public BaseCRUDMongoRepository(IMongoDbContext mongoDbContext)
        {
            _DbContext = mongoDbContext;
            _Database = mongoDbContext.Database;
            _Table = _Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual TEntity Create(TEntity entity, bool autoSave = true)
        {
            _Table.InsertOne(entity);
            return entity;
        }

        public virtual void Delete(TEntity entity, bool autoSave = true)
        {
            var id = entity.ToBsonDocument()["_id"].ToString();
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            _Table.DeleteOne(filter);
        }


        public virtual TEntity FindById(object id)
        {
            BsonDocument document = new BsonDocument("_id", BsonValue.Create(ObjectId.Parse(id.ToString())));
            var entity = _Table.Find(document).FirstOrDefault();
            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _Table.Find(x => true).ToList().AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAllPaging(int pageIndex, int pageSize)
        {
            return GetAll().Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public virtual TEntity Update(TEntity entity, bool autoSave = true)
        {
            var id = entity.ToBsonDocument()["_id"].ToString();
            var filter = Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id));
            _Table.ReplaceOne(filter, entity);
            return entity;
        }
    }
}
