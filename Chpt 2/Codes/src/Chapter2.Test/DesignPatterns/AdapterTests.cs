using Chapter2.GoF.Adapter;
//using Xunit;

namespace Chapter2.Test.DesignPatterns
{
    public class AdapterTests
    {
        //[Fact]
        public void Test_Adapter_Pattern()
        {
            DBAdapter db = null;
            string someSQLstring = "";
            //Create concrete objects, some meaningful SQL..
            var dbTable = db.ExecuteSQL(someSQLstring);
        }
    }
}
