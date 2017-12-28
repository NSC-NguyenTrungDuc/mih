using System;
//using System.Data.SQLite;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDrugCheckingDao : IDrugCheckingDao
    {
        
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = "+ Db.Escape(tableName) + ";");

            return ((long) Db.GetScalar(query.ToString()) > 0);            
        }

        public int Insert(DrugChecking drug)
        {
            List<DrugChecking> lst = new List<DrugChecking>();
            lst.Add(drug);
            return Insert(lst, false);
        }

        public int Insert(List<DrugChecking> lst, bool isTemTable)
        {
            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    StringBuilder query = new StringBuilder();
                    query.Append(string.Format("  Insert Into  DRUG_CHECKING{0} ", isTemTable ? "_TEMP" : ""));
                    query.Append("  (DRUG_ID, BRANCH_NUMBER,A3,A4,A5,A6,A7,A8,A9,YJ_CODE,");
                    query.Append("  A11,A12,A13,A14,A15,A16,A17,A18,A19,A20,A21,A22,A23,A24,A25,A26,A27,A28) ");
                    query.Append(" 	values (@DRUG_ID, @BRANCH_NUMBER,@A3,@A4,@A5,@A6,@A7,@A8,@A9,@YJ_CODE,");
                    query.Append("  @A11,@A12,@A13,@A14,@A15,@A16,@A17,@A18,@A19,@A20,@A21,@A22,@A23,@A24,@A25,@A26,@A27,@A28)");
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (DrugChecking drug in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add(Db.CreateParameter("@DRUG_ID", DbType.String, drug.DrugId));
                            command.Parameters.Add(Db.CreateParameter("@BRANCH_NUMBER", DbType.String, drug.BranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@A3", DbType.String, drug.A3));
                            command.Parameters.Add(Db.CreateParameter("@A4", DbType.String, drug.A4));
                            command.Parameters.Add(Db.CreateParameter("@A5", DbType.String, drug.A5));
                            command.Parameters.Add(Db.CreateParameter("@A6", DbType.String, drug.A6));
                            command.Parameters.Add(Db.CreateParameter("@A7", DbType.String, drug.A7));
                            command.Parameters.Add(Db.CreateParameter("@A8", DbType.String, drug.A8));
                            command.Parameters.Add(Db.CreateParameter("@A9", DbType.String, drug.A9));
                            command.Parameters.Add(Db.CreateParameter("@YJ_CODE", DbType.String, drug.YjCode));
                            command.Parameters.Add(Db.CreateParameter("@A11", DbType.String, drug.A11));
                            command.Parameters.Add(Db.CreateParameter("@A12", DbType.String, drug.A12));
                            command.Parameters.Add(Db.CreateParameter("@A13", DbType.String, drug.A13));
                            command.Parameters.Add(Db.CreateParameter("@A14", DbType.String, drug.A14));
                            command.Parameters.Add(Db.CreateParameter("@A15", DbType.String, drug.A15));
                            command.Parameters.Add(Db.CreateParameter("@A16", DbType.String, drug.A16));
                            command.Parameters.Add(Db.CreateParameter("@A17", DbType.String, drug.A17));
                            command.Parameters.Add(Db.CreateParameter("@A18", DbType.String, drug.A18));
                            command.Parameters.Add(Db.CreateParameter("@A19", DbType.String, drug.A19));
                            command.Parameters.Add(Db.CreateParameter("@A20", DbType.String, drug.A20));
                            command.Parameters.Add(Db.CreateParameter("@A21", DbType.String, drug.A21));
                            command.Parameters.Add(Db.CreateParameter("@A22", DbType.String, drug.A22));
                            command.Parameters.Add(Db.CreateParameter("@A23", DbType.String, drug.A23));
                            command.Parameters.Add(Db.CreateParameter("@A24", DbType.String, drug.A24));
                            command.Parameters.Add(Db.CreateParameter("@A25", DbType.String, drug.A25));
                            command.Parameters.Add(Db.CreateParameter("@A26", DbType.String, drug.A26));
                            command.Parameters.Add(Db.CreateParameter("@A27", DbType.String, drug.A27));
                            command.Parameters.Add(Db.CreateParameter("@A28", DbType.String, drug.A28));

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
            query.Append(string.Format("  DELETE FROM DRUG_CHECKING{0} ",isTemTable?"_TEMP":""));

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
            query.Append("  INSERT INTO DRUG_CHECKING ");
            query.Append("  SELECT * FROM DRUG_CHECKING_TEMP");

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