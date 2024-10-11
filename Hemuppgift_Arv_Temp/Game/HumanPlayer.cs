using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string user) : base(user)
        {
            base.userID = user;
        }
    }
}
