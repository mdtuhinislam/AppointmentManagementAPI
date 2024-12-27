using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppoinmentManagementAPI.Application.Interfaces.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AppoinmentManagementAPI.Application.Services.Base
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _db;

        public BaseRepository(DbContext db)
        {
            _db = db;
        }

        private DbSet<TEntity> Table => _db.Set<TEntity>();

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            Table.Add(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public async virtual Task<bool> Update(TEntity entity)
        {
            Table.Update(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public async virtual Task<bool> Delete(TEntity entity)
        {
           
            Table.Remove(entity);
           
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
