
namespace Chapter2.GoF.Visitor
{
    internal class WeatherDescription : IWeatherElement
    {
        protected internal string ShortDescription;
        protected internal string Description;

        public void ManipulateMe(IWeatherManipulator weatherManipulator)
        {
            if (weatherManipulator != null) weatherManipulator.ManipulateElement(this);
        }

        public void ManipulateMe(IAnotherWeatherManipulator anotherWeatherManipulator) //aka accept
        {
            if (anotherWeatherManipulator != null) anotherWeatherManipulator.ManipulateElement(this); //aka visitor.visit(this)
        }
    }
}