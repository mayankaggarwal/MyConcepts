using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDWVisualization.Core;
using IDWVisualization.DataAccessLayer.Entities;
using IDWVisualization.DataAccessLayer.RepositoryInterfaces;

namespace IDWVisualization.DataAccessLayer.Repositories
{
    public class EntityCountryRepository : DataRepositoryBase<EntityCountry,LoadzoneContext>,IEntityCountry
   {

       public EntityCountry Get(string entityName)
       {
           using (LoadzoneContext context = new LoadzoneContext())
           {
               return context.EntityCountrySet.Where(e => e.Entity.Equals(entityName)).FirstOrDefault();
           }
       }

       // public override IEnumerable<EntityCountry> Get()
       //{
       //     using(LoadzoneContext context = new LoadzoneContext())
       //     {
       //         return context.EntityCountrySet.ToFullyLoaded();
       //     }
       //}

       protected override DbSet<EntityCountry> DbSet(LoadzoneContext entityContext)
       {
           return entityContext.EntityCountrySet;
       }

       protected override System.Linq.Expressions.Expression<Func<EntityCountry, bool>> IdentifierPredicate(LoadzoneContext entityContext, int id)
       {
           return (e => e.ID == id);
       }
   }
}
