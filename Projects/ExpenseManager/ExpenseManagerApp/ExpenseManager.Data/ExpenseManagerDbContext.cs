using ExpenseManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Data
{
    public class ExpenseManagerDbContext : DbContext
    {
        public ExpenseManagerDbContext()
            : base("SqlConn")
        {
            Database.SetInitializer<ExpenseManagerDbContext>(null);
        }

        public DbSet<ExpenseUser> ExpenseUserSet { get; set; }

    }
}
