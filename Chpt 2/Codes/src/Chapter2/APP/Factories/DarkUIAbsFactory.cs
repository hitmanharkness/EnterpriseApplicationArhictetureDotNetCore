using Chapter2.APP.Interfaces;
using System;

namespace Chapter2.APP.Factories
{
    /// <summary>
    /// Template Method design pattern implementation demonstration
    /// </summary>
    public class DarkUIAbsFactory : ThemeableUIAbsFactory
    {
        public DarkUIAbsFactory(IServiceProvider provider) : base(provider)
        {
        }

        public override void ApplyThemeOnMenu(IMenu menu)
        {
            //specific implementation
        }

        public override void ApplyThemeOnStatusBar(IStatusBar statusBar)
        {
            //specific implementation
        }

        public override void ApplyThemeOnWizard(IWizard wizard)
        {
            //specific implementation
        }
    }
}
