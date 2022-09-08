using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayRoutes
{
    public class BusRoute
    {
        public int Number { get; }
        public string Origin => PlacesServed[0]; //first place in array
        public string Destination => PlacesServed[^1]; //last place in array

        public string[] PlacesServed { get; }

        public BusRoute(int number, string[] placesServed)
        {
            Number = number;
            PlacesServed = placesServed;
        }

        public override string ToString() => $"{Number}: {Origin} -> {Destination}";

        public bool Serves (string destination)
        {
            return Array.Exists(PlacesServed, place => place.Equals(destination));
            //foreach(string place in PlacesServed)
            //{
            //    if (place == destination)
            //        return true;
            //}
            //return false;
        }
        
    }
}
