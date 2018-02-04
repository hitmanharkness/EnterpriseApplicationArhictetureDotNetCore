using Xunit;
using Chapter2.LSP;
using System.Collections.Generic;

namespace Chapter2.Test.SOLID
{
    public class LSPTests
    {
        [Fact]
        public void Test_Client_Violating()
        {
            List<ISettings> allSettings = new List<ISettings>();

            ISettings setting = new LSP.Bad.UserSettings();
            allSettings.Add(setting);

            setting = new LSP.Bad.MachineSettings();
            allSettings.Add(setting);

            setting = new LSP.Bad.ReadOnlySettings();
            allSettings.Add(setting);

            //Load all types of settings
            allSettings.ForEach(s => s.Load());

            //Do some changes to settings objects..

            //Following line fails because client (actually) does not know it has to catch
            //the exception(NotImplementedException) as thrown by ReadOnlySettings.Save()
            try { allSettings.ForEach(s => s.Save()); }
            catch(System.NotImplementedException)
            {
                //Caught exception only to avoid test case failure but confirmation of a bad design
            }
        }

        [Fact]
        public void Test_Client_NonViolating()
        {
            var allLoadableSettings = new List<IReadableSettings>();
            var allSaveableSettings = new List<IWriteableSettings>();

            var userSettings = new LSP.Good.UserSettings();
            allLoadableSettings.Add(userSettings);
            allSaveableSettings.Add(userSettings);

            var machineSettings = new LSP.Good.MachineSettings();
            allLoadableSettings.Add(machineSettings);
            allSaveableSettings.Add(machineSettings);

            var readOnlySettings = new LSP.Good.ReadOnlySettings();
            allLoadableSettings.Add(readOnlySettings);
            //allSaveableSettings.Add(readOnlySettings); Cannot compile this line; readOnlySettings is not save-able/writable settings

            //Load all types of settings
            allLoadableSettings.ForEach(s => s.Load());

            //Do some changes to settings objects..

            allSaveableSettings.ForEach(s => s.Save()); //Now this line clearly does not fail :)
        }
    }
}
