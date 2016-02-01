using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UsersManager_v02_DAL.DbConnection;

namespace UsersManager_v02_BL.DesignPatternHelpers
{
    [NotMapped]
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DatabaseContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(DatabaseContext Context)
        {
            this.Context = Context;
            this.DbSet = Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> Filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null,
            string IncludeProperties = "")
        {
            IQueryable<TEntity> Query = DbSet;

            if (Filter != null)
            {
                Query = Query.Where(Filter);
            }

            foreach (var includeProperty in IncludeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Query = Query.Include(includeProperty);
            }

            if (OrderBy != null)
            {
                return OrderBy(Query); //.ToList();
            }
            else
            {
                return Query; //.ToList();
            }
        }

        public virtual TEntity GetByID(object Id)
        {
            return DbSet.Find(Id);
        }

        public virtual void Insert(TEntity Entity)
        {
            DbSet.Add(Entity);
        }

        public virtual void Delete(object Id)
        {
            TEntity EntityToDelete = DbSet.Find(Id);
            Delete(EntityToDelete);
        }

        public virtual void Delete(TEntity EntityToDelete)
        {
            if (Context.Entry(EntityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(EntityToDelete);
            }
            DbSet.Remove(EntityToDelete);
        }

        public virtual void Update(TEntity EntityToDelete)
        {
            DbSet.Attach(EntityToDelete);
            Context.Entry(EntityToDelete).State = EntityState.Modified;
        }
    }
}
