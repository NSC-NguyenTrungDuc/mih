using System;
//using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Collections.Generic;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    public class SqliteDrugKinkiDiseaseDao : IDrugKinkiDiseaseDao
    {
        public bool TableExists(string tableName)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT COUNT(*) FROM SQLITE_MASTER ");
            query.Append("WHERE TYPE = 'table' AND NAME = " + Db.Escape(tableName) + ";");

            return ((long)Db.GetScalar(query.ToString()) > 0);
        }

        public int Insert(DrugKinkiDisease drug)
        {
            List<DrugKinkiDisease> lst = new List<DrugKinkiDisease>();
            lst.Add(drug);
            return Insert(lst, false);
        }

        public int Insert(List<DrugKinkiDisease> lst, bool isTemTable)
        {
            StringBuilder query = new StringBuilder();
            query.Append(string.Format("  Insert Into   DRUG_KINKI_DISEASE{0} ", isTemTable ? "_TEMP" : ""));
            query.Append("  (KINKI_ID, DISEASE_NAME, INDEX_TERM, STANDARD_DISEASE_NAME, ");
            query.Append("  DISEASE_CODE, ICD10, DECISION_FLG, COMMENT) ");
            query.Append(" 	values (@KINKI_ID, @DISEASE_NAME, @INDEX_TERM, @STANDARD_DISEASE_NAME,");
            query.Append("  @DISEASE_CODE, @ICD10, @DECISION_FLG, @COMMENT)");

            using (DbConnection connection = Db.CreateConnection())
            {

                using (DbCommand command = Db.CreateCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    try
                    {
                        foreach (DrugKinkiDisease drug in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Add(Db.CreateParameter("@KINKI_ID", DbType.String, drug.KinkiId));
                            command.Parameters.Add(Db.CreateParameter("@DISEASE_NAME", DbType.String, drug.DiseaseName));
                            command.Parameters.Add(Db.CreateParameter("@INDEX_TERM", DbType.String, drug.IndexTerm));
                            command.Parameters.Add(Db.CreateParameter("@STANDARD_DISEASE_NAME", DbType.String, drug.StandardDiseaseName));
                            command.Parameters.Add(Db.CreateParameter("@DISEASE_CODE", DbType.String, drug.DiseaseCode));
                            command.Parameters.Add(Db.CreateParameter("@ICD10", DbType.String, drug.Icd10));
                            command.Parameters.Add(Db.CreateParameter("@DECISION_FLG", DbType.String, drug.DicisionFlag));
                            command.Parameters.Add(Db.CreateParameter("@COMMENT", DbType.String, drug.Comment));
                            command.ExecuteNonQuery();
                            DateTime end = DateTime.Now;

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
            query.Append(string.Format("  DELETE FROM DRUG_KINKI_DISEASE{0} ", isTemTable ? "_TEMP" : ""));

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
            query.Append("  INSERT INTO DRUG_KINKI_DISEASE ");
            query.Append("  SELECT * FROM DRUG_KINKI_DISEASE_TEMP");

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