using EnterpriseApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();

        void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void BeginTransaction();
        int Commit();
        Task<int> CommitAsync();
        void Rollback();

        void Dispose();
    }
}
