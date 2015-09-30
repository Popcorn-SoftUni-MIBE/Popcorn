using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public abstract class GameObject
    {
        private char Symbol { get; set; }
        public char GetCharOfObject()
        {
            return this.Symbol;
        }
    }
}
