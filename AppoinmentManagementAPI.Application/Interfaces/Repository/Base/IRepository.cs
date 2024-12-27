namespace AppoinmentManagementAPI.Application.Interfaces.Repository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
}
