using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public abstract class Player
    {
        public string userID {  get; set; }

        public Player(string userId)
        {
            userID = userId;
        }
        public string GetUserID()
        {
            return userID;
        }
        public int TakePins(int amount, Board board)
        {
            return board.TakePins(amount);
        }
    }
}
