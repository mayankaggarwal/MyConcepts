using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.Domain
{
    public class MerchantNotebook
    {
        private static MerchantNotebook _Instance;
        private static object syncRoot = new Object();
        internal static MerchantNotebook Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_Instance == null)
                            _Instance = new MerchantNotebook();
                    }
                }
                return _Instance;
            }
        }

        private MerchantNotebook()
        {
            IntergalacticUnits = new List<IntergalacticUnit>();
            Metals = new List<Metal>();
            merchandiseConversions = new List<MerchandiseConversions>();
        }

        internal List<IntergalacticUnit> IntergalacticUnits;
        internal List<Metal> Metals;
        internal List<MerchandiseConversions> merchandiseConversions;
    }
}
