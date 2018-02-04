using Chapter2.APP.Interfaces;
using System.Collections.Generic;

namespace Chapter2.APP.UIObjects
{
    public class Wizard : UIObject, IWizard
    {
        private IList<IScreen> wizardScreens;

        public Wizard()
        {
            wizardScreens = new List<IScreen>();
        }

        /// <summary>
        /// From this getter, multiple screens can be
        /// added by the Builder.
        /// </summary>
        public IList<IScreen> Screens
        {
            get { return wizardScreens; }
        }
    }
}
