using EnterpriseApp.Models;
using EnterpriseApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Data
{
    public class DataRepository<TEntity>:IDataRepository<TEntity> where TEntity:BaseEntity
    {
        private readonly IDbContext _context;
        private readonly IDbSet<TEntity> _dbEntitySet;
        private bool _disposed;

        public DataRepository(IDbContext context)
        {
            _context = context;
            _dbEntitySet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public TEntity GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
