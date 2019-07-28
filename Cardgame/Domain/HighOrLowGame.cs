using System;
using System.Collections.Generic;
using System.Text;

namespace Cardgame.Domain
{
    public class HighOrLowGame : PlayingCardGame
    {
        public HighOrLowGame()
        {
        }

        public override void Play()
        {

            Console.Clear();
            if (this.Players.Count == 0)
            {
                var playerName = string.Empty;
                do
                {
                    playerName = PlayingCardGame.AskUserForInput("What is your name?");
                    if (!string.IsNullOrWhiteSpace(playerName))
                    {
                        break;
                    }
                } while (true);
                this.Players = new List<Player> { new Player { Name = playerName, IsAi = false, CardsOnHand = this.CardDeck.GetCardsFromTop(2) } };
                this.Players[0].CardsOnHand[0].Visible = true;
            }
            else
            {
                this.Players[0].CardsOnHand = this.CardDeck.GetCardsFromTop(2);
                this.Players[0].CardsOnHand[0].Visible = true;
            }

            Console.Clear();
            Console.WriteLine($"Player {this.Players[0].Name}");
            Console.WriteLine("Your cards:");
                
            foreach (var card in this.Players[0].CardsOnHand)
            {
                    Console.Write($"{card.ToString()}\t");
            }
            Console.WriteLine();
            do
            {
                Console.WriteLine();
                string userGuess = AskUserForInput("Is the hidden card higher or lower?: ");
                
                // User guessed higher
                if (userGuess.Equals("higher",StringComparison.CurrentCultureIgnoreCase) || userGuess.Equals("h", StringComparison.CurrentCultureIgnoreCase))
                {
                    DisplayResult(this.Players[0], HighOrLow.Higher);
                    break;
                }
                // User guessed lower
                else if (userGuess.Equals("lower", StringComparison.CurrentCultureIgnoreCase) || userGuess.Equals("l", StringComparison.CurrentCultureIgnoreCase))
                {
                    DisplayResult(this.Players[0], HighOrLow.Lower);
                    break;
                }
                // Invalid guess
                else
                {
                    DisplayErrorMessage("Invalid guess");
                }

            } while (true);
            var userInput = string.Empty;
            do
            {
                userInput = AskUserForInput("Play again? (Y/N):");
                if (userInput.Equals("Y", StringComparison.CurrentCultureIgnoreCase) || userInput.Equals("N", StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    DisplayErrorMessage("Invalid input");
                    Console.ReadKey();
                }
            } while (true);
            
            // Return cards on hand to deck
            this.CardDeck.PutCardLast(this.Players[0].CardsOnHand);
            this.Players[0].CardsOnHand = null;

            if (userInput.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
            {
                this.Play();
            }
            else if (userInput.Equals("N", StringComparison.CurrentCultureIgnoreCase))
            {
                this.Players = new List<Player>();
            }
        }

        public void DisplayResult(Player player, HighOrLow guess)
        {
            HighOrLow correctAnswer = HighOrLow.NotSet;
            player.CardsOnHand[1].Visible = true;
            if (player.CardsOnHand[1].Rank > player.CardsOnHand[0].Rank)
            {
                correctAnswer = HighOrLow.Higher;
            }
            else if (player.CardsOnHand[1].Rank < player.CardsOnHand[0].Rank)
            {
                correctAnswer = HighOrLow.Lower;
            }
            else
            {
                if ((int)player.CardsOnHand[1].Color > (int)player.CardsOnHand[0].Color)
                {
                    correctAnswer = HighOrLow.Higher;
                }
                else if ((int)player.CardsOnHand[1].Color < (int)player.CardsOnHand[0].Color)
                {
                    correctAnswer = HighOrLow.Lower;
                }
            }
            Console.Clear();
            Console.WriteLine($"Player {this.Players[0].Name}");
            Console.WriteLine("Your cards:");

            foreach (var card in this.Players[0].CardsOnHand)
            {
                Console.Write($"{card.ToString()}\t");
            }
            Console.WriteLine();
            if (guess.Equals(correctAnswer))
            {
                DisplayMessage("Congratulations, you guessed correct!");
            }
            else
            {
                DisplayMessage("Sorry, your guess was not correct!");
            }
            Console.WriteLine();
        }
        public override void DisplayRules()
        {
            Console.WriteLine("Not yet implemented...");
            Console.ReadKey();
        }

        public override void DisplayStatistics()
        {
            Console.WriteLine("Not yet implemented...");
            Console.ReadKey();
        }

        public override string ToString()
        {
            return "High or Low";
        }
    }
}
