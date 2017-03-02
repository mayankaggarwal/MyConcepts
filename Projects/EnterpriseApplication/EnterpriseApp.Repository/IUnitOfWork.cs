using EnterpriseApp.Models;
using EnterpriseApp.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Repository
{
    public interface IUnitOfWork
    {
        IDataRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        void BeginTransaction();

        int Commit();

        Task<int> CommitAsync();

        void Rollback();

        void Dispose(bool disposing);
    }
}
