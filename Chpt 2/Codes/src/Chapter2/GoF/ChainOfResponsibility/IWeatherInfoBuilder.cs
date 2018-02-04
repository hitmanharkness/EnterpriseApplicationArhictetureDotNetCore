
namespace Chapter2.GoF.ChainOfResponsibility
{
    public abstract class IWeatherInfoBuilder
    {
        protected IWeatherInfoBuilder _successor;

        public void SetSuccessor(IWeatherInfoBuilder successor)
        {
            _successor = successor;
        }

        public abstract void BuildWeatherObject(WeatherStructure weatherStructure);
    }
}
