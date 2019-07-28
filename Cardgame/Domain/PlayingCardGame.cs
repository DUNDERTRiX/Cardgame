using System;
using System.Collections.Generic;
using System.Text;

namespace Cardgame.Domain
{
    public abstract class PlayingCardGame
    {
        public List<Player> Players { get; set; } = new List<Player>();
        public PlayingCardDeck CardDeck { get; }
        public PlayingCardGame()
        {
            this.CardDeck = new PlayingCardDeck();

        }

        public abstract void Play();
        public abstract void DisplayRules();
        public abstract void DisplayStatistics();
        public override abstract string ToString();
        public void DisplayMenu()
        {
            bool loop = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{this.ToString()} menu:");
                Console.WriteLine(" 1) Play");
                Console.WriteLine(" 2) Show rules");
                Console.WriteLine(" 3) Show statistics");
                Console.WriteLine();
                Console.WriteLine(" Q) Return to main menu");
                Console.WriteLine();
                var pressedKey = AskUserForInput("Selection:");
                switch (pressedKey.ToUpper())
                {
                    case "1":
                        this.Play();
                        break;
                    case "2":
                        this.DisplayRules();
                        break;
                    case "3":
                        this.DisplayStatistics();
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

        public static void DisplayErrorMessage(string message)
        {
            var previousForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = previousForegroundColor;
        }

        public static void DisplayMessage(string message)
        {
            var previousForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ForegroundColor = previousForegroundColor;
        }
        public static string AskUserForInput(string question)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{question} ");
            Console.ForegroundColor = ConsoleColor.Green;
            return Console.ReadLine().Trim();
        }
    }
}
