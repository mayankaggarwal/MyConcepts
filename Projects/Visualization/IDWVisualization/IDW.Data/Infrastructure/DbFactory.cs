using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Data.Infrastructure
{
    public class DbFactory:Disposable,IDbFactory
    {
        IDWContext dbContext;
        public IDWContext Init()
        {
            return dbContext ?? (dbContext = new IDWContext());
        }

        protected override void DisposeCore()
        {
            if(dbContext!=null)
            {
                dbContext.Dispose();
            }
        }
    }
}
