using Hemuppgift_Arv_Temp.Game;
using System;

namespace Hemuppgift_Arv_Temp
{
    internal class TakePins
    {
        static void Main(string[] args)
        {
            /* I programmet för spelet dra stickor använder vi arv(superklassen
               Player och underklasserna HumanPlayer och ComputerPlayer).
               Vad har vi vunnit med detta?
               För att enklare kunna spaka nya typer av spelare.

               Det finns en abstrakt metod i superklassen Player. Vad är en abstrakt metod? Varför finns den där?
               För att kunna skicka in ett värde som en spelare väljer.
            */



            Console.WriteLine("Hello, please write your username");
            string playerName = Console.ReadLine();
            // CREATING ALL NEEDED OBJ
            Board board = new Board();
            Player pcPlayer = new ComputerPlayer("Computer");
            Player player = new HumanPlayer(playerName);

            Console.WriteLine($"Hi, {player.GetUserID()}. \nYou have now created a new game of PickingPins");
            Console.WriteLine("You can choose between 2 modes. \n[1.EASY] and [2.HARD]");
            int gameMode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many pins would you like to play with?");
            int pinAmount = Convert.ToInt32(Console.ReadLine());

            // THE GAME SETUP
            board.setUp(pinAmount);
            bool computer = true;
            bool hardMode = false;
            int computerNbr = 0;

            if (gameMode == 2)
            {
                hardMode = true;
            } else
            {
                hardMode = false;
            }

            // THE GAME
            while (board.getNoPins() > 0)
            {
                if (computer)
                {
                    if (hardMode)
                    {
                        int pinsRemain = board.getNoPins();
                        computerNbr = ComputerHard(pinsRemain);
                    }
                    else
                    {
                        computerNbr = ComputerEasy();
                    }

                    Thread.Sleep(1000);
                    pcPlayer.TakePins(computerNbr, board);
                    Console.Clear();
                    if (computerNbr > 1)
                    {
                        Console.WriteLine($"{pcPlayer.GetUserID()} took {computerNbr} pins");
                    }
                    else
                    {
                        Console.WriteLine($"{pcPlayer.GetUserID()} took {computerNbr} pin");
                    }
                    computer = false ;
                }
                else
                {
                    Console.WriteLine($"Its your turn again {player.GetUserID()}, remaining pins: {board.getNoPins()}");
                    Thread.Sleep(500);
                    Console.WriteLine("How many pins would you like to pick?");
                    int temp = Convert.ToInt32(Console.ReadLine());
                    if (temp > 0 && temp < 3)
                    {
                        player.TakePins(temp, board);
                        computer = true;
                    }
                    else
                    {
                        Console.WriteLine("You can only pick 1 or 2 pins at a time");
                    }
                }

                if (computer && board.getNoPins() == 0)
                {
                    Console.WriteLine("Congratulations, you won!");
                }
                else if (!computer && board.getNoPins() == 0)
                {
                    Console.WriteLine("You lost, better luck next time");
                }

            }

        }
        // FUNC FOR EASY MODE
        static int ComputerEasy()
        {
            Random randomNbr = new Random();
            return randomNbr.Next(1, 3);

        }
        // FUNC FOR HARD MODE
        static int ComputerHard(int pinsRemain)
        {
            if (pinsRemain == 2)
            {
                return 2;
            }
            else if(pinsRemain % 3 == 0)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

    }
}
