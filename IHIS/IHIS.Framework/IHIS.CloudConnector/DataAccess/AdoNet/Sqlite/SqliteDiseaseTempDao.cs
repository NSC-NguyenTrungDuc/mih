using System;
//using System.Data.SQLite;
using System.Text;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDiseaseTempDao : IDiseaseTempDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = "+ Db.Escape(tableName) + ";");

            return ((long) Db.GetScalar(query.ToString()) > 0);            
        }

        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.CACHE; }
        }

        #endregion
    }
}