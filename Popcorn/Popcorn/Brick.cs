using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
   public class Brick : GameObject
   {
       public const int STENGHT = 1;

        public int Size { get; set; }
        
        public virtual int GetBonus()
        {
            throw new NotImplementedException();
        }

    }
}
