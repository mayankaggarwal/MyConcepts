using IDWVisualization.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDWVisualization.DataAccessLayer.RepositoryInterfaces
{
    public interface IPZActivityRepository
    {
        
        PZActivity Get(int ActivityID);
        IEnumerable<PZActivity> Get();
        Int32 GetActiveIdentitiesCount(string lastDate);
        Int32 GetViewCommunities();
        Int32 GetAverageActivites(string lastDate);
    }
}
