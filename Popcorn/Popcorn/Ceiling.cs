using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    class Ceiling: GameObject
    {
        public const bool isDestroyable = false;
        private const char symbol = '-';
        public override char GetCharOfObject()
        {
            return symbol;
        }
    }
}
