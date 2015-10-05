using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public class Board : GameObject
    {
        public const bool isDestroyable = false;
        public int Size { get; set; }
        private const char symbol = '*';
        public int Row { get; private set; }
        public int Col { get; set; }

        public override bool IsDestroyable
        {
            get
            {
                return false;
            }
        }

        public Board(int row, int col, int size = 4)
        {
            this.Row = row;
            this.Col = col;
            this.Size = size;
        }

        public override char GetCharOfObject()
        {
            return symbol;
        }
    }
}
