
namespace Chapter2.GoF.Flyweight
{
    /// <summary>
    /// Flight (immutable) objects will be the Flyweights
    /// 
    /// To make a type immutable you simply need to
    /// - Make all fields readonly and assign them in the constructor
    /// - Any method that change data or state of the object let it create and return a new (another immutable) instance instead
    /// </summary>
    public class Flight
    {
        private const string FLIGHT_CARRIER = "KE";
        private readonly string _flightNumber;
        private readonly string _from;
        private readonly string _to;
        private readonly string _planeType;

        public Flight(string flightNumber, string from, string to, string planeType)
        {
            _flightNumber = flightNumber;
            _from = from;
            _to = to;
            _planeType = planeType;
        }

        public string FlightNumber
        {
            get { return FLIGHT_CARRIER + _flightNumber; }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Flight && Equals((Flight)obj);
        }

        public bool Equals(Flight other)
        {
            return (string.Equals(FlightNumber, other.FlightNumber) &&
                string.Equals(_from, other._from) &&
                string.Equals(_to, other._to) &&
                string.Equals(_planeType, other._planeType));
        }

        public override int GetHashCode()
        {
            return (FlightNumber != null ? FlightNumber.GetHashCode() : 0);
        }

        public static bool operator ==(Flight a, Flight b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Flight a, Flight b)
        {
            return !Equals(a, b);
        }
    }

}
