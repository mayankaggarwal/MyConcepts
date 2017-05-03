using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.Domain
{
    public class MerchandiseConversions
    {
        public List<IntergalacticUnit> IntergalacticUnits;
        public Metal Metal { get; set; }
        public decimal ItemsValue { get; set; }
        public string Output { get; set; }

        public MerchandiseConversions()
        {
            IntergalacticUnits = new List<IntergalacticUnit>();
            Metal = null;
            ItemsValue = 0;
            Output = "";
        }
    }
}
