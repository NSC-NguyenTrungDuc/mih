using System;
//using System.Data.SQLite;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDrugDosageNormalDao : IDrugDosageNormalDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = "+ Db.Escape(tableName) + ";");

            return ((long) Db.GetScalar(query.ToString()) > 0);            
        }
        public int Insert(DrugDosageNormal drug)
        {
            List<DrugDosageNormal> lst = new List<DrugDosageNormal>();
            lst.Add(drug);
            return Insert(lst, false);
        }

        public int Insert(List<DrugDosageNormal> lst, bool isTemTable)
        {
            StringBuilder query = new StringBuilder();
            query.Append(string.Format("  Insert Into   DRUG_DOSAGE_NORMAL{0} ", isTemTable ? "_TEMP" : ""));
            query.Append("  (DRUG_ID, BRANCH_NUMBER, DOSAGE_BRANCH_NUMBER, DAILY_DOSE,DAILY_DOSE_CONTENT,DOSE_FORM,DAILY_DOSE_FORM,DOSAGE_FORM_UNIT,DAILY_NUMBER_DOSES,A21,A22,A23,A24,");
            query.Append("  A25, A26,A27,A28,A29,A30,A31,A32,A33,A34,A35,A36,A37,A38,A39,A40,A41,A42,A43)");
            query.Append(" 	values (@DRUG_ID, @BRANCH_NUMBER, @DOSAGE_BRANCH_NUMBER, @DAILY_DOSE,@DAILY_DOSE_CONTENT,@DOSE_FORM,@DAILY_DOSE_FORM,@DOSAGE_FORM_UNIT,@DAILY_NUMBER_DOSES,@A21,@A22,@A23,@A24,  ");
            query.Append("  @A25,@A26,@A27,@A28,@A29,@A30,@A31,@A32,@A33,@A34,@A35,@A36,@A37,@A38,@A39,@A40,@A41,@A42,@A43)");

            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (DrugDosageNormal drug in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add(Db.CreateParameter("@DRUG_ID", DbType.String, drug.DrugId));
                            command.Parameters.Add(Db.CreateParameter("@BRANCH_NUMBER", DbType.String, drug.BranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@DOSAGE_BRANCH_NUMBER", DbType.String, drug.DosageBranchNumber));
                            command.Parameters.Add(Db.CreateParameter("@DAILY_DOSE", DbType.String, drug.DailyDose));
                            command.Parameters.Add(Db.CreateParameter("@DAILY_DOSE_CONTENT", DbType.String, drug.DailyDoseContent));
                            command.Parameters.Add(Db.CreateParameter("@DOSE_FORM", DbType.String, drug.DoseForm));
                            command.Parameters.Add(Db.CreateParameter("@DAILY_DOSE_FORM", DbType.String, drug.DailyDoseForm));
                            command.Parameters.Add(Db.CreateParameter("@DOSAGE_FORM_UNIT", DbType.String, drug.DosageFormUnit));
                            command.Parameters.Add(Db.CreateParameter("@DAILY_NUMBER_DOSES", DbType.String, drug.DailyNumberDoses));
                            command.Parameters.Add(Db.CreateParameter("@A21", DbType.String, drug.A21));
                            command.Parameters.Add(Db.CreateParameter("@A22", DbType.String, drug.A22));
                            command.Parameters.Add(Db.CreateParameter("@A23", DbType.String, drug.A23));
                            command.Parameters.Add(Db.CreateParameter("@A24", DbType.String, drug.A24));
                            command.Parameters.Add(Db.CreateParameter("@A25", DbType.String, drug.A25));
                            command.Parameters.Add(Db.CreateParameter("@A26", DbType.String, drug.A26));
                            command.Parameters.Add(Db.CreateParameter("@A27", DbType.String, drug.A27));
                            command.Parameters.Add(Db.CreateParameter("@A28", DbType.String, drug.A28));
                            command.Parameters.Add(Db.CreateParameter("@A29", DbType.String, drug.A29));
                            command.Parameters.Add(Db.CreateParameter("@A30", DbType.String, drug.A30));
                            command.Parameters.Add(Db.CreateParameter("@A31", DbType.String, drug.A31));
                            command.Parameters.Add(Db.CreateParameter("@A32", DbType.String, drug.A32));
                            command.Parameters.Add(Db.CreateParameter("@A33", DbType.String, drug.A33));
                            command.Parameters.Add(Db.CreateParameter("@A34", DbType.String, drug.A34));
                            command.Parameters.Add(Db.CreateParameter("@A35", DbType.String, drug.A35));
                            command.Parameters.Add(Db.CreateParameter("@A36", DbType.String, drug.A36));
                            command.Parameters.Add(Db.CreateParameter("@A37", DbType.String, drug.A37));
                            command.Parameters.Add(Db.CreateParameter("@A38", DbType.String, drug.A38));
                            command.Parameters.Add(Db.CreateParameter("@A39", DbType.String, drug.A39));
                            command.Parameters.Add(Db.CreateParameter("@A40", DbType.String, drug.A40));
                            command.Parameters.Add(Db.CreateParameter("@A41", DbType.String, drug.A41));
                            command.Parameters.Add(Db.CreateParameter("@A42", DbType.String, drug.A42));
                            command.Parameters.Add(Db.CreateParameter("@A43", DbType.String, drug.A43));

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
            query.Append(string.Format("  DELETE FROM DRUG_DOSAGE_NORMAL{0} ", isTemTable ? "_TEMP" : ""));

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
            query.Append("  INSERT INTO DRUG_DOSAGE_NORMAL ");
            query.Append("  SELECT * FROM DRUG_DOSAGE_NORMAL_TEMP");

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