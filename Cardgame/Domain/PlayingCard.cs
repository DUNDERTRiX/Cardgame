using System;
using System.Collections.Generic;
using System.Text;

namespace Cardgame.Domain
{
    public class PlayingCard
    {
        public CardColor Color { get; set; }
        public CardRank Rank { get; set; }
        public bool Visible { get; set; }

        public void DisplayCard()
        {
            bool hasWrittenFirstNumber = false;
            string printString = string.Empty;
            if (this.Rank == CardRank.Ace)
            {
                printString =
                    " V         " +
                    "           " +
                    "           " +
                    "     S     " +
                    "           " +
                    "           " +
                    "         V ";
            }
            if (this.Rank == CardRank.Two)
            {
                printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "           " +
                    "           " +
                    "     S     " +
                    "         V ";
            }
            if (this.Rank == CardRank.Three)
            {
                printString =
                    " V         " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "           " +
                    "     S     " +
                    "         V ";
            }
            if (this.Rank == CardRank.Four)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "           " +
                    "           " +
                    "   S   S   " +
                    "         V ";
            }
            if (this.Rank == CardRank.Five)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "     S     " +
                    "           " +
                    "   S   S   " +
                    "         V ";
            }
            if (this.Rank == CardRank.Six)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
            }
            if (this.Rank == CardRank.Seven)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "           " +
                    "   S   S   " +
                    "         V ";
            }
            if (this.Rank == CardRank.Eight)
            {
                printString =
                    " V         " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "     S     " +
                    "   S   S   " +
                    "         V ";
            }
            if (this.Rank == CardRank.Nine)
            {
                printString =
                    " V         " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "           " +
                    "   S S S   " +
                    "         V ";
            }
            if (this.Rank == CardRank.Ten || this.Rank == CardRank.Jack || this.Rank == CardRank.Queen || this.Rank == CardRank.King)
            {
                printString =
                    " V         " +
                    "    S S    " +
                    "     S     " +
                    "  S S S S  " +
                    "     S     " +
                    "    S S    " +
                    "         V ";
            }
            switch (this.Color)
            {
                case CardColor.Diamonds:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case CardColor.Spades:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
            if (!this.Visible)
            {
                printString =
                    " X       X " +
                    "           " +
                    "           " +
                    "     X     " +
                    "           " +
                    "           " +
                    " X       X ";
            }

            for (int i = 0; i < printString.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (i % 11 == 0 && i != 0)
                {
                    Console.CursorLeft -= 11;
                    Console.CursorTop += 1;
                }
                if (printString[i] == 'S')
                {
                    switch (this.Color)
                    {
                        case CardColor.Hearts:
                            Console.Write('♥');
                            break;
                        case CardColor.Clubs:
                            Console.Write("♣");
                            break;
                        case CardColor.Diamonds:
                            Console.Write("♦");
                            break;
                        case CardColor.Spades:
                            Console.Write("♠");
                            break;
                    }
                    continue;
                }
                else if (printString[i] == 'V')
                {
                    if (this.Rank == CardRank.Ten)
                    {
                        if (hasWrittenFirstNumber == false)
                        {
                            Console.Write(10);
                            hasWrittenFirstNumber = true;
                            i++;
                        }
                        else
                        {
                            Console.CursorLeft--;
                            Console.Write(10);
                        }
                        continue;
                    }
                    else if (this.Rank == CardRank.Jack)
                    {
                        Console.Write("J");
                    }
                    else if (this.Rank == CardRank.Queen)
                    {
                        Console.Write("Q");
                    }
                    else if (this.Rank == CardRank.King)
                    {
                        Console.Write("K");
                    }
                    else if (this.Rank == CardRank.Ace)
                    {
                        Console.Write("A");
                    }
                    else
                    {
                        Console.Write((int)this.Rank);
                    }
                }
                else
                {
                    Console.Write(printString[i]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override string ToString()
        {
            string returnString = string.Empty;
            if (!this.Visible)
            {
                return "XX";
            }
            switch (this.Color)
            {
                case CardColor.Hearts:
                    returnString = "♥";
                    break;
                case CardColor.Clubs:
                    returnString = "♣";
                    break;
                case CardColor.Diamonds:
                    returnString = "♦";
                    break;
                case CardColor.Spades:
                    returnString = "♠";
                    break;
            }
            if (this.Rank == CardRank.Jack)
            {
                returnString += "J";
            }
            else if (this.Rank == CardRank.Queen)
            {
                returnString += "Q";
            }
            else if (this.Rank == CardRank.King)
            {
                returnString += "K";
            }
            else if (this.Rank == CardRank.Ace)
            {
                returnString += "A";
            }
            else
            {
                returnString += $"{(int)this.Rank}";
            }
            return returnString;
        }
    }
}
