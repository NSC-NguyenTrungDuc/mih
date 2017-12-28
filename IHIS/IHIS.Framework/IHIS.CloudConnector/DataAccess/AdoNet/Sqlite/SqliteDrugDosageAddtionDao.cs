using System;
//using System.Data.SQLite;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDrugDosageAddtionDao : IDrugDosageAddtionDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = "+ Db.Escape(tableName) + ";");

            return ((long) Db.GetScalar(query.ToString()) > 0);            
        }

        public int Insert(DrugDosageAddtion drug)
        {
            List<DrugDosageAddtion> lst = new List<DrugDosageAddtion>();
            lst.Add(drug);
            return Insert(lst, false);
        }

        public int Insert(List<DrugDosageAddtion> lst, bool isTemTable)
        {
            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append(string.Format("  Insert Into   DRUG_DOSAGE_ADDITION{0} ", isTemTable ? "_TEMP" : ""));
                    query.Append("  (DRUG_ID, BRANCH_NUMBER, DOSAGE_BRANCH_NUMBER, A73,A74,A75,A76,A77,A78,A79,A80,A81,A82,");
                    query.Append("  A83, A84,A85,A86,A87,A88,A89,A90,A91,A92,A93,A94,A95,A96,A97,A98,A99,A100,A101)                                              ");
                    query.Append(" 	values (@DRUG_ID, @BRANCH_NUMBER, @DOSAGE_BRANCH_NUMBER, @A73,@A74,@A75,@A76,@A77,@A78,@A79,@A80,@A81,@A82,  ");
                    query.Append("  @A83,@A84,@A85,@A86,@A87,@A88,@A89,@A90,@A91,@A92,@A93,@A94,@A95,@A96,@A97,@A98,@A99,@A100,@A101)                                            ");

                    command.Connection = connection;
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (DrugDosageAddtion drug in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add(Db.CreateParameter("@DRUG_ID", DbType.String, drug.DrugId));
                            command.Parameters.Add(Db.CreateParameter("@BRANCH_NUMBER", DbType.String, drug.BranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@DOSAGE_BRANCH_NUMBER", DbType.String, drug.DosageBranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@A73", DbType.String, drug.A73));
                            command.Parameters.Add(Db.CreateParameter("@A74", DbType.String, drug.A74));
                            command.Parameters.Add(Db.CreateParameter("@A75", DbType.String, drug.A75));
                            command.Parameters.Add(Db.CreateParameter("@A76", DbType.String, drug.A76));
                            command.Parameters.Add(Db.CreateParameter("@A77", DbType.String, drug.A77));
                            command.Parameters.Add(Db.CreateParameter("@A78", DbType.String, drug.A78));
                            command.Parameters.Add(Db.CreateParameter("@A79", DbType.String, drug.A79));
                            command.Parameters.Add(Db.CreateParameter("@A80", DbType.String, drug.A80));
                            command.Parameters.Add(Db.CreateParameter("@A81", DbType.String, drug.A81));
                            command.Parameters.Add(Db.CreateParameter("@A82", DbType.String, drug.A82));
                            command.Parameters.Add(Db.CreateParameter("@A83", DbType.String, drug.A83));
                            command.Parameters.Add(Db.CreateParameter("@A84", DbType.String, drug.A84));
                            command.Parameters.Add(Db.CreateParameter("@A85", DbType.String, drug.A85));
                            command.Parameters.Add(Db.CreateParameter("@A86", DbType.String, drug.A86));
                            command.Parameters.Add(Db.CreateParameter("@A87", DbType.String, drug.A87));
                            command.Parameters.Add(Db.CreateParameter("@A88", DbType.String, drug.A88));
                            command.Parameters.Add(Db.CreateParameter("@A89", DbType.String, drug.A89));
                            command.Parameters.Add(Db.CreateParameter("@A90", DbType.String, drug.A90));
                            command.Parameters.Add(Db.CreateParameter("@A91", DbType.String, drug.A91));
                            command.Parameters.Add(Db.CreateParameter("@A92", DbType.String, drug.A92));
                            command.Parameters.Add(Db.CreateParameter("@A93", DbType.String, drug.A93));
                            command.Parameters.Add(Db.CreateParameter("@A94", DbType.String, drug.A94));
                            command.Parameters.Add(Db.CreateParameter("@A95", DbType.String, drug.A95));
                            command.Parameters.Add(Db.CreateParameter("@A96", DbType.String, drug.A96));
                            command.Parameters.Add(Db.CreateParameter("@A97", DbType.String, drug.A97));
                            command.Parameters.Add(Db.CreateParameter("@A98", DbType.String, drug.A98));
                            command.Parameters.Add(Db.CreateParameter("@A99", DbType.String, drug.A99));
                            command.Parameters.Add(Db.CreateParameter("@A100", DbType.String, drug.A100));
                            command.Parameters.Add(Db.CreateParameter("@A101", DbType.String, drug.A101));

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
            query.Append(string.Format("  DELETE FROM DRUG_DOSAGE_ADDITION{0} ", isTemTable ? "_TEMP" : ""));

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
            query.Append("  INSERT INTO DRUG_DOSAGE_ADDITION ");
            query.Append("  SELECT * FROM DRUG_DOSAGE_ADDITION_TEMP");

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