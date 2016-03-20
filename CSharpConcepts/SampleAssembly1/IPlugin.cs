using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAssembly1
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        bool Load(string myApplication);
    }
}
