using IDWVisualization.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDWVisualization.DataAccessLayer.RepositoryInterfaces
{
    public interface IEntityCountry
    {
        EntityCountry Get(string entityName);
        IEnumerable<EntityCountry> Get();
    }
}
