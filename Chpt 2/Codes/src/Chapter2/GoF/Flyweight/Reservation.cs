
namespace Chapter2.GoF.Flyweight
{
    public class Reservation
    {
        private readonly int _pnr;
        private readonly Flight _flight;

        public Reservation(int pnr, Flight flight)
        {
            _pnr = pnr;
            _flight = flight;
        }

        public string Display()
        {
            //concat all properties and return as a single string
            return "";
        }
    }
}