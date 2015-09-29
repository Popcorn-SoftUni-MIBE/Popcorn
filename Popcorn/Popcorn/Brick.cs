using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
   public class Brick
    {
        public int Size { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public const int Strenght = 1;
        public virtual int GetBonus();
    }
}
