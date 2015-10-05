using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public class Brick : GameObject
    {
        private const char symbol = '#';
        public const int STENGHT = 1;
        
        public int Size { get; set; }

        public override bool IsDestroyable
        {
            get
            {
                return true;
            }
        }

        public override char GetCharOfObject()
        {
            return symbol;
        }
    }

}
