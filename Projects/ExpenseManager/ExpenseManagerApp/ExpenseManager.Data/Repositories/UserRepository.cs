using ExpenseManager.Core;
using ExpenseManager.Data.Entities;
using ExpenseManager.Data.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Data.Repositories
{
    public class UserRepository:DataRepositoryBase<ExpenseUser,ExpenseManagerDbContext>,IUserRepository
    {

        protected override System.Data.Entity.DbSet<ExpenseUser> DbSet(ExpenseManagerDbContext entityContext)
        {
            return entityContext.ExpenseUserSet;
        }

        protected override System.Linq.Expressions.Expression<Func<ExpenseUser, bool>> IdentifierPredicate(ExpenseManagerDbContext entityContext, int id)
        {
            return (e => e.ID == id);
        }
    }
}
