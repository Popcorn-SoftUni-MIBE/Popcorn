using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popcorn
{
    public class SpecialBonusBrick: Brick
    {
        public SpecialBonusBrick(int row, int col) 
            :base(row, col)
        {
        
        }
        public override int GetBonus()
        {
            throw new NotImplementedException();
        }
    }
}
