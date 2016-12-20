using IDWVisualization.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDWVisualization.DataAccessLayer
{
    public class LoadzoneContext:DbContext
    {
        public LoadzoneContext()
            : base("name=main")
        {
            Database.SetInitializer<LoadzoneContext>(null);
        }

        public DbSet<EntityCountry> EntityCountrySet { get; set; }
        public DbSet<PZProfile> PZProfileSet { get; set; }
        public DbSet<PZActivity> PZActivitySet { get; set; }
        public DbSet<SocialGroup> PZSocialGroupSet { get; set; }
    }
}
