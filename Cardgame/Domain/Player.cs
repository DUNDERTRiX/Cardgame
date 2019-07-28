using System;
using System.Collections.Generic;
using System.Text;

namespace Cardgame.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public bool IsAi { get; set; }
        public List<PlayingCard> CardsOnHand { get; set; }
    }
}
