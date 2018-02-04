
namespace Chapter2.GoF.Visitor
{
    internal class Temperature : IWeatherElement
    {
        protected internal int CentigradeTemperature;
        protected internal int FahrenheihtTemperature;

        public void ManipulateMe(IWeatherManipulator weatherManipulator) //aka accept
        {
            if (weatherManipulator != null) weatherManipulator.ManipulateElement(this); //aka visitor.visit(this)
        }

        public void ManipulateMe(IAnotherWeatherManipulator anotherWeatherManipulator) //aka accept
        {
            if (anotherWeatherManipulator != null) anotherWeatherManipulator.ManipulateElement(this); //aka visitor.visit(this)
        }
    }
}