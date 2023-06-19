using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.Repositories;

namespace Domain.Services
{
    public abstract class BaseService<TDTO, TEntity> : IBaseService<TDTO>
        where TDTO : class
        where TEntity : class
    {

        public IBaseCRUDRepository<TEntity> _repository;

        public IMapper _mapperDependency;

        public IConfiguration _configuration;

        public BaseService(
            IBaseCRUDRepository<TEntity> repository, 
            IMapper mapper, 
            IConfiguration configuration
            )
        {
            _repository = repository;
            _mapperDependency = mapper;
            _configuration = configuration;
        }

        #region CRUD

        public virtual TDTO Create(TDTO dto, bool autoSave = true)
        {
            TEntity entity = _mapperDependency.Map<TEntity>(dto);

            entity = _repository.Create(entity, autoSave);

            return _mapperDependency.Map<TDTO>(entity);
        }

        public virtual void Delete(object id, bool autoSave = true)
        {
            TEntity entity = _repository.FindById(id);

            _repository.Delete(entity, autoSave);
        }

        public virtual TDTO FindById(object Id)
        {
            var result = _repository.FindById(Id);
            return _mapperDependency.Map<TDTO>(result);
        }

        public virtual TDTO Update(TDTO dto, bool autoSave = true)
        {
            TEntity entity = _mapperDependency.Map<TEntity>(dto);

            entity = _repository.Update(entity, autoSave);

            return _mapperDependency.Map<TDTO>(entity);
        }

        public virtual IEnumerable<TDTO> GetAll()
        {
            List<TDTO> list = _mapperDependency.Map<List<TDTO>>(_repository.GetAll());

            return list;
        }

        #endregion
    }
}