using ContosoUniversity.Domain;
using ContosoUniversity.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext context;
        private readonly IDbSet<TEntity> dbSet;
        private bool _disposed;

        public DataRepository(IDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);

            foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query.Include(property);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            context.SetAsAdded<TEntity>(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entity = GetByID(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            context.SetAsDeleted<TEntity>(entity);
        }

        public virtual void Update(TEntity entity)
        {
            context.SetAsModified<TEntity>(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                context.Dispose();
            }
            _disposed = true;
        }
    }
}
