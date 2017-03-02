using EnterpriseApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Data
{
    public class EnterpriseAppDbContext:DbContext,IDbContext
    {
        private DbTransaction _transaction;
        private static readonly object Lock = new object();
        private static bool _databaseInitialized;

        public EnterpriseAppDbContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
            if (_databaseInitialized)
            {
                return;
            }
            lock (Lock)
            {
                if (!_databaseInitialized)
                {
                    Database.SetInitializer(new EnterpriseAppInitializer());
                    _databaseInitialized = true;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Models.BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : Models.BaseEntity
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : Models.BaseEntity
        {
            UpdateEntityState(entity, EntityState.Modified);
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : Models.BaseEntity
        {
            UpdateEntityState(entity, EntityState.Deleted);
        }

        public void BeginTransaction()
        {
            if (this.Database.Connection.State == ConnectionState.Open)
            {
                return;
            }
            this.Database.Connection.Open();
            _transaction = this.Database.Connection.BeginTransaction();
        }

        public int Commit()
        {
            try
            {
                BeginTransaction();
                var saveChanges = SaveChanges();
                _transaction.Commit();

                return saveChanges;
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                BeginTransaction();
                var saveChangesAsync = await SaveChangesAsync();
                _transaction.Commit();

                return saveChangesAsync;
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        private void UpdateEntityState<TEntity>(TEntity entity, EntityState entityState) where TEntity : BaseEntity
        {
            var dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = entityState;
        }

        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var dbEntityEntry = Entry<TEntity>(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }
    }
}
