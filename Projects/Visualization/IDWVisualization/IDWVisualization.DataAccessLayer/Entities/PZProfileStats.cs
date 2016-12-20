using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDWVisualization.DataAccessLayer.Entities
{
    public class PZProfileStats
    {
        public int NumberOfUsers { get; set; }
        public string Section { get; set; }
        public decimal PercentCompleted { get; set; }
    }
}
