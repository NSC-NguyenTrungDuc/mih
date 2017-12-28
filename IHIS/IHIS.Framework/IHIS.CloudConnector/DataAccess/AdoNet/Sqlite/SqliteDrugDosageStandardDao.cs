using System;
//using System.Data.SQLite;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDrugDosageStandardDao : IDrugDosageStandardDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = " + Db.Escape(tableName) + ";");

            return ((long)Db.GetScalar(query.ToString()) > 0);
        }

        public int Insert(DrugDosageStandard drug)
        {
            List<DrugDosageStandard> lst = new List<DrugDosageStandard>();
            lst.Add(drug);
            return Insert(lst, false);
        }

        public int Insert(List<DrugDosageStandard> lst, bool isTemTable)
        {
            StringBuilder query = new StringBuilder();
            query.Append(string.Format("  Insert Into   DRUG_DOSAGE_STANDARD{0} ", isTemTable ? "_TEMP" : ""));
            query.Append("  (DRUG_ID, BRANCH_NUMBER, DOSAGE_BRANCH_NUMBER, A44,A45,A46,A47,A48,A49,A50,A51,A52,A53,");
            query.Append("  A54, A55,A56,A57,A58,A59,A60,A61,A62,A63,A64,A65,A66,A67,A68,A69,A70,A71,A72)");
            query.Append(" 	values (@DRUG_ID, @BRANCH_NUMBER, @DOSAGE_BRANCH_NUMBER,@A44,@A45,@A46,@A47,@A48,@A49,@A50,@A51,@A52,@A53,");
            query.Append("  @A54, @A55,@A56,@A57,@A58,@A59,@A60,@A61,@A62,@A63,@A64,@A65,@A66,@A67,@A68,@A69,@A70,@A71,@A72)");

            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (DrugDosageStandard drug in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add(Db.CreateParameter("@DRUG_ID", DbType.String, drug.DrugId));
                            command.Parameters.Add(Db.CreateParameter("@BRANCH_NUMBER", DbType.String, drug.BranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@DOSAGE_BRANCH_NUMBER", DbType.String, drug.DosageBranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@A44", DbType.String, drug.A44));
                            command.Parameters.Add(Db.CreateParameter("@A45", DbType.String, drug.A45));
                            command.Parameters.Add(Db.CreateParameter("@A46", DbType.String, drug.A46));
                            command.Parameters.Add(Db.CreateParameter("@A47", DbType.String, drug.A47));
                            command.Parameters.Add(Db.CreateParameter("@A48", DbType.String, drug.A48));
                            command.Parameters.Add(Db.CreateParameter("@A49", DbType.String, drug.A49));
                            command.Parameters.Add(Db.CreateParameter("@A50", DbType.String, drug.A50));
                            command.Parameters.Add(Db.CreateParameter("@A51", DbType.String, drug.A51));
                            command.Parameters.Add(Db.CreateParameter("@A52", DbType.String, drug.A52));
                            command.Parameters.Add(Db.CreateParameter("@A53", DbType.String, drug.A53));
                            command.Parameters.Add(Db.CreateParameter("@A54", DbType.String, drug.A54));
                            command.Parameters.Add(Db.CreateParameter("@A55", DbType.String, drug.A55));
                            command.Parameters.Add(Db.CreateParameter("@A56", DbType.String, drug.A56));
                            command.Parameters.Add(Db.CreateParameter("@A57", DbType.String, drug.A57));
                            command.Parameters.Add(Db.CreateParameter("@A58", DbType.String, drug.A58));
                            command.Parameters.Add(Db.CreateParameter("@A59", DbType.String, drug.A59));
                            command.Parameters.Add(Db.CreateParameter("@A60", DbType.String, drug.A60));
                            command.Parameters.Add(Db.CreateParameter("@A61", DbType.String, drug.A61));
                            command.Parameters.Add(Db.CreateParameter("@A62", DbType.String, drug.A62));
                            command.Parameters.Add(Db.CreateParameter("@A63", DbType.String, drug.A63));
                            command.Parameters.Add(Db.CreateParameter("@A64", DbType.String, drug.A64));
                            command.Parameters.Add(Db.CreateParameter("@A65", DbType.String, drug.A65));
                            command.Parameters.Add(Db.CreateParameter("@A66", DbType.String, drug.A66));
                            command.Parameters.Add(Db.CreateParameter("@A67", DbType.String, drug.A67));
                            command.Parameters.Add(Db.CreateParameter("@A68", DbType.String, drug.A68));
                            command.Parameters.Add(Db.CreateParameter("@A69", DbType.String, drug.A69));
                            command.Parameters.Add(Db.CreateParameter("@A70", DbType.String, drug.A70));
                            command.Parameters.Add(Db.CreateParameter("@A71", DbType.String, drug.A71));
                            command.Parameters.Add(Db.CreateParameter("@A72", DbType.String, drug.A72));
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
            query.Append(string.Format("  DELETE FROM DRUG_DOSAGE_STANDARD{0} ", isTemTable ? "_TEMP" : ""));

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
            query.Append("  INSERT INTO DRUG_DOSAGE_STANDARD ");
            query.Append("  SELECT * FROM DRUG_DOSAGE_STANDARD_TEMP");

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