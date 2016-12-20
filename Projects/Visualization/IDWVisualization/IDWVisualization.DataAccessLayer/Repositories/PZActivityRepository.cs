using IDWVisualization.Core;
using IDWVisualization.DataAccessLayer.Entities;
using IDWVisualization.DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDWVisualization.DataAccessLayer.Repositories
{
    public class PZActivityRepository : DataRepositoryBase<PZActivity, LoadzoneContext>, IPZActivityRepository
    {
        protected override System.Data.Entity.DbSet<PZActivity> DbSet(LoadzoneContext entityContext)
        {
            return entityContext.PZActivitySet;
        }

        protected override System.Linq.Expressions.Expression<Func<PZActivity, bool>> IdentifierPredicate(LoadzoneContext entityContext, int id)
        {
            return (e => e.ActivityID == id);
        }


        public int GetActiveIdentitiesCount(string lastDate)
        {
            int totalActiveIdentities = 0;
            DateTime selectDate = DateTime.Parse(lastDate).AddMonths(-1).Date;
            using(LoadzoneContext context = new LoadzoneContext())
            {
                totalActiveIdentities = context.PZActivitySet
                    .Where(e => e.CreationDate >= selectDate)
                    .Select(e => e.UserID)
                    .Distinct()
                    .Count();
            }

            return totalActiveIdentities;
        }

        public int GetViewCommunities()
        {
            int viewCommunities = 0;
            using(LoadzoneContext context = new LoadzoneContext())
            {
                viewCommunities = context.PZActivitySet
                    .Where(e => e.ActivityType.Equals("viewed", StringComparison.CurrentCultureIgnoreCase) && e.ContainerType.Equals("socialgroup", StringComparison.CurrentCultureIgnoreCase))
                    .Select(e => e.ActivityID)
                    .Count();
            }

            return viewCommunities;
        }

        public int GetAverageActivites(string lastDate)
        {
            int viewCommunities = 0;
            DateTime selectDate = DateTime.Parse(lastDate).AddDays(-7).Date;
            using (LoadzoneContext context = new LoadzoneContext())
            {
                viewCommunities = (context.PZActivitySet
                    .Where(e => e.ActivityType.Equals("viewed", StringComparison.CurrentCultureIgnoreCase) && e.CreationDate >= selectDate)
                    .Select(e => e.ActivityID)
                    .Count())/7;
            }

            return viewCommunities;
        }
    }
}
