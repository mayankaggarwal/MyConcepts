using ExpenseManager.Core;
using ExpenseManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Data.RepositoryInterface
{
    public interface IUserRepository:IDataRepository<ExpenseUser>
    {
    }
}
