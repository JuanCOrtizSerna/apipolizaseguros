
namespace Repository.Repositories
{

    public interface IBaseCRUDRepository<T> 
    {
        T Create(T entity, bool autoSave = true);

        void Delete(T entity, bool autoSave = true);

        T FindById(object id);

        IQueryable<T> GetAll();

        T Update(T entity, bool autoSave = true);
    }
}
