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



            Console.WriteLine("Hello, Please write your username");
            string playerName = Console.ReadLine();

            Board board = new Board();
            Player pcPlayer = new ComputerPlayer("Computer");
            Player player = new HumanPlayer(playerName);

            Console.WriteLine("You have now created a new game.");
            Console.WriteLine("How many pins would you like to play with?");
            int pinAmount = Convert.ToInt32(Console.ReadLine());

            board.setUp(pinAmount);
            bool computer = true;
            Random randomNbr = new Random();

            while (board.getNoPins() > 0)
            {
                if (computer)
                {
                    Thread.Sleep(1000);
                    int randomNumber = randomNbr.Next(1, 3);
                    pcPlayer.TakePins(randomNumber, board);
                    Console.Clear();
                    if (randomNumber > 1)
                    {
                        Console.WriteLine($"{pcPlayer.userID} took {randomNumber} pins");
                    }
                    else
                    {
                        Console.WriteLine($"{pcPlayer.userID} took {randomNumber} pin");
                    }
                    computer = false ;
                }
                else
                {
                    Console.WriteLine($"Its your turn again {player.userID}, remaining pins: {board.getNoPins()}");
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

    }
}
