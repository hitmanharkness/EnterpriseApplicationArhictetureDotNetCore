
namespace Chapter2.GoF.Adapter
{
    public interface OracleDBDriver
    {
        bool Initialize(string parameters);

        IOracleDBConnection CreateNewConnection();
        IOracleDBConnection CreateNewPooledConnection();

        bool ValidateSQL(string validSQL);

        SomeDBFormat ExecuteSQL(IOracleDBConnection dbCon, string validSQL);
        int ExecuteScalarSQL(IOracleDBConnection dbCon, string validSQL);
    }

    /// <summary>
    /// Connection Object
    /// </summary>
    public interface IOracleDBConnection
    {      
    }

    public class SomeDBFormat
    {
    }
}
