
namespace Chapter2.GoF.Visitor
{
    /// <summary>
    /// Interface for the Visitable class (The class to be visited by the visitor class)
    /// </summary>
    public interface IWeatherElement
    {
        void ManipulateMe(IWeatherManipulator weatherManipulator);

        //void ManipulateMe(IAnotherWeatherManipulator anotherWeatherManipulator);
    }
}
