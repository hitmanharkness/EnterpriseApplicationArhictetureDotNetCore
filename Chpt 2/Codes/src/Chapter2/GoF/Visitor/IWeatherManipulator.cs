
namespace Chapter2.GoF.Visitor
{
    /// <summary>
    /// Interface for the Visitor object
    /// </summary>
    public interface IWeatherManipulator
    {
        void ManipulateElement(IWeatherElement weatherElement);
    }
}