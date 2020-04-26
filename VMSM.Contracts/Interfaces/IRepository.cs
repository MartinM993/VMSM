using System.Collections.Generic;

namespace VMSM.Contracts.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(object id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void Save();
    }
}
