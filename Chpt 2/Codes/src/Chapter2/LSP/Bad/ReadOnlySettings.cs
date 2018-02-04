using System;

namespace Chapter2.LSP.Bad
{
    /// <summary>
    /// Says this class holds readonly or constant settings / configuration parameters to the software
    /// </summary>
    public class ReadOnlySettings : ISettings
    {
        public void Load()
        {
            //Loads some readonly/constant settings
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
