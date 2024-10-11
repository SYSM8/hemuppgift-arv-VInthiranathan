using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public class Board
    {
        int noPins { get; set; }

        public void setUp(int pins)
        {
            noPins = pins;
        }
        public int TakePins(int takePins)
        {
            return noPins -= takePins;
        }
        public int getNoPins()
        {
            return noPins;
        }
    }
}
