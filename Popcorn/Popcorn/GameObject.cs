using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public abstract class GameObject 
    {
        public abstract bool IsDestroyable { get;}
        abstract public char GetCharOfObject();
    }
}
