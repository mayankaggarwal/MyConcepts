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
    public class PZSocialGroupRepository : DataRepositoryBase<SocialGroup, LoadzoneContext>, IPZSocialGroupRepository
    {
        protected override System.Data.Entity.DbSet<SocialGroup> DbSet(LoadzoneContext entityContext)
        {
            return entityContext.PZSocialGroupSet;
        }

        protected override System.Linq.Expressions.Expression<Func<SocialGroup, bool>> IdentifierPredicate(LoadzoneContext entityContext, int id)
        {
            return (e => e.GroupID == id);
        }


        public int GetTotalCount()
        {
            int totalCommunities = 0;
            using (LoadzoneContext context = new LoadzoneContext())
            {
                totalCommunities = context.PZSocialGroupSet.Count();                   
            }

            return totalCommunities;
        }
    }
}
