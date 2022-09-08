using System;
using MyUtilities;

namespace ConsoleApp1
{
    
    class CheckComfort
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Where should we go in May?");
            WeatherUtilities.Report("San Francisco", WeatherUtilities.FahrenheitToCelsius(65), 73);
            WeatherUtilities.Report("Bologna", 23, 65); //~73 F

        }
    }
}
