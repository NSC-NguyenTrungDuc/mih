using System;
//using System.Data.SQLite;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using IHIS.Framework;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDrugInteractionDao : IDrugInteractionDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = " + Db.Escape(tableName) + ";");

            return ((long)Db.GetScalar(query.ToString()) > 0);
        }

        public int Insert(DrugInteraction drug)
        {
            List<DrugInteraction> lst = new List<DrugInteraction>();
            lst.Add(drug);
            return Insert(lst, false);
        }

        public int Insert(List<DrugInteraction> lst, bool isTemTable)
        {
            StringBuilder query = new StringBuilder();
            query.Append(string.Format("  Insert Into   DRUG_INTERACTION{0} ", isTemTable ? "_TEMP" : ""));
            query.Append("  (DRUG_ID, BRANCH_NUMBER, YJ9_CODE, DESCRIBED_CLASSIFICATION,A5,");
            query.Append("  A6,A7,A8,A9,ORDER_NOTE,A11,COMMENT)");
            query.Append(" 	values (@DRUG_ID, @BRANCH_NUMBER, @YJ9_CODE, @DESCRIBED_CLASSIFICATION,@A5,");
            query.Append("  @A6,@A7,@A8,@A9,@ORDER_NOTE,@A11,@COMMENT)");

            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (DrugInteraction drug in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add(Db.CreateParameter("@DRUG_ID", DbType.String, drug.DrugId));
                            command.Parameters.Add(Db.CreateParameter("@BRANCH_NUMBER", DbType.String, drug.BranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@YJ9_CODE", DbType.String, drug.Yj9Code));
                            command.Parameters.Add(Db.CreateParameter("@DESCRIBED_CLASSIFICATION", DbType.String, drug.DescribedClassification));
                            command.Parameters.Add(Db.CreateParameter("@A5", DbType.String, drug.A5));
                            command.Parameters.Add(Db.CreateParameter("@A6", DbType.String, drug.A6));
                            command.Parameters.Add(Db.CreateParameter("@A7", DbType.String, drug.A7));
                            command.Parameters.Add(Db.CreateParameter("@A8", DbType.String, drug.A8));
                            command.Parameters.Add(Db.CreateParameter("@A9", DbType.String, drug.A9));
                            command.Parameters.Add(Db.CreateParameter("@ORDER_NOTE", DbType.String, drug.OrderNote));
                            command.Parameters.Add(Db.CreateParameter("@A11", DbType.String, drug.A11));
                            command.Parameters.Add(Db.CreateParameter("@COMMENT", DbType.String, drug.Comment));
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
            query.Append(string.Format("  DELETE FROM DRUG_INTERACTION{0} ", isTemTable ? "_TEMP" : ""));

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
            query.Append("  INSERT INTO DRUG_INTERACTION ");
            query.Append("  SELECT * FROM DRUG_INTERACTION_TEMP");

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

        public DataTable CheckInteraction(DataTable grdOrderOld, DataTable grdOrderNew)
        {
            //create dataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("HANGMOG_CODE", typeof(string));
            dataTable.Columns.Add("HANGMOG_NAME", typeof(string));
            dataTable.Columns.Add("HANGMOG_CODE_INTERACTION", typeof(string));
            dataTable.Columns.Add("HANGMOG_NAME_INTERACTION", typeof(string));
            dataTable.Columns.Add("DESCRIBED_CLASSIFICATION_NOTE", typeof(string));

            try
            {
                foreach (DataRow rowOld in grdOrderOld.Rows)
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("  SELECT X.DESCRIBED_CLASSIFICATION_NOTE");
                    query.Append("  FROM DRUG_CHECKING A, DRUG_INTERACTION B, DRUG_GENERIC_NAME C, CLASSIFICATION X");
                    query.Append("  WHERE ");
                    query.Append("  A.DRUG_ID						=		B.DRUG_ID								AND");
                    query.Append("  A.BRANCH_NUMBER					=		B.BRANCH_NUMBER							AND");
                    query.Append("  B.DRUG_ID						=		C.DRUG_ID								AND");
                    query.Append("  B.BRANCH_NUMBER					=		C.BRANCH_NUMBER							AND");
                    query.Append("  B.DESCRIBED_CLASSIFICATION		=		C.DESCRIBED_CLASSIFICATION				AND");
                    query.Append("  B.ORDER_NOTE					=		C.ORDER_NOTE							AND");
                    query.Append("  B.DESCRIBED_CLASSIFICATION		=		X.DESCRIBED_CLASSIFICATION				AND");

                    query.Append("  A.YJ_CODE					    =		'" + rowOld["yj_code"].ToString() + "' AND");
                    query.Append("  (C.YJ9_CODE_EFFECT			    =	'" + grdOrderNew.Rows[0]["yj_code"].ToString().Substring(0, 9) + "' OR");
                    query.Append("   C.YJ9_CODE			            =	'" + grdOrderNew.Rows[0]["yj_code"].ToString().Substring(0,9) + "' )");

                    Logs.WriteLog("Query InteractionCheck: " + query.ToString());

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
                                    String note = reader["DESCRIBED_CLASSIFICATION_NOTE"].ToString();
                                    dataTable.Rows.Add(rowOld["hangmog_code"].ToString(), rowOld["hangmog_name"].ToString(), grdOrderNew.Rows[0]["hangmog_code"].ToString(),
                                        grdOrderNew.Rows[0]["hangmog_name"].ToString(), note);

                                    Logs.WriteLog("HangmogCode: " + rowOld["hangmog_code"].ToString());

                                    break;
                                }

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


        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.CACHE; }
        }

        #endregion
    }
}