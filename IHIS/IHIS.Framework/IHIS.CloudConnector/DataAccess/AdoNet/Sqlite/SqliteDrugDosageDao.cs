using System;
//using System.Data.SQLite;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDrugDosageDao : IDrugDosageDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = " + Db.Escape(tableName) + ";");

            return ((long)Db.GetScalar(query.ToString()) > 0);
        }

        public int Insert(DrugDosage drug)
        {
            List<DrugDosage> lst = new List<DrugDosage>();
            lst.Add(drug);
            return Insert(lst, false);
        }

        public int Insert(List<DrugDosage> lst, bool isTemTable)
        {
            StringBuilder query = new StringBuilder();
            query.Append(string.Format("  Insert Into   DRUG_DOSAGE{0} ", isTemTable ? "_TEMP" : ""));
            query.Append("  (DRUG_ID, BRANCH_NUMBER, DOSAGE_BRANCH_NUMBER, A4,A5,ADAPTATION,");
            query.Append("  ADAPTATION_RELATED, A8,AGE_CLASSIFICATION,APPROPRIATE,APPROPRIATE_CONDITION,A12,A13,ONE_DOSE)                                              ");
            query.Append(" 	values (@DRUG_ID, @BRANCH_NUMBER, @DOSAGE_BRANCH_NUMBER, @A4,@A5,@ADAPTATION,  ");
            query.Append("  @ADAPTATION_RELATED, @A8,@AGE_CLASSIFICATION,@APPROPRIATE,@APPROPRIATE_CONDITION,@A12,@A13,@ONE_DOSE)                                            ");

            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (DrugDosage drug in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add(Db.CreateParameter("@DRUG_ID", DbType.String, drug.DrugId));
                            command.Parameters.Add(Db.CreateParameter("@BRANCH_NUMBER", DbType.String, drug.BranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@DOSAGE_BRANCH_NUMBER", DbType.String, drug.DosageBranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@A4", DbType.String, drug.A4));
                            command.Parameters.Add(Db.CreateParameter("@A5", DbType.String, drug.A5));
                            command.Parameters.Add(Db.CreateParameter("@ADAPTATION", DbType.String, drug.Adaptation));
                            command.Parameters.Add(Db.CreateParameter("@ADAPTATION_RELATED", DbType.String, drug.AdaptationRelated));
                            command.Parameters.Add(Db.CreateParameter("@A8", DbType.String, drug.A8));
                            command.Parameters.Add(Db.CreateParameter("@AGE_CLASSIFICATION", DbType.String, drug.AgeClassification));
                            command.Parameters.Add(Db.CreateParameter("@APPROPRIATE", DbType.String, drug.Appropriate));
                            command.Parameters.Add(Db.CreateParameter("@APPROPRIATE_CONDITION", DbType.String, drug.AppropriateCondition));
                            command.Parameters.Add(Db.CreateParameter("@A12", DbType.String, drug.A12));
                            command.Parameters.Add(Db.CreateParameter("@A13", DbType.String, drug.A13));
                            command.Parameters.Add(Db.CreateParameter("@ONE_DOSE", DbType.String, drug.OneDose));

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
            query.Append(string.Format("  DELETE FROM DRUG_DOSAGE{0} ", isTemTable ? "_TEMP" : ""));

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
            query.Append("  INSERT INTO DRUG_DOSAGE ");
            query.Append("  SELECT * FROM DRUG_DOSAGE_TEMP");

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

        public DataTable CheckDosage(DataTable grdOrder)
        {
            //create dataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("HANGMOG_CODE", typeof(string));
            dataTable.Columns.Add("HANGMOG_NAME", typeof(string));
            dataTable.Columns.Add("ADAPTATION", typeof(string));
            dataTable.Columns.Add("ADAPTATION_RELATED", typeof(string));
            dataTable.Columns.Add("AGE_CLASSIFICATION", typeof(string));
            dataTable.Columns.Add("APPROPRIATE", typeof(string));
            dataTable.Columns.Add("APPROPRIATE_CONDITION", typeof(string));
            dataTable.Columns.Add("A12", typeof(string));
            dataTable.Columns.Add("A13", typeof(string));
            dataTable.Columns.Add("ONE_DOSE", typeof(string));
            dataTable.Columns.Add("DAILY_DOSE", typeof(string));
            dataTable.Columns.Add("DAILY_DOSE_CONTENT", typeof(string));
            dataTable.Columns.Add("DOSE_FORM", typeof(string));
            dataTable.Columns.Add("DAILY_DOSE_FORM", typeof(string));
            dataTable.Columns.Add("DOSAGE_FORM_UNIT", typeof(string));
            dataTable.Columns.Add("DAILY_NUMBER_DOSES", typeof(string));
            dataTable.Columns.Add("A23", typeof(string));
            dataTable.Columns.Add("A24", typeof(string));
            dataTable.Columns.Add("A25", typeof(string));
            dataTable.Columns.Add("A26", typeof(string));
            dataTable.Columns.Add("A27", typeof(string));
            dataTable.Columns.Add("A28", typeof(string));
            dataTable.Columns.Add("A29", typeof(string));
            dataTable.Columns.Add("A30", typeof(string));

            try
            {
                String hangmog_code = grdOrder.Rows[0]["hangmog_code"].ToString();
                String hangmog_name = grdOrder.Rows[0]["hangmog_name"].ToString();
                String yj_code = grdOrder.Rows[0]["yj_code"].ToString();

                StringBuilder query = new StringBuilder();
                query.Append("  SELECT ");
                query.Append("	A.YJ_CODE				,");
                query.Append("	B.ADAPTATION			,");
                query.Append("	B.ADAPTATION_RELATED	,");
                query.Append("	B.AGE_CLASSIFICATION	,");
                query.Append("	B.APPROPRIATE			,");
                query.Append("	B.APPROPRIATE_CONDITION	,");
                query.Append("	B.A12					,");
                query.Append("	B.A13					,");
                query.Append("	B.ONE_DOSE				,");
                query.Append("	C.DAILY_DOSE			,");
                query.Append("	C.DAILY_DOSE_CONTENT	,");
                query.Append("	C.DOSE_FORM				,");
                query.Append("	C.DAILY_DOSE_FORM		,");
                query.Append("	C.DOSAGE_FORM_UNIT		,");
                query.Append("	C.DAILY_NUMBER_DOSES	,");
                query.Append("	C.A23					,");
                query.Append("	C.A24					,");
                query.Append("	C.A25					,");
                query.Append("	C.A26					,");
                query.Append("	C.A27					,");
                query.Append("	C.A28					,");
                query.Append("	C.A29					,");
                query.Append("	C.A30					 ");
                query.Append("  From DRUG_CHECKING A, DRUG_DOSAGE B, DRUG_DOSAGE_NORMAL C ");
                query.Append("  WHERE ");
                query.Append(String.Format("    A.YJ_CODE	=		'{0}'								        AND", yj_code));
                query.Append("  A.DRUG_ID					=		B.DRUG_ID									AND");
                query.Append("  A.BRANCH_NUMBER			    =		B.BRANCH_NUMBER								AND");
                query.Append("  C.DRUG_ID					=		B.DRUG_ID									AND");
                query.Append("  C.BRANCH_NUMBER			    =		B.BRANCH_NUMBER								AND");
                query.Append("  C.DOSAGE_BRANCH_NUMBER	    =		B.DOSAGE_BRANCH_NUMBER						   ");

                Logs.WriteLog("Query DosageCheck: " + query.ToString());

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
                                dataTable.Rows.Add(hangmog_code, hangmog_name, reader["ADAPTATION"].ToString(), reader["ADAPTATION_RELATED"].ToString(), reader["AGE_CLASSIFICATION"].ToString(),
                                    reader["APPROPRIATE"].ToString(), reader["APPROPRIATE_CONDITION"].ToString(), reader["A12"].ToString(), reader["A13"].ToString(),
                                    reader["ONE_DOSE"].ToString(), reader["DAILY_DOSE"].ToString(), reader["DAILY_DOSE_CONTENT"].ToString(), reader["DOSE_FORM"].ToString(),
                                    reader["DAILY_DOSE_FORM"].ToString(), reader["DOSAGE_FORM_UNIT"].ToString(), reader["DAILY_NUMBER_DOSES"].ToString(), reader["A23"].ToString(),
                                    reader["A24"].ToString(), reader["A25"].ToString(), reader["A26"].ToString(), reader["A27"].ToString(),
                                    reader["A28"].ToString(), reader["A29"].ToString(), reader["A30"].ToString());

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

        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.CACHE; }
        }

        #endregion
    }
}