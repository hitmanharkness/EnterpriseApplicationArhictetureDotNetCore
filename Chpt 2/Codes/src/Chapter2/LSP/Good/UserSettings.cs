
namespace Chapter2.LSP.Good
{
    public class UserSettings: IReadableSettings, IWriteableSettings
    {
        public void Load()
        {
            //Loads the user settings
        }

        public void Save()
        {
            //Saves the user settings
        }
    }
}
