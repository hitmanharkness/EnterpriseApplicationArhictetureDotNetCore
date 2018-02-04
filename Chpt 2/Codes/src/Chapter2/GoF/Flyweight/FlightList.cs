using System.Collections.Concurrent;

namespace Chapter2.GoF.Flyweight
{
    /// <summary>
    /// Its a factory class that creates flyweights i.e. Flight objects and pool them (in the dictionary)
    /// </summary>
    public class FlightList
    {
        /// <summary>
        /// Thread-safe internal storage
        /// </summary>
        private readonly ConcurrentDictionary<string, Flight> _cache = new ConcurrentDictionary<string, Flight>();

        public FlightList()
        {
            PopulateFlightList(); //List of available flights by the given carrier (airline)
        }

        /// <summary>
        /// Returns immutable (and shareable flyweights) instances
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <returns></returns>
        public Flight GetFlight(string flightNumber)
        {
            Flight flight = null;
            if (_cache.TryGetValue(flightNumber, out flight)) return flight;
            throw new FlightDoesNotExistException();
        }

        public void AddFlight(string flightNumber, string from, string to, string planeType)
        {
            var flight = new Flight(flightNumber, from, to, planeType);
            _cache.AddOrUpdate(flightNumber, flight, (key, oldFlight) => flight);
        }

        /// <summary>
        /// Data feed - could be done via injection..
        /// This generation of objects via this factory and adding them to internal pool
        /// is shown here for demonstration purposes. Normally its done outside the factory class itself.
        /// </summary>
        private void PopulateFlightList()
        {
            //Fetches from some data source and add
            AddFlight("332", "DXB", "MNL", "B777");
            AddFlight("333", "MNL", "DXB", "B777");

            AddFlight("432", "ABC", "XYZ", "A320");
            AddFlight("433", "XYZ", "ABC", "A320");

            AddFlight("532", "KHI", "LHR", "A330");
            AddFlight("533", "LHR", "KHI", "A330");

            AddFlight("632", "DXB", "JFK", "A380");
            AddFlight("633", "JFK", "DXB", "A380");
        }
    }

}
