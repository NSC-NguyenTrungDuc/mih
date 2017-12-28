using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    class SqliteDrugDoNoStaAddDao : IDrugDoNoStaAdd
    {
        public DataTable GetDrugDoNoStaAdd()
        {
            DataTable dt = new DataTable("DugData");
            using (DbConnection connection = Db.CreateConnection())
            {
                using (DbCommand command = Db.CreateCommand())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("select B4.DRUG_ID, B4.BRANCH_NUMBER, B4.DOSAGE_BRANCH_NUMBER, B1.A4, B1.A5, B1.ADAPTATION, B1.ADAPTATION_RELATED, B1.A8, B1.AGE_CLASSIFICATION, B1.APPROPRIATE, B1.APPROPRIATE_CONDITION, B1.A12, B1.A13, B1.ONE_DOSE, B2.DAILY_DOSE, B2.DAILY_DOSE_CONTENT, B2.DOSE_FORM, B2.DAILY_DOSE_FORM, B2.DOSAGE_FORM_UNIT, B2.DAILY_NUMBER_DOSES, B2.A21, B2.A22, B2.A23, B2.A24, B2.A25, B2.A26, B2.A27, B2.A28, B2.A29, B2.A30, B2.A31, B2.A32, B2.A33, B2.A34, B2.A35, B2.A36, B2.A37, B2.A38, B2.A39, B2.A40, B2.A41, B2.A42, B2.A43, B3.A44, B3.A45, B3.A46, B3.A47, B3.A48, B3.A49, B3.A50, B3.A51, B3.A52, B3.A53, B3.A54, B3.A55, B3.A56, B3.A57, B3.A58, B3.A59, B3.A60, B3.A61, B3.A62, B3.A63, B3.A64, B3.A65, B3.A66, B3.A67, B3.A68, B3.A69, B3.A70, B3.A71, B3.A72, B4.A73, B4.A74, B4.A75, B4.A76, B4.A77, B4.A78, B4.A79, B4.A80, B4.A81, B4.A82, B4.A83, B4.A84, B4.A85, B4.A86, B4.A87, B4.A88, B4.A89, B4.A90, B4.A91, B4.A92, B4.A93, B4.A94, B4.A95, B4.A96, B4.A97, B4.A98, B4.A99, B4.A100, B4.A101"
                        );
                    //query.Append(" select * ");
                    //query.Append(" select B4.DRUG_ID, B4.BRANCH_NUMBER, B4.DOSAGE_BRANCH_NUMBER, B1.A4, ");
                    //query.Append(" B1.A5, B1.ADAPTATION, B1.ADAPTATION_RELATED, B1.A8, B1.AGE_CLASSIFICATION, ");
                    //query.Append(" B1.APPROPRIATE, B1.APPROPRIATE_CONDITION, B1.A12, B1.A13, B1.ONE_DOSE, B2.DAILY_DOSE, B2.DAILY_DOSE_CONTENT, ");
                    //query.Append(" B2.DOSE_FORM, B2.DAILY_DOSE_FORM, B2.DOSAGE_FORM_UNIT, B2.DAILY_NUMBER_DOSES, ");
                    //query.Append(" B2.A21, B2.A22, B2.A23, B2.A24, B2.A25, B2.A26, B2.A27, B2.A28, B2.A29, B2.A30, B2.A31, B2.A32, B2.A33, B2.A34, ");
                    //query.Append(" B2.A35, B2.A36, B2.A37, B2.A38, B2.A39, B2.A40, B2.A41, B2.A42, B2.A43, B3.A44, ");
                    //query.Append(" B3.A45, B3.A46, B3.A47, B3.A48, B3.A49, B3.A50, B3.A51, B3.A52, B3.A53, B3.A54, B3.A55, ");
                    //query.Append(" B3.A56, B3.A57, B3.A58, B3.A59, B3.A60, B3.A61, B3.A62, B3.A63, B3.A64, B3.A65, ");
                    //query.Append(" B3.A66, B3.A67, B3.A68, B3.A69, B3.A70, B3.A71, B3.A72, B4.A73, B4.A74, B4.A75, ");
                    //query.Append(" B4.A76, B4.A77, B4.A78, B4.A79, B4.A80, B4.A81, B4.A82, B4.A83, B4.A84, B4.A85, ");
                    //query.Append(" B4.A86, B4.A87, B4.A88, B4.A89, B4.A90, B4.A91, B4.A92, B4.A93, B4.A94, B4.A95, ");
                    //query.Append(" B4.A96, B4.A97, B4.A98, B4.A99, B4.A100, B4.A101 ");

                    query.Append(" from DRUG_DOSAGE B1,");
                    query.Append(" DRUG_DOSAGE_NORMAL B2,");
                    query.Append(" DRUG_DOSAGE_STANDARD B3,");
                    query.Append(" DRUG_DOSAGE_ADDITION B4");

                    query.Append(" Where B1.DRUG_ID = B2.DRUG_ID and");
                    query.Append(" B1.BRANCH_NUMBER = B2.BRANCH_NUMBER and");
                    query.Append(" B1.DOSAGE_BRANCH_NUMBER = B2.DOSAGE_BRANCH_NUMBER and");

                    query.Append(" B2.DRUG_ID = B3.DRUG_ID and");
                    query.Append(" B2.BRANCH_NUMBER = B3.BRANCH_NUMBER and");
                    query.Append(" B2.DOSAGE_BRANCH_NUMBER = B3.DOSAGE_BRANCH_NUMBER and");

                    query.Append(" B3.DRUG_ID = B4.DRUG_ID and");
                    query.Append(" B3.BRANCH_NUMBER = B4.BRANCH_NUMBER and");
                    query.Append(" B3.DOSAGE_BRANCH_NUMBER = B4.DOSAGE_BRANCH_NUMBER");

                    command.Connection = connection;
                    connection.Open();
                    //command.CommandType = CommandType.Text;
                    //command.CommandText = query.ToString();
                    //DbDataReader dr = command.ExecuteReader();
                    //DataSet ds =  Db.GetDataSet(query.ToString());
                    dt = Db.GetDataTable(query.ToString());
                    return dt;
                }
            }
            //return new DataTable();
        }

        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.CACHE; }
        }

        #endregion
    }
}
