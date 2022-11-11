using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Jack
{
    public class Deck
    {
        public List<Card> Cards { get; set; } // property
        public Deck() //constructor
        {
            Cards = new List<Card>();
            for (int i = (int)Card.Suit.Hearts; i <= (int)Card.Suit.Diamonds; i++) //from enum list. Hearts = 0 and Diamonds = 3
            {

                for (int j = (int)Card.Face.Ace; j <= (int)Card.Face.King; j++) //from enum list. Ace = 1 and King = 13
                {
                    Card card = new((Card.Face)j, (Card.Suit)i); //new card of each face and suit

                    if (card.face == Card.Face.Jack || card.face == Card.Face.Queen || card.face == Card.Face.King) //high face cards set to = 10
                        card.value = 10;
                    else
                        card.value = (int)card.face;
                    Cards.Add(card); //add to list of cards
                }

            }
        }       

        public static Stack<Card> ShuffleDeck(Deck deck) //excepts a Deck, shuffles the Deck, and returns a stack of cards
        {
            var random = new Random();
            var shuffledCards = deck.Cards.OrderBy(card => random.Next());

            var stackOfCards = new Stack<Card>(shuffledCards);

            return stackOfCards;
        }
        public static List<Card> DealCardHand(Stack<Card> cards) //deals top three cards from stack
        {
            List<Card> cardHand = new List<Card>();
            for (int i = 0; i < 2; i++)
            {
                cardHand.Add(cards.Pop());
            }
            return cardHand;
        }
    }

}
