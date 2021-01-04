using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace Repository
{
    class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(params object[] id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
