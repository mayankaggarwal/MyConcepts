﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.RomanConversion
{
    public class ThousandSymbol: SymbolRepresentation
    {
        public ThousandSymbol()
        {
            symbolValues.Add("M", 1000);
        }
    }
}
