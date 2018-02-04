
namespace Chapter2.GoF.Visitor
{
    /// <summary>
    /// Vistable class (The class to be visited by the visitor class)
    /// </summary>
    internal class Map : IWeatherElement
    {
        protected internal string MapURL;
        protected internal byte[] ThumbnailImage;

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