using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.Domain
{
    public class RomanIntegerRepresentation
    {
        public string RomanRepresentation { get; set; }
        public int IntegerRepresentation { get; set; }

        public RomanIntegerRepresentation(string romanRepresentation)
        {
            this.RomanRepresentation = romanRepresentation;
        }
    }
}
