using Chapter2.APP.Interfaces;

namespace Chapter2.APP.Factories
{
    public interface IUIAbsFactory
    {
        IMenu GetMenu();
        IWizard CreateWizard();
        IStatusBar CreateStatusBar();
    }
}
