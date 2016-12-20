using IDW.Data.OneDIR;
using IDW.Data.GIR;
using IDW.Data.Membership;
using IDW.Entities.GIR;
using IDW.Entities.Membership;
using IDW.Entities.OneDIR;
using IDW.Entities.Plazza;
using IDW.Entities.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDW.Data.Plazza;

namespace IDW.Data
{
    public class IDWContext:DbContext
    {
        public IDWContext():base("queryzoneconn")
        {
            Database.SetInitializer<IDWContext>(null);
        }

        #region Entity Sets

        public IDbSet<GIR_Identity> GIRIdentitySet { get; set; }
        public IDbSet<OD_Identity> ODIdentitySet { get; set; }
        public IDbSet<OD_Entity> ODEntitySet { get; set; }
        public IDbSet<UserProfile> UserProfileSet { get; set; }
        public IDbSet<UserActivity> UserActivitySet { get; set; }
        public IDbSet<SocialGroup> SocialGroupSet { get; set; }
        public IDbSet<UserExpertize> UserExpertiseSet { get; set; }
        public IDbSet<PlazzaBlog> PlazzaBlogSet { get; set; }
        public IDbSet<PlazzaCommunity> PlazzaCommunitySet { get; set; }
        public IDbSet<PlazzaGroupMember> PlazzaGroupMember { get; set; }
        public IDbSet<PlazzaUserRelation> PlazzaUserRelation { get; set; }
        public IDbSet<StatusLevelPoint> StatusLevelPointSet { get; set; }
        public IDbSet<ObjectTag> ObjectTagSet { get; set; }
        public IDbSet<ProjectDetails> ProjectDetailsSet { get; set; }
        public IDbSet<ProfileHistory> ProfileHistorySet { get; set; }
        public IDbSet<User> UserSet { get; set; } 
        public IDbSet<Role> RoleSet { get; set; } 
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }

        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new GIRIdentityConfiguration());
            modelBuilder.Configurations.Add(new ODIdentityConfiguration());
            modelBuilder.Configurations.Add(new ODEntityConfiguration());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
            modelBuilder.Configurations.Add(new UserActivityConfiguration());
            modelBuilder.Configurations.Add(new SocialGroupConfiguration());
            modelBuilder.Configurations.Add(new UserExpertizeConfiguration());
            modelBuilder.Configurations.Add(new ProjectDetailsConfiguration());
            modelBuilder.Configurations.Add(new PlazzaBlogConfiguration());
            modelBuilder.Configurations.Add(new PlazzaCommunityConfiguration());
            modelBuilder.Configurations.Add(new PlazzaGroupMemberConfiguration());
            modelBuilder.Configurations.Add(new PlazzaUserRelationConfiguration());
            modelBuilder.Configurations.Add(new ProfileHistoryConfiguration());
            modelBuilder.Configurations.Add(new ObjectTagConfiguration());
        }
    }
}
