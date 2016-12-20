using IDWVisualization.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDWVisualization.DataAccessLayer.RepositoryInterfaces
{
    public interface IPZProfileRepository
    {
        PZProfile Get(int ProfileID);
        IEnumerable<PZProfile> Get();
        IEnumerable<PZProfileStats> GetStats();
        Int32 GetCreatedProfiles();
    }
}
