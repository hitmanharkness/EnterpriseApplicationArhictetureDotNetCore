using Chapter2.APP.Factories;
using Chapter2.APP.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace Chapter2.Test.DesignPatterns
{
    /// <summary>
    /// A testing class containing various test cases related to sample GoF design patterns
    /// </summary>
    public class AppTests
    {
        private static IServiceProvider Provider { get; set; }

        [Fact]
        public void Test_GoF_Creational_Patterns()
        {
            RegisterServices();
            Test_UI_Creation();
        }

        private void RegisterServices()
        {
            IServiceCollection services = new ServiceCollection();

            //Adding required dependencies to the DI Container
            services.AddTransient<IWizardBuilder, WizardBuilder>();
            services.AddSingleton<IUIAbsFactory, DarkUIAbsFactory>();

            Provider = services.BuildServiceProvider();
        }

        private void Test_UI_Creation()
        {
            var uiFactory = Provider.GetRequiredService<IUIAbsFactory>();
            var uiElements = new List<IUIObject>();

            uiElements.Add(uiFactory.CreateStatusBar());
            uiElements.Add(uiFactory.GetMenu());
            uiElements.Add(uiFactory.CreateWizard());
        }
    }
}
