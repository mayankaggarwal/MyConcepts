using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OperaWebSites.Models
{
    public class OperasInitializer:DropCreateDatabaseAlways<OperaDB>
    {
        protected override void Seed(OperaDB context)
        {
            var operas = new List<Opera>{
                new Opera{
                    Title = "Cosi Fan Tutte",
                    Year = 1960,
                    Composer = "Mozart"
                }
            };

            operas.ForEach(s => context.Operas.Add(s));
            context.SaveChanges();
        }
    }
}