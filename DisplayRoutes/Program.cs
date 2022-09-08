using DisplayRoutes;

List<BusRoute> allRoutes = BusRouteRepository.InitializeRoutes();




//Console.WriteLine("Where do you want to go to?");

//string location = Console.ReadLine();




//BusRoute[] routes = FindBusesTo(allRoutes, location);



//if (routes.Length > 0)
//    foreach (BusRoute route in routes)
//    Console.WriteLine($"You can use route {route}");
//else
//    Console.WriteLine($"No routes go to {location}");


//static BusRoute[] FindBusesTo(BusRoute[] routes, string location)
//{
//    return Array.FindAll(routes, route => route.Serves(location));

    //foreach (var route in routes)
    //{
    //    if (routes.Origin == location || routes.Destination == location)
    //        return route;
    //}
    //return null;

}