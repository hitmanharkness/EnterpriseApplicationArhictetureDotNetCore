using System.Data;
using System;

namespace Chapter2.GoF.Adapter
{
    public class DBAdapter
    {
        private OracleDBDriver dbDriver = null;
        private bool bDBInitialized;
        private readonly string initializationDBParameters;

        public DBAdapter()
        {
            //dbDriver = new OracleDBDriverImpl();
            initializationDBParameters = "XYZ, ABC";
        }

        public DataTable ExecuteSQL(string strSQL)
        {
            if (string.IsNullOrWhiteSpace(strSQL)) throw new InvalidSQLException();

            if (!bDBInitialized) bDBInitialized = dbDriver.Initialize(initializationDBParameters);

            if(!dbDriver.ValidateSQL(strSQL)) throw new InvalidSQLException();

            var dbConnection = dbDriver.CreateNewPooledConnection();

            SomeDBFormat dbData = dbDriver.ExecuteSQL(dbConnection, strSQL);

            return TransformDBDataType(dbData);
        }

        private DataTable TransformDBDataType(SomeDBFormat dbData)
        {
            DataTable dbTable = null;

            //dbTable = dbData; do some conversions

            return dbTable;
        }
    }

    public class InvalidSQLException: Exception
    {
    }
}
