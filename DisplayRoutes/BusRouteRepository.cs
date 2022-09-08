using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayRoutes
{
    public class BusRouteRepository
    {
        public static Dictionary<int, BusRoute> InitializeRoutes()
        {
            BusRoute route85 = new BusRoute(85, new string[] { "Dothan", "Enterprise", "Columbus" });
            BusRoute route231 = new BusRoute(231, new string[] { "Dothan", "Ozark", "Troy", "Montgomory" });
            BusRoute route51 = new BusRoute(51, new string[] { "Ariton", "Coffee Springs", "Andalusia" });
            BusRoute route167 = new BusRoute(167, new string[] { "Panama City Beach", "Enterprise", "Troy" });

            var routes = new Dictionary<int, BusRoute>
            {
                { 85, route85 },
                { 231, route231 },
                { 51, route51 },
                { 167, route167 }
            };

            return routes;
        }


        //public static List<BusRoute> InitializeRoutes()
        //{
        //    List<BusRoute> routes = new List<BusRoute>();

        //        routes.Add(new BusRoute(85, new string[] { "Dothan", "Enterprise", "Columbus" }));
        //        routes.Add(new BusRoute(231, new string[] { "Dothan", "Ozark", "Troy", "Montgomory" }));
        //        routes.Add(new BusRoute(51, new string[] { "Ariton", "Coffee Springs", "Andalusia" }));
        //        routes.Add(new BusRoute(167, new string[] { "Panama City Beach", "Enterprise", "Troy" }));
        //        routes.Add(new BusRoute(167, new string[] { "Test Origin", "Test Destination" }));
        //    return routes;
        //}
    }
}
