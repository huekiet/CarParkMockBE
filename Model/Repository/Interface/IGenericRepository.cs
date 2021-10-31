using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model.Repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        IQueryable<TEntity> FindAll();
        IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetById(long id);
        Task<TEntity> GetById(string id);

        Task Create(TEntity entity);
        Task Delete(long id);
        Task Delete(string id);

        DbSet<TEntity> GetDbSet();
        Task Save();
        void SaveChanges();
        Task Update(TEntity entity);
        Task UpdateRange(IEnumerable<TEntity> entities);

    }
}
