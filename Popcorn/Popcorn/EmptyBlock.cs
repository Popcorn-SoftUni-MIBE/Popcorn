using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    class EmptyBlock : GameObject
    {
        public const bool isDestroyable = false;
        private const char symbolForPrinting = ' ';

        public override bool IsDestroyable
        {
            get
            {
                return false;
            }
        }

        public override char GetCharOfObject()
        {
            return symbolForPrinting;
        }
    }
}
