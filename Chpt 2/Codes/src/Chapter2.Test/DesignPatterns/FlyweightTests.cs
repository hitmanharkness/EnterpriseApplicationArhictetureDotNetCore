using Chapter2.GoF.Flyweight;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Chapter2.Test.DesignPatterns
{
    public class FlyweightTests
    {
        private static IServiceProvider Provider { get; set; }

        [Fact]
        public void Test_Flyweight_Pattern()
        {
            RegisterServices();
            FlyweightClient();
        }

        /// <summary>
        /// Initializing & populating DI container
        /// </summary>
        private void RegisterServices()
        {
            IServiceCollection services = new ServiceCollection();

            //Adding required dependencies to the DI Container
            services.AddSingleton<FlightList>();
            services.AddTransient<FlightReservation>();

            Provider = services.BuildServiceProvider();
        }

        private void FlyweightClient()
        {
            var flightReservationSystem = Provider.GetRequiredService<FlightReservation>();

            flightReservationSystem.MakeReservation("Qureshi", "NRJ445", "332");
            flightReservationSystem.MakeReservation("Senthilvel", "NRI339", "333");
            flightReservationSystem.MakeReservation("Khan", "KLM987", "333");

            flightReservationSystem.DisplayReservations();
        }
    }
}
