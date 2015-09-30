using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public abstract class GameObject
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public GameObject(int row, int col) 
        {
            
        }
    }
}
