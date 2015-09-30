using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    class Wall : GameObject, IIndestructableObject
    {
        public char Symbol { get; set; }
    }
}
