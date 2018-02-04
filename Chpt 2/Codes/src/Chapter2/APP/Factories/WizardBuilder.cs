using System;
using Chapter2.APP.Interfaces;
using Chapter2.APP.UIObjects;

namespace Chapter2.APP.Factories
{
    /// <summary>
    /// Just a simple demonstration for a Builder pattern
    /// </summary>
    public class WizardBuilder : IWizardBuilder
    {
        private IWizard _wizard = new Wizard();

        public void CreateWizardSteps(int screenSteps)
        {
            if (screenSteps < 2) throw new Exception("Invalid number of wizard screen steps");

            for (int i = 0; i < screenSteps; i++)
                _wizard.Screens.Add(new Screen());
        }

        public void AddFrontScreen()
        {
            var frontScreen = _wizard.Screens[0];
            //Update the welcome screen step frontScreen..
        }

        public void AddFinalScreen()
        {
            var finalScreen = _wizard.Screens[_wizard.Screens.Count - 1];
            //Update the final screen step finalScreen..
        }        

        public IWizard GetResult()
        {
            return _wizard;
        }
    }
}
