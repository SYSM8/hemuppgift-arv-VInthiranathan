using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(string user) : base(user)
        {
            base.userID = user;
        }

    }
}
