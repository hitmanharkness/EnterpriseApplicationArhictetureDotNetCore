using System.Collections.Generic;

namespace Chapter2.APP.Interfaces
{
    /// <summary>
    /// Wizard here is collection of some <see cref="IScreen"/>
    /// </summary>
    public interface IWizard : IUIObject
    {
        IList<IScreen> Screens { get; }
    }
}
