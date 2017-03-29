using ContosoUniversity.Domain;
using ContosoUniversity.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(IDbContext context)
        {
            this._context = context;
        }

        public IDataRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IDataRepository<TEntity>)_repositories[type];
            }

            var repositoryType = typeof(DataRepository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));
            return (IDataRepository<TEntity>)_repositories[type];
        }

        public void BeginTransaction()
        {
            this._context.BeginTransaction();
        }

        public int Commit()
        {
            return this._context.Commit();
        }

        public Task<int> CommitAsync()
        {
            return this._context.CommitAsync();
        }

        public void Rollback()
        {
            this._context.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
                foreach (IDisposable repository in _repositories.Values)
                {
                    repository.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
