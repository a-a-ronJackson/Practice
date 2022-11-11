using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Black_Jack
{
    public class GameLogic
    {
        public static void PlayGame()
        {
            var newDeck = new Deck();
            var shuffledDeck = Deck.ShuffleDeck(newDeck);
            var cardHand = Deck.DealCardHand(shuffledDeck);
            var score = 0;
            var hand = "";

            foreach (var card in cardHand)
            {
                score += card.value;
                hand += card.ToString();
            }

            Console.WriteLine($"Here are your cards: {hand.Trim()}\n");
            Console.WriteLine("Would you like another card?");
            string answer = Console.ReadLine().ToLower();

            while (answer == "yes")
            {
                var nextCard = shuffledDeck.Pop();
                score += nextCard.value;
                hand += nextCard.ToString();
                Console.WriteLine(hand);
                if (score > 21)
                    break;
                Console.WriteLine("Would you like another card?");
                answer = Console.ReadLine().ToLower();
            }
            
            if (score == 21)
            {
                Console.WriteLine("You win!!");
            }
            else if (score <= 21)
            {
                Console.WriteLine("Good job. You were close!");
            }
            else
                Console.WriteLine("You lose....");
        }
    }
}
