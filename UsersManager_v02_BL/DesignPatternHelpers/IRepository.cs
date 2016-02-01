using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UsersManager_v02_BL.DesignPatternHelpers
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> Filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null, string IncludeProperties = "");
        TEntity GetByID(object Id);
        void Insert(TEntity Entity);
        void Delete(object Id);
        void Delete(TEntity EntityToDelete);
        void Update(TEntity EntityToUpdate);
    }
}
