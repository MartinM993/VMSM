using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VMSM.Contracts.Entities;
using VMSM.Contracts.Interfaces;

namespace VMSM.Data
{
    public class Repository <TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly VMSMDbContext _context;

        public Repository(VMSMDbContext context)
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
            Type entityType = typeof(TEntity);

            if (entityType.Name.Equals(nameof(AppUser)))
            {
                _context.Entry<TEntity>(entity).State = EntityState.Deleted;
                var dbEntity = _context.Set<TEntity>().Attach(entity).Entity;
                _context.Entry(entity).State = EntityState.Modified;
                return dbEntity;
            }
            else
            {
                var dbEntity = _context.Set<TEntity>().Attach(entity).Entity;
                _context.Entry(entity).State = EntityState.Modified;
                return dbEntity;
            }
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
