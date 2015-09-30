using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public class Brick
    {
        public const int STENGHT = 2;
        public const char brick = '=';
        public int Size { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public virtual int GetBonus()
        {
            throw new NotImplementedException();
        }

        public Brick(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
