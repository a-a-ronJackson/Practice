using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Jack
{
    public class Card
    {
        public Card(Face face, Suit suit)
        {
            this.face = face;
            this.suit = suit;
        }

        public Face face { get; set; }
        public Suit suit { get; set; }
        public int value { get; set; }

        public override string ToString()
        {
            return value + " of " + suit + " ";
        }
        public enum Suit
        {
            Hearts,
            Spades,
            Clubs,
            Diamonds
        }
        public enum Face
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
    }
}
