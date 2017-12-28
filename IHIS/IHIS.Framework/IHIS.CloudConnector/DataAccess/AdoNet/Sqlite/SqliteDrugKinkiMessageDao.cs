using System;
//using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Collections.Generic;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDrugKinkiMessageDao : IDrugKinkiMessageDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = " + Db.Escape(tableName) + ";");

            return ((long)Db.GetScalar(query.ToString()) > 0);
        }

        public int Insert(DrugKinkiMessage drug)
        {
            List<DrugKinkiMessage> lst = new List<DrugKinkiMessage>();
            lst.Add(drug);
            return Insert(lst, false);
        }

        public int Insert(List<DrugKinkiMessage> lst, bool isTemTable)
        {
            StringBuilder query = new StringBuilder();
            query.Append(string.Format("  Insert Into   DRUG_KINKI_MESSAGE{0} ", isTemTable ? "_TEMP" : ""));
            query.Append("  (DRUG_ID, BRANCH_NUMBER, WARNING_LEVEL, KINKI_ID,               ");
            query.Append("  MESSAGE, CATEGORY)                                              ");
            query.Append(" 	values (@DRUG_ID, @BRANCH_NUMBER, @WARNING_LEVEL, @KINKI_ID,    ");
            query.Append("  @MESSAGE, @CATEGORY)                                            ");

            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (DrugKinkiMessage drug in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add(Db.CreateParameter("@DRUG_ID", DbType.String, drug.DrugId));
                            command.Parameters.Add(Db.CreateParameter("@BRANCH_NUMBER", DbType.String, drug.BranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@WARNING_LEVEL", DbType.String, drug.WarningLevel));
                            command.Parameters.Add(Db.CreateParameter("@KINKI_ID", DbType.String, drug.KinkiId));
                            command.Parameters.Add(Db.CreateParameter("@MESSAGE", DbType.String, drug.Message));
                            command.Parameters.Add(Db.CreateParameter("@CATEGORY", DbType.String, drug.Category));

                            command.ExecuteNonQuery();
                        }
                        trans.Commit();
                        return 0;
                    }
                    catch
                    {
                        trans.Rollback();
                        return -1;
                    }
                }
            }
        }

        public int Truncate()
        {
            return Truncate(false);
        }

        public int Truncate(bool isTemTable)
        {
            StringBuilder query = new StringBuilder();
            query.Append(string.Format("  DELETE FROM DRUG_KINKI_MESSAGE{0} ", isTemTable ? "_TEMP" : ""));

            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    command.CommandText = query.ToString();
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }


        public int CopyData()
        {
            StringBuilder query = new StringBuilder();
            query.Append("  INSERT INTO DRUG_KINKI_MESSAGE ");
            query.Append("  SELECT * FROM DRUG_KINKI_MESSAGE_TEMP");

            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    command.CommandText = query.ToString();
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public DataTable CheckKinki(DataTable grdOrder, DataTable grdOutSang)
        {
            //create dataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("HANGMOG_CODE", typeof(string));
            dataTable.Columns.Add("HANGMOG_NAME", typeof(string));
            dataTable.Columns.Add("SANG_CODE", typeof(string));
            dataTable.Columns.Add("SANG_NAME", typeof(string));
            dataTable.Columns.Add("WARNING_LEVEL", typeof(string));
            dataTable.Columns.Add("MESSAGE", typeof(string));

            try
            {
                //collect string
                String listOrder = CollectStringFromDataTable(grdOrder, "hangmog_code");
                String listOutSang = CollectStringFromDataTable(grdOutSang, "sang_code");
                String listYj = CollectStringFromDataTable(grdOrder, "yj_code");

                StringBuilder query = new StringBuilder();
                query.Append("  Select C.YJ_CODE, A.DISEASE_CODE, X.MESSAGE_LEVEL	,B.MESSAGE	");
                query.Append("  From DRUG_KINKI_DISEASE A, DRUG_KINKI_MESSAGE B, DRUG_CHECKING C, WARNING X ");
                query.Append("  WHERE ");
                query.Append("  A.DISEASE_CODE in " + listOutSang + "		AND");
                query.Append("  A.KINKI_ID					=	B.KINKI_ID							AND");
                query.Append("  B.DRUG_ID						=	C.DRUG_ID							AND");
                query.Append("  B.BRANCH_NUMBER				=	C.BRANCH_NUMBER						AND");
                query.Append("  B.WARNING_LEVEL				=	X.WARNING_LEVEL						AND");
                query.Append("  C.YJ_CODE in " + listYj);

                Logs.WriteLog("Query KinkiCheck: " + query.ToString());

                using (DbConnection connection = Db.CreateConnection())
                {
                    using (DbCommand command = Db.CreateCommand())
                    {
                        command.CommandText = query.ToString();
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;
                        connection.Open();
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                String hangmog_code = GetHangmogCode(grdOrder, reader["YJ_CODE"].ToString());
                                String hangmog_name = GetHangmogName(grdOrder, reader["YJ_CODE"].ToString());
                                String outsang_name = GetOutSangName(grdOutSang, reader["DISEASE_CODE"].ToString());
                                dataTable.Rows.Add(hangmog_code, hangmog_name, reader["DISEASE_CODE"].ToString(), outsang_name, reader["MESSAGE_LEVEL"].ToString(), reader["MESSAGE"].ToString());
                                Logs.WriteLog("HangmogCode: " + hangmog_code);
                            }
                        }
                    }
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dataTable;
            }
        }

        private static string GetHangmogCode(DataTable grdOrder, string p)
        {
            foreach (DataRow row in grdOrder.Rows)
            {
                if (row["yj_code"].ToString().Equals(p))
                {
                    return row["hangmog_code"].ToString();
                }
            }
            return "";
        }

        private static string GetOutSangName(DataTable grdOutSang, string p)
        {
            foreach (DataRow row in grdOutSang.Rows)
            {
                if (row["sang_code"].ToString().Equals(p))
                {
                    return row["sang_name"].ToString();
                }
            }
            return "";
        }

        private static string GetHangmogName(DataTable grdOrder, string p)
        {
            foreach (DataRow row in grdOrder.Rows)
            {
                if (row["yj_code"].ToString().Equals(p))
                {
                    return row["hangmog_name"].ToString();
                }
            }
            return "";
        }

        public static string CollectStringFromDataTable(DataTable dt, string columnName)
        {
            string result = "(";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result += "'" + dt.Rows[i][columnName].ToString() + "'";
                if (i < dt.Rows.Count - 1) result += ",";
            }
            result += ")";
            return result;
        }

        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.CACHE; }
        }

        #endregion
    }
}