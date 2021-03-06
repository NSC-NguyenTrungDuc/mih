using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using System.Xml;

namespace IHIS
{
    #region SessionInfo
    /// <summary>
    /// SessionInfo
    /// </summary>
    internal class SessionInfo
    {
        private ProviderKind providerKind = ProviderKind.Unknown;
        private DataBaseKind dBKind = DataBaseKind.UnKnown;
        private string connectString = "";
        private DbFactory dbFactory = null;
        private IDbConnection connection = null;
        private IDbTransaction transaction = null;

        /// <summary>
        /// Connect할 Data Provider의 종류
        /// </summary>
        public ProviderKind ProviderKind
        {
            get { return providerKind; }
            set { providerKind = value; }
        }
        /// <summary>
        /// Connect할 DataBase의 종류
        /// </summary>
        public DataBaseKind DBKind
        {
            get { return dBKind; }
            set { dBKind = value; }
        }

        /// <summary>
        /// DB Connect String
        /// </summary>
        public string ConnectString
        {
            get { return connectString; }
            set { connectString = value; }
        }

        /// <summary>
        /// Data관련 Class의 객체를 생성하는 Factory
        /// </summary>
        public DbFactory DbFactory
        {
            get { return dbFactory; }
            set { dbFactory = value; }
        }

        /// <summary>
        /// DB 연결 객체
        /// </summary>
        public IDbConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        /// <summary>
        /// DB Transaction 객체
        /// </summary>
        public IDbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        /// <summary>
        /// Default설정의 SessionInfo객체를 초기화한다.
        /// </summary>
        public SessionInfo()
        {
        }

        #region static 생성자, Method
        public static Hashtable SessionInfoList = new Hashtable();
        static SessionInfo()
        {
            //configXml에서 DBConnections Node List로 Session List Set
            XmlNodeList conns = Service.ConfigXml.DocumentElement.GetElementsByTagName("DBConnections");
            SessionInfo sInfo = null;
            string key;
            if (conns.Count > 0)
            {
                foreach (XmlElement conn in conns[0].ChildNodes)
                {
                    try
                    {
                        sInfo = new SessionInfo();
                        key = conn.GetAttribute("Name");
                        sInfo.ProviderKind = GetProviderKind(conn.GetAttribute("ProviderKind"));
                        sInfo.DBKind = GetDataBaseKind(conn.GetAttribute("DataBaseKind"));
                        sInfo.ConnectString = conn.GetAttribute("ConnectString");
                        sInfo.DbFactory = DbFactory.GetFactory(sInfo.ProviderKind);
                        sInfo.Connection = sInfo.DbFactory.NewConnection(sInfo.ConnectString);
                        SessionInfoList.Add(key, sInfo);
                    }
                    catch (Exception xe)
                    {
                        MessageBox.Show("Session정보 생성에러[" + xe.Message + "][" + xe.StackTrace + "]");
                    }
                }
            }
        }
        private static ProviderKind GetProviderKind(string kindName)
        {
            ProviderKind kind = ProviderKind.Unknown;
            switch (kindName.ToUpper())
            {
                case "MYSQL":
                    kind = ProviderKind.MySql;
                    break;
                case "SQLSERVER":
                    kind = ProviderKind.SqlServer;
                    break;
                case "ORACLE":
                    kind = ProviderKind.Oracle;
                    break;
                case "OLEDB":
                    kind = ProviderKind.OleDB;
                    break;
                case "ODBC":
                    kind = ProviderKind.ODBC;
                    break;
                default:
                    break;
            }
            return kind;
        }
        private static DataBaseKind GetDataBaseKind(string kindName)
        {
            DataBaseKind kind = DataBaseKind.UnKnown;
            switch (kindName.ToUpper())
            {
                case "MYSQL":
                    kind = DataBaseKind.MySql;
                    break;
                case "SQLSERVER":
                    kind = DataBaseKind.SqlServer;
                    break;
                case "ORACLE":
                    kind = DataBaseKind.Oracle;
                    break;
                case "MSACCESS":
                    kind = DataBaseKind.MSAccess;
                    break;
                default:
                    break;
            }
            return kind;
        }
        #endregion
    }
    #endregion

    #region enum ProviderKind
    /// <summary>
    /// Data Provider의 종류
    /// </summary>
    internal enum ProviderKind
    {
        /// <summary>
        /// Microsoft SqlServer용 SqlClient Data Provider
        /// </summary>
        SqlServer,
        /// <summary>
        /// OracleClient Data Provider
        /// </summary>
        Oracle,
        /// <summary>
        /// OleDB를 지원하는 Data Provider
        /// </summary>
        OleDB,
        /// <summary>
        /// ODBC를 지원하는 Data Provider
        /// </summary>
        ODBC,
        /// <summary>
        /// MySQL Data Provider
        /// </summary>
        MySql,
        /// <summary>
        /// 기타 (현재는 지원하지 않음)
        /// </summary>
        Unknown
    }
    #endregion

    #region enum DataBaseKind
    /// <summary>
    /// DB의 종류를 관리하는 Enum
    /// </summary>
    public enum DataBaseKind
    {
        /// <summary>
        /// Oracle DB
        /// </summary>
        Oracle,
        /// <summary>
        /// SqlServer DB
        /// </summary>
        SqlServer,
        /// <summary>
        /// MySQL DB
        /// </summary>
        MySql,
        /// <summary>
        /// MS Access DB (mdb)
        /// </summary>
        MSAccess,
        /// <summary>
        /// 기타(현재 정의안됨)
        /// </summary>
        UnKnown
    }
    #endregion

    #region DbFactory
    /// <summary>
    /// Data관련 Class의 객체를 생성하는 추상Factory
    /// </summary>
    internal abstract class DbFactory
    {
        /// <summary>
        /// Data Prover의 종류에 의해 유효한 DbFactory객체를 반환한다.
        /// </summary>
        /// <param name="kind">Data Provider의 종류</param>
        /// <returns></returns>
        public static DbFactory GetFactory(ProviderKind kind)
        {
            DbFactory factory = null;
            switch (kind)
            {
                case ProviderKind.MySql:
                    factory = new MySqlDbFactory();
                    break;
                case ProviderKind.Oracle:
                    factory = new OracleDbFactory();
                    break;
                case ProviderKind.OleDB:
                    factory = new OleDbFactory();
                    break;
                case ProviderKind.ODBC:
                    factory = new OdbcFactory();
                    break;
                case ProviderKind.SqlServer:
                    factory = new SqlDbFactory();
                    break;
                default:
                    factory = new OdbcFactory();
                    break;
            }
            return factory;
        }

        /// <summary>
        /// IDbConnection 구현객체를 반환한다.
        /// </summary>
        /// <param name="connString">연결 문자열</param>
        /// <returns></returns>
        public abstract IDbConnection NewConnection(string connString);

        /// <summary>
        /// IDbCommand 구현객체를 반환한다.
        /// </summary>
        /// <returns></returns>
        public abstract IDbCommand NewCommand();
        /// <summary>
        /// IDbCommand 구현객체를 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <returns></returns>
        public abstract IDbCommand NewCommand(string cmdText);
        /// <summary>
        /// IDbCommand 구현객체를 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <param name="connection">DB연결을 나타내는 IDbConnection객체</param>
        /// <returns></returns>
        public abstract IDbCommand NewCommand(string cmdText, IDbConnection connection);
        /// <summary>
        /// IDbDataParameter 구현객체를 반환한다.
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        public abstract IDbDataParameter NewDataParamater(string parameterName, object value);
        /// <summary>
        /// 사용하는 DB를 지원하는 DataAdapter객체를 반환한다.
        /// </summary>
        /// <param name="selectCommand">DataAdapter의 SelectCommand속성으로 설정될 SELECT문 또는 Stored Procedure를 나타내는 Command객체</param>
        /// <returns></returns>
        public abstract DbDataAdapter NewDataAdapter(IDbCommand selectCommand);
        /// <summary>
        /// IDbCommand에 지정된 Stored Procedure의 Parameter 정보를 검색하여 지정된 IDbCommand객체의 Parameters 컬렉션을 채운다.
        /// </summary>
        /// <param name="command">지정된 IDbCommand객체</param>
        public abstract void DeriveParameters(IDbCommand command);
        /// <summary>
        /// DbCommandBuilder GET
        /// </summary>
        /// <returns></returns>
        public abstract DbCommandBuilder NewDbCommandBuilder(DbDataAdapter adapter);
    }
    #endregion

    #region SqlDbFactory
    /// <summary>
    /// SqlDbFactory
    /// </summary>
    internal class SqlDbFactory : DbFactory
    {
        internal SqlDbFactory()
        {
        }

        /// <summary>
        /// SqlConnection객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="connString">연결 문자열</param>
        /// <returns></returns>
        public override IDbConnection NewConnection(string connString)
        {
            return new SqlConnection(connString);
        }

        /// <summary>
        /// SqlCommad객체를 초기화하여 반환한다.
        /// </summary>
        /// <returns></returns>
        public override IDbCommand NewCommand()
        {
            return new SqlCommand();
        }

        /// <summary>
        /// SqlCommad객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText)
        {
            return new SqlCommand(cmdText);
        }

        /// <summary>
        /// SqlCommad객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <param name="connection">DB연결을 나타내는 SqlConnection객체</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText, IDbConnection connection)
        {
            return new SqlCommand(cmdText, connection as SqlConnection);
        }
        /// <summary>
        /// SqlParameter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        public override IDbDataParameter NewDataParamater(string parameterName, object value)
        {
            return new SqlParameter(parameterName, value);
        }
        /// <summary>
        /// SqlDataAdapter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="selectCommand">DataAdapter의 SelectCommand속성으로 설정될 SELECT문 또는 Stored Procedure를 나타내는 SqlCommand객체</param>
        /// <returns></returns>
        public override DbDataAdapter NewDataAdapter(IDbCommand selectCommand)
        {
            return new SqlDataAdapter(selectCommand as SqlCommand);
        }
        /// <summary>
        /// SqlCommand에 지정된 Stored Procedure의 Parameter 정보를 검색하여 지정된 SqlCommand객체의 Parameters 컬렉션을 채운다.
        /// </summary>
        /// <param name="command">지정된 IDbCommand객체</param>
        public override void DeriveParameters(IDbCommand command)
        {
            SqlCommandBuilder.DeriveParameters(command as SqlCommand);
        }
        public override DbCommandBuilder NewDbCommandBuilder(DbDataAdapter adapter)
        {
            return new SqlCommandBuilder(adapter as SqlDataAdapter);
        }
    }
    #endregion

    #region OracleDbFactory
    /// <summary>
    /// OracleDbFactory
    /// </summary>
    internal class OracleDbFactory : DbFactory
    {
        internal OracleDbFactory()
        {
        }

        /// <summary>
        /// OracleConnection객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="connString">연결 문자열</param>
        /// <returns></returns>
        public override IDbConnection NewConnection(string connString)
        {
            return new OracleConnection(connString);
        }

        /// <summary>
        /// OracleCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <returns></returns>
        public override IDbCommand NewCommand()
        {
            return new OracleCommand();
        }

        /// <summary>
        /// OracleCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText)
        {
            return new OracleCommand(cmdText);
        }

        /// <summary>
        /// OracleCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <param name="connection">DB연결을 나타내는 OracleConnection객체</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText, IDbConnection connection)
        {
            return new OracleCommand(cmdText, connection as OracleConnection);
        }

        /// <summary>
        /// OracleParameter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        public override IDbDataParameter NewDataParamater(string parameterName, object value)
        {
            return new OracleParameter(parameterName, value);
        }
        /// <summary>
        /// OracleDataAdapter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="selectCommand">DataAdapter의 SelectCommand속성으로 설정될 SELECT문 또는 Stored Procedure를 나타내는 OracleCommand객체</param>
        /// <returns></returns>
        public override DbDataAdapter NewDataAdapter(IDbCommand selectCommand)
        {
            return new OracleDataAdapter(selectCommand as OracleCommand);
        }
        /// <summary>
        /// OracleCommand에 지정된 Stored Procedure의 Parameter 정보를 검색하여 지정된 OracleCommand객체의 Parameters 컬렉션을 채운다.
        /// </summary>
        /// <param name="command">지정된 IDbCommand객체</param>
        public override void DeriveParameters(IDbCommand command)
        {
            OracleCommandBuilder.DeriveParameters(command as OracleCommand);
        }
        public override DbCommandBuilder NewDbCommandBuilder(DbDataAdapter adapter)
        {
            return new OracleCommandBuilder(adapter as OracleDataAdapter);
        }
    }
    #endregion

    #region MySqlFactory
    /// <summary>
    /// OleDbFactory
    /// </summary>
    internal class MySqlDbFactory : DbFactory
    {
        internal MySqlDbFactory()
        {
        }

        /// <summary>
        /// MySqlConnection객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="connString">연결 문자열</param>
        /// <returns></returns>
        public override IDbConnection NewConnection(string connString)
        {
            return new MySqlConnection(connString);
        }

        /// <summary>
        /// MySqlCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <returns></returns>
        public override IDbCommand NewCommand()
        {
            return new MySqlCommand();
        }

        /// <summary>
        /// MySqlParameter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText)
        {
            return new MySqlCommand(cmdText);
        }

        /// <summary>
        /// MySqlParameter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <param name="connection">DB연결을 나타내는 OleDbConnection객체</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText, IDbConnection connection)
        {
            return new MySqlCommand(cmdText, connection as MySqlConnection);
        }
        /// <summary>
        /// MySqlParameter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        public override IDbDataParameter NewDataParamater(string parameterName, object value)
        {
            //return new MySqlParameter(parameterName, value.ToString());
            //<MySQL 특징 : value를 ToString()하지 않고, 원래 형태로 그대로 넣어야 NULL을 허용할 수 있다. 
            //DBNull과 string.Empty를 명확히 구분(NUMBER, Decimal, Date등이 NULL일떄 명확히 구분됨)
            return new MySqlParameter(parameterName, value);
        }
        /// <summary>
        /// MySqlDataAdapter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="selectCommand">DataAdapter의 SelectCommand속성으로 설정될 SELECT문 또는 Stored Procedure를 나타내는 OleDbCommand객체</param>
        /// <returns></returns>
        public override DbDataAdapter NewDataAdapter(IDbCommand selectCommand)
        {
            return new MySqlDataAdapter(selectCommand as MySqlCommand);
        }
        /// <summary>
        /// MySqlCommand에 지정된 Stored Procedure의 Parameter 정보를 검색하여 지정된 MySqlCommand객체의 Parameters 컬렉션을 채운다.
        /// </summary>
        /// <param name="command">지정된 IDbCommand객체</param>
        public override void DeriveParameters(IDbCommand command)
        {
            MySqlCommandBuilder.DeriveParameters(command as MySqlCommand);
        }
        public override DbCommandBuilder NewDbCommandBuilder(DbDataAdapter adapter)
        {
            return new MySqlCommandBuilder(adapter as MySqlDataAdapter);
        }
    }
    #endregion

    #region OleDbFactory
    /// <summary>
    /// OleDbFactory
    /// </summary>
    internal class OleDbFactory : DbFactory
    {
        internal OleDbFactory()
        {
        }

        /// <summary>
        /// OleDbConnection객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="connString">연결 문자열</param>
        /// <returns></returns>
        public override IDbConnection NewConnection(string connString)
        {
            return new OleDbConnection(connString);
        }

        /// <summary>
        /// OleDbCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <returns></returns>
        public override IDbCommand NewCommand()
        {
            return new OleDbCommand();
        }

        /// <summary>
        /// OleDbCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText)
        {
            return new OleDbCommand(cmdText);
        }

        /// <summary>
        /// OleDbCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <param name="connection">DB연결을 나타내는 OleDbConnection객체</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText, IDbConnection connection)
        {
            return new OleDbCommand(cmdText, connection as OleDbConnection);
        }
        /// <summary>
        /// OleDbParameter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        public override IDbDataParameter NewDataParamater(string parameterName, object value)
        {
            return new OleDbParameter(parameterName, value);
        }
        /// <summary>
        /// OleDbDataAdapter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="selectCommand">DataAdapter의 SelectCommand속성으로 설정될 SELECT문 또는 Stored Procedure를 나타내는 OleDbCommand객체</param>
        /// <returns></returns>
        public override DbDataAdapter NewDataAdapter(IDbCommand selectCommand)
        {
            return new OleDbDataAdapter(selectCommand as OleDbCommand);
        }
        /// <summary>
        /// OleDbCommand에 지정된 Stored Procedure의 Parameter 정보를 검색하여 지정된 OleDbCommand객체의 Parameters 컬렉션을 채운다.
        /// </summary>
        /// <param name="command">지정된 IDbCommand객체</param>
        public override void DeriveParameters(IDbCommand command)
        {
            OleDbCommandBuilder.DeriveParameters(command as OleDbCommand);
        }
        public override DbCommandBuilder NewDbCommandBuilder(DbDataAdapter adapter)
        {
            return new OleDbCommandBuilder(adapter as OleDbDataAdapter);
        }
    }
    #endregion

    #region OdbcFactory
    /// <summary>
    /// OdbcFactory
    /// </summary>
    internal class OdbcFactory : DbFactory
    {
        internal OdbcFactory()
        {
        }

        /// <summary>
        /// OleDbConnection객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="connString">연결 문자열</param>
        /// <returns></returns>
        public override IDbConnection NewConnection(string connString)
        {
            return new OdbcConnection(connString);
        }

        /// <summary>
        /// OleDbCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <returns></returns>
        public override IDbCommand NewCommand()
        {
            return new OdbcCommand();
        }

        /// <summary>
        /// OleDbCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText)
        {
            return new OdbcCommand(cmdText);
        }

        /// <summary>
        /// OleDbCommand객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="cmdText">Query Text</param>
        /// <param name="connection">DB연결을 나타내는 OleDbConnection객체</param>
        /// <returns></returns>
        public override IDbCommand NewCommand(string cmdText, IDbConnection connection)
        {
            return new OdbcCommand(cmdText, connection as OdbcConnection);
        }
        /// <summary>
        /// OleDbParameter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        public override IDbDataParameter NewDataParamater(string parameterName, object value)
        {
            return new OdbcParameter(parameterName, value);
        }
        /// <summary>
        /// OleDbDataAdapter객체를 초기화하여 반환한다.
        /// </summary>
        /// <param name="selectCommand">DataAdapter의 SelectCommand속성으로 설정될 SELECT문 또는 Stored Procedure를 나타내는 OleDbCommand객체</param>
        /// <returns></returns>
        public override DbDataAdapter NewDataAdapter(IDbCommand selectCommand)
        {
            return new OdbcDataAdapter(selectCommand as OdbcCommand);
        }
        /// <summary>
        /// OleDbCommand에 지정된 Stored Procedure의 Parameter 정보를 검색하여 지정된 OleDbCommand객체의 Parameters 컬렉션을 채운다.
        /// </summary>
        /// <param name="command">지정된 IDbCommand객체</param>
        public override void DeriveParameters(IDbCommand command)
        {
            OdbcCommandBuilder.DeriveParameters(command as OdbcCommand);
        }
        public override DbCommandBuilder NewDbCommandBuilder(DbDataAdapter adapter)
        {
            return new OdbcCommandBuilder(adapter as OdbcDataAdapter);
        }
    }
    #endregion
}
