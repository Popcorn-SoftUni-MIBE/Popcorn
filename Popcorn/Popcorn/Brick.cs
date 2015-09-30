using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
<<<<<<< HEAD
    public class Brick : GameObject
    {
        public const int STENGHT = 1;
        public const char brick = '=';
=======
   public class Brick : GameObject, IDestructableObject
   {
       public const int STENGHT = 1;
>>>>>>> origin/master

        public int Size { get; set; }

        public virtual int GetBonus()
        {
            throw new NotImplementedException();
        }
    }


}
