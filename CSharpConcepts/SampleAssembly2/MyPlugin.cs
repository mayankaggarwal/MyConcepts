using SampleAssembly1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAssembly2
{
    public class MyPlugin : IPlugin
    {
        public string Description
        {
            get
            {
                return "MyPlugin";
            }
        }

        public string Name
        {
            get
            {
                return "My Sample Plugin";
            }
        }

        public bool Load(string myApplication)
        {
            return true;
        }
    }
}
