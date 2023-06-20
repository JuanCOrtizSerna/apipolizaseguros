
namespace Domain.Services
{
    public interface IBaseService<TDTO>
        where TDTO : class
    {
        TDTO Create(TDTO dto, bool autoSave = true);
        
        void Delete(object id, bool autoSave = true);
        
        TDTO FindById(object Id);
        
        TDTO Update(TDTO dto, bool autoSave = true);
        
        IEnumerable<TDTO> GetAll();
    }
}
