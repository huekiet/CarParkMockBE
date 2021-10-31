using CoreApp.Model;
using CoreApp.Model.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.Repository
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
    {
        private CarParkDbContext _dbContext;

        public GenericRepository(CarParkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected CarParkDbContext DbContext
        {
            get { return _dbContext ?? (_dbContext = new CarParkDbContext()); }
        }

        public async Task Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public async Task Delete(long id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task Delete(string id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public DbSet<TEntity> GetDbSet()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> FindAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }


        public async Task<TEntity> GetById(long id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
        }

    }
}
