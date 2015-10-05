using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public class SpecialBonusBrick : Brick
    {
        private const char symbolForPrinting = '=';
        public override char GetCharOfObject()
        {
            return symbolForPrinting;
        }
    }
}
