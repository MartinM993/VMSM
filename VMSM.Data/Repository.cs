using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Interfaces;

namespace VMSM.Data
{
    public class Repository <TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext: VMSMDbContext
    {
        protected readonly TContext _context;

        public Repository(TContext context)
        {
           this._context = context;
        }

        public TEntity Get(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return _context.Set<TEntity>().Attach(entity).Entity;
        }

        public void Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);

            if(entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
