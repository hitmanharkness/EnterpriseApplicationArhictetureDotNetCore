using Chapter2.APP.Interfaces;
using Chapter2.APP.UIObjects;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Chapter2.APP.Factories
{
    /// <summary>
    /// Abstract implementation of IUIAbsFactory which provides the essential implementation
    /// and leaves the themeable (via template method pattern) factory onto the specific derived, concrete abstract_factory implementations
    /// </summary>
    public abstract class ThemeableUIAbsFactory : IUIAbsFactory
    {
        protected IServiceProvider _provider;
        private IMenu menu;

        public ThemeableUIAbsFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        #region IUIAbsFactory abstract factory interface
        public IStatusBar CreateStatusBar()
        {
            var statusBar = new StatusBar();
            //StatusBar creation Preprocessing..
            ApplyThemeOnStatusBar(statusBar);
            //StatusBar creation Post-processing..
            return statusBar;
        }

        /// <summary>
        /// Internal code demonstrates the use of Builder pattern
        /// </summary>
        /// <returns></returns>
        public IWizard CreateWizard()
        {
            //Director code for builder pattern
            var wizardBuilder = _provider.GetRequiredService<IWizardBuilder>();

            wizardBuilder.CreateWizardSteps(4);
            wizardBuilder.AddFrontScreen();
            wizardBuilder.AddFinalScreen();

            var wizard = wizardBuilder.GetResult();

            ApplyThemeOnWizard(wizard);

            return wizard;
        }

        public IMenu GetMenu()
        {
            //sort of Singleton resource behaviour
            if (menu != null) return menu; //only one menu resource will be created

            menu = new Menu();
            //Menu creation Preprocessing..
            ApplyThemeOnMenu(menu);
            //Menu creation Post-processing..
            return menu;
        }
        #endregion

        #region Template Methods
        public abstract void ApplyThemeOnStatusBar(IStatusBar statusBar);

        public abstract void ApplyThemeOnWizard(IWizard wizard);

        public abstract void ApplyThemeOnMenu(IMenu menu);
        #endregion
    }
}
