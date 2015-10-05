using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public class SpecialBonusBrick : Brick, IDestroyable
    {
        private const char symbolForPrinting = '=';
        public new const bool isDestroyable = true;
        public override char GetCharOfObject()
        {
            return symbolForPrinting;
        }
    }
}
