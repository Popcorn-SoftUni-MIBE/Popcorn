using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public class Ball : GameObject
    {
        public const char ballSymbol = '@';

        public Ball(int row, int col)
            : base(row, col)
        {

        }
    }
}
