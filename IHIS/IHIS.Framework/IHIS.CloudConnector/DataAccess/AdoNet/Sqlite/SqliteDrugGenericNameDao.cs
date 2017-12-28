using System;
//using System.Data.SQLite;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDrugGenericNameDao : IDrugGenericNameDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = " + Db.Escape(tableName) + ";");

            return ((long)Db.GetScalar(query.ToString()) > 0);
        }

        public int Insert(DrugGenericName drug)
        {
            List<DrugGenericName> lst = new List<DrugGenericName>();
            lst.Add(drug);
            return Insert(lst, false);
        }

        public int Insert(List<DrugGenericName> lst, bool isTemTable)
        {
            StringBuilder query = new StringBuilder();
            query.Append(string.Format("  Insert Into   DRUG_GENERIC_NAME{0} ", isTemTable ? "_TEMP" : ""));
            query.Append("  (DRUG_ID, BRANCH_NUMBER, YJ9_CODE, DESCRIBED_CLASSIFICATION,ORDER_NOTE,");
            query.Append("  A6,YJ9_CODE_EFFECT,A8,COMMENT1,COMMENT2)");
            query.Append(" 	values (@DRUG_ID, @BRANCH_NUMBER, @YJ9_CODE, @DESCRIBED_CLASSIFICATION,@ORDER_NOTE,");
            query.Append("  @A6,@YJ9_CODE_EFFECT,@A8,@COMMENT1,@COMMENT2)");

            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (DrugGenericName drug in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add(Db.CreateParameter("@DRUG_ID", DbType.String, drug.DrugId));
                            command.Parameters.Add(Db.CreateParameter("@BRANCH_NUMBER", DbType.String, drug.BranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@YJ9_CODE", DbType.String, drug.Yj9Code));
                            command.Parameters.Add(Db.CreateParameter("@DESCRIBED_CLASSIFICATION", DbType.String, drug.DescribedClassification));
                            command.Parameters.Add(Db.CreateParameter("@ORDER_NOTE", DbType.String, drug.OrderNote));
                            command.Parameters.Add(Db.CreateParameter("@A6", DbType.String, drug.A6));
                            command.Parameters.Add(Db.CreateParameter("@YJ9_CODE_EFFECT", DbType.String, drug.Yj9CodeEffect));
                            command.Parameters.Add(Db.CreateParameter("@A8", DbType.String, drug.A8));
                            command.Parameters.Add(Db.CreateParameter("@COMMENT1", DbType.String, drug.Comment1));
                            command.Parameters.Add(Db.CreateParameter("@COMMENT2", DbType.String, drug.Comment2));
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
            query.Append(string.Format("  DELETE FROM DRUG_GENERIC_NAME{0} ", isTemTable ? "_TEMP" : ""));

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
            query.Append("  INSERT INTO DRUG_GENERIC_NAME ");
            query.Append("  SELECT * FROM DRUG_GENERIC_NAME_TEMP");

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

        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.CACHE; }
        }

        #endregion
    }
}