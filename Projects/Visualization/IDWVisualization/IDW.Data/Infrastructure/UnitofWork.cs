using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Data.Infrastructure
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private IDWContext dbContext;

        public UnitofWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public IDWContext DbContext
        {
            get { return dbContext ?? (dbContext = this.dbFactory.Init()); }
        }

        public void Commit()
        {
            this.dbContext.Commit();
        }
    }
}
