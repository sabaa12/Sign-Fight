using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Data.Interfaces.Repositories
{
   public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(params object[] id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        bool Save();
    }
}
