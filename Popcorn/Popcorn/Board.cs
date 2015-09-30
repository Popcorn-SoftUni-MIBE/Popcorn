using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public class Board : GameObject
    {
        public int Size { get; set; }
        public const char board = '_';
        public Board(int row, int col, int size = 6)
            : base(row, col)
        {
            this.Size = size;
        }
    }
}
