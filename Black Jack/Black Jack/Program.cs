using static Black_Jack.Card;

namespace Black_Jack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string answer = "no";
            Console.WriteLine("Welcome to the Black-Jack Table");
            while (answer != "yes")
            {
                Console.WriteLine("Do you want to play a game? (yes/no))");
                answer = Console.ReadLine().ToLower();

                if (answer == "yes")
                {
                    GameLogic.PlayGame();
                }
                else if (answer == "no")
                {
                    Console.WriteLine("Ok, maybe later then.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a yes/no answer...");
                }
            }
            
        }
    }
}