using System.Collections.Generic;

namespace Chapter2.GoF.Flyweight
{
    public class FlightReservation
    {
        private readonly IList<Reservation> _reservations = new List<Reservation>();
        private FlightList _flightList;

        public FlightReservation(FlightList flightList)
        {
            _flightList = flightList;
        }

        public void MakeReservation(string lastName, string id, string flightNumber)
        {
            int pnr = PNRAllocator.AllocatePNR(lastName, id);

            //Flyweight-Immutable object is returned which will be shared between all instances
            Flight flight = _flightList.GetFlight(flightNumber);

            _reservations.Add(new Reservation(pnr, flight));
        }

        public void DisplayReservations()
        {
            //Print Total Reservations: _reservations.Count;
            foreach (var reservation in _reservations)
                reservation.Display();
        }
    }
}
