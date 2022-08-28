using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoBlazorphic.Extensions.BaseTypes
{
    public static class NumberExtensions
    {
        public static string ToInvariantString(this double num, int amountOfDigit = 2)
        {
            var format = "0." + new string ('0', amountOfDigit);

            return num.ToString(format, System.Globalization.CultureInfo.InvariantCulture);
        }
        
    }
}
