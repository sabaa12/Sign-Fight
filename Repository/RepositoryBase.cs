using Domain.Models.Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace Repository
{
   public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public RepositoryBase()
        {
            _dbContext = new ApplicationDbContext();
           _dbSet = _dbContext.Set<TEntity>();
        }
        public void Create(TEntity entity)
            =>
            _dbSet.Add(entity);


        public void Delete(object id)
         =>
            _dbSet.Remove(_dbSet.Find(id));

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
         =>
            _dbSet.Where(predicate);

        public IQueryable<TEntity> FindAll()
         =>
            _dbSet;

        public TEntity FindById(params object[] id)
         =>
            _dbSet.Find(id);

        public void Update(TEntity entity)
         =>
            _dbSet.Update(entity);

        public bool Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                var messe = ex.Message;
                throw;
            }
            return true;
        }
    }
}
