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
    public class PZProfileRepository : DataRepositoryBase<PZProfile, LoadzoneContext>, IPZProfileRepository
    {
        protected override System.Data.Entity.DbSet<PZProfile> DbSet(LoadzoneContext entityContext)
        {
            return entityContext.PZProfileSet;
        }

        protected override System.Linq.Expressions.Expression<Func<PZProfile, bool>> IdentifierPredicate(LoadzoneContext entityContext, int id)
        {
            return (e => e.UserID == id);
        }


        public IEnumerable<PZProfileStats> GetStats()
        {
            List<PZProfileStats> profileStats = new List<PZProfileStats>();

            using (LoadzoneContext context = new LoadzoneContext())
            {
                decimal totalUsers = (from pzprofile in context.PZProfileSet
                                      select pzprofile.UserID).Count();

                int expertiseCount = (from pzprofile in context.PZProfileSet
                                      where pzprofile.Expertise != null
                                      select pzprofile.UserID).Count();

                PZProfileStats pzProfileExpertise = new PZProfileStats
                {
                    NumberOfUsers = expertiseCount,
                    Section = "Expertise",
                    PercentCompleted = (expertiseCount / totalUsers) * 1000
                };

                profileStats.Add(pzProfileExpertise);

                int workActivitiesCount = (from pzprofile in context.PZProfileSet
                                           where pzprofile.WorkActivities != null
                                           select pzprofile.UserID).Count();

                PZProfileStats pzProfileWorkActivities = new PZProfileStats
                {
                    NumberOfUsers = workActivitiesCount,
                    Section = "Work Activities",
                    PercentCompleted = (workActivitiesCount / totalUsers) * 1000
                };

                profileStats.Add(pzProfileWorkActivities);

                int interestCount = (from pzprofile in context.PZProfileSet
                                     where pzprofile.Interests != null
                                     select pzprofile.UserID).Count();

                PZProfileStats pzProfileInterests = new PZProfileStats
                {
                    NumberOfUsers = interestCount,
                    Section = "Interests",
                    PercentCompleted = (interestCount / totalUsers) * 1000
                };

                profileStats.Add(pzProfileInterests);

                int biographyCount = (from pzprofile in context.PZProfileSet
                                      where pzprofile.Biography != null
                                      select pzprofile.UserID).Count();

                PZProfileStats pzProfileBiography = new PZProfileStats
                {
                    NumberOfUsers = biographyCount,
                    Section = "Biography",
                    PercentCompleted = (biographyCount / totalUsers) * 1000
                };

                profileStats.Add(pzProfileBiography);

                int functionCount = (from pzprofile in context.PZProfileSet
                                     where pzprofile.Title != null
                                     select pzprofile.UserID).Count();

                PZProfileStats pzProfileFunction = new PZProfileStats
                {
                    NumberOfUsers = functionCount,
                    Section = "Function",
                    PercentCompleted = (functionCount / totalUsers) * 1000
                };

                profileStats.Add(pzProfileFunction);
            }

            return profileStats;
        }

        public int GetCreatedProfiles()
        {
            int createdProfilesCount = 0;
            using(LoadzoneContext context = new LoadzoneContext())
            {
                createdProfilesCount = context.PZProfileSet.Where(e => e.LastLoggedIn != null).Select(e => e.UserID).Count();
            }

            return createdProfilesCount;
        }
    }
}
