using Chapter2.APP.Interfaces;

namespace Chapter2.APP.Factories
{
    public interface IWizardBuilder
    {
        void CreateWizardSteps(int screenSteps);
        void AddFrontScreen();
        void AddFinalScreen();

        IWizard GetResult();
    }
}
