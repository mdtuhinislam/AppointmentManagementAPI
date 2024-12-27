using AppoinmentManagementAPI.Application.Interfaces.Repository.Base;
using AppointmentManagementAPI.Application.Interfaces.Services.Base;

namespace AppointmentManagementAPI.Application.UseCases.Base
{
    public class BaseService<TEntity>:IService<TEntity> where TEntity : class
    {
        IRepository<TEntity> _repository;
        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            return await _repository.Add(entity);
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            return await _repository.Delete(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            return await _repository.Update(entity);
        }
    }
}
