using EnterpriseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Repository.Repositories
{

    public interface IDataRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
