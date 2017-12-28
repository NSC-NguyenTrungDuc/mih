using System;
//using System.Data.SQLite;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteOrderTempDao : IOrderTempDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = "+ Db.Escape(tableName) + ";");

            return ((long) Db.GetScalar(query.ToString()) > 0);            
        }

        public bool UpdateTemp(DataTable grdOrder, DataTable grdDisease)
        {
            try
            {
                StringBuilder query = new StringBuilder();
                query.Append(" DELETE *                              ");
                query.Append(" FROM                                  ");
                query.Append(" main.DISEASE_TEMP , main.ORDER_TEMP   ");

                using (DbConnection connection = Db.CreateConnection())
                {
                    using (DbCommand command = Db.CreateCommand())
                    {
                        command.CommandText = query.ToString();
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        //using (DbDataReader reader = command.ExecuteReader())
                        //{
                        //    while (reader.Read())
                        //    {
                        //        Customer customer = new Customer();
                        //        customer.Id = Int32.Parse(reader["Id"].ToString());
                        //        customer.Name = reader["Name"].ToString();
                        //        customer.Dob = Int32.Parse(reader["DoB"].ToString());
                        //        return customer;
                        //    }
                        //}
                        int result = command.ExecuteNonQuery();
                        if (result <= 0) return false;
                        foreach (DataRow rowOrder in grdOrder.Rows)
                        {
                            query = new StringBuilder();
                            query.Append("INSERT INTO ORDER_TEMP (YJ_CODE, YJ_NAME) ");
                            query.Append(String.Format("VALUES('{0}','{1}')", rowOrder["hangmog_code"].ToString(), rowOrder["hangmog_name"].ToString()));
                            command.CommandText = query.ToString();
                            int resultInsert = command.ExecuteNonQuery();
                            if (resultInsert <= 0)
                            {
                                return false;
                            }
                        }

                        foreach (DataRow rowDisease in grdDisease.Rows)
                        {
                            query = new StringBuilder();
                            query.Append("INSERT INTO DISEASE_TEMP (SANG_CODE, SANG_NAME) ");
                            query.Append(String.Format("VALUES('{0}','{1}')", rowDisease["sang_code"].ToString(), rowDisease["sang_name"].ToString()));
                            command.CommandText = query.ToString();
                            int resultInsert = command.ExecuteNonQuery();
                            if (resultInsert <= 0)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }

                //return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.CACHE; }
        }

        #endregion
    }
}