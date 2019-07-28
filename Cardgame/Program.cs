using Cardgame.Domain;
using System;
using System.Text;

namespace Cardgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DisplayMenu();
        }
        private static void DisplayMenu()
        {
            bool loop = true;
            do
            {
                //Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Games:");
                Console.WriteLine(" 1) High or low");
                Console.WriteLine(" 2) Black Jack");
                Console.WriteLine();
                Console.WriteLine(" Q) Exit game");
                Console.WriteLine();

                var pressedKey = PlayingCardGame.AskUserForInput("Selection:");
                switch (pressedKey.ToString().ToUpper())
                {
                    case "1":
                        var game = new HighOrLowGame();
                        game.DisplayMenu();
                        break;
                    case "Q":
                        loop = false;
                        break;
                    default:
                        PlayingCardGame.DisplayErrorMessage("Invalid menu option.");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            } while (loop);
        }
    }
}
