using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess;
using IHIS.CloudConnector.DataAccess.Entities;
using System.Data.Common;
using IHIS.CloudConnector.DataAccess.AdoNet;
using System.Data;
using IHIS.Framework;

namespace NURO.MisaLib
{
    public class SqlServerMisaSyncDao : IMisaSyncDao
    {
        #region IMisaSyncDao Members

        public List<BookingMisa> GetBookingMisa(DateTime currentDate)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  SELECT B1.AccountObjectCode,B2.AccountObjectCode,A.ModifiedBy,A.RefDate,A.CreatedDate, D.InventoryItemCode, B1.BranchID ");
            query.Append("  FROM SAOrder A, AccountObject B1, AccountObject B2, SAOrderDetail C, InventoryItem D                                    ");
            query.Append("  WHERE CONVERT(DATE, A.ModifiedDate) = @currentDate                                                                      ");
            query.Append("  AND A.AccountObjectID = B1.AccountObjectID                                                                              ");
            query.Append("  AND A.EmployeeID = B2.AccountObjectID                                                                                   ");
            query.Append("  AND A.RefID = C.RefID                                                                                                   ");
            query.Append("  AND C.InventoryItemID = D.InventoryItemID                                                                               ");

            using (DbConnection connection = Db.CreateConnection(this))
            {

                using (DbCommand command = Db.CreateCommand(this))
                {
                    command.Connection = connection;
                    connection.Open();
                    try
                    {
                        command.CommandText = query.ToString();
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(Db.CreateParameter("@currentDate", DbType.Date, currentDate, this));
                        using (DbDataAdapter adapter = Db.CreateDataAdapter(this))
                        {
                            adapter.SelectCommand = command;

                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                List<BookingMisa> lst = new List<BookingMisa>();
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {

                                    BookingMisa bookingMisa = new BookingMisa();
                                    bookingMisa.AccountObjectCode = dt.Rows[i][0].ToString();
                                    bookingMisa.EmployeeCode = dt.Rows[i][1].ToString();
                                    bookingMisa.ModififiedBy = dt.Rows[i][2].ToString();
                                    bookingMisa.RefDate = Convert.ToDateTime(dt.Rows[i][3].ToString());
                                    bookingMisa.CreateDate = Convert.ToDateTime(dt.Rows[i][4].ToString());
                                    bookingMisa.InventoryCode = dt.Rows[i][5].ToString();
                                    bookingMisa.BrandID = dt.Rows[i][6].ToString();

                                    lst.Add(bookingMisa);
                                }
                                return lst;
                            }
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Service.WriteLog(ex.ToString());
                        throw ex;
                    }
                }
            }
        }

        public List<PatientMisa> GetPatientMisa(DateTime currentDate)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  SELECT AccountObjectCode,AccountObjectName,Address,Tel,Mobile,Fax,EmailAddress ");
            query.Append("  FROM AccountObject ");
            query.Append("  WHERE CONVERT(DATE, ModifiedDate) = @currentDate ");

            using (DbConnection connection = Db.CreateConnection(this))
            {

                using (DbCommand command = Db.CreateCommand(this))
                {
                    command.Connection = connection;
                    connection.Open();
                    try
                    {
                        command.CommandText = query.ToString();
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(Db.CreateParameter("@currentDate", DbType.Date, currentDate, this));
                        using (DbDataAdapter adapter = Db.CreateDataAdapter(this))
                        {
                            adapter.SelectCommand = command;

                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                List<PatientMisa> lst = new List<PatientMisa>();
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {

                                    PatientMisa patientMisa = new PatientMisa();
                                    patientMisa.AccountObjectCode = dt.Rows[i][0].ToString();
                                    patientMisa.AccountObjectName = dt.Rows[i][1].ToString();
                                    patientMisa.Address = dt.Rows[i][2].ToString();
                                    patientMisa.Tel = dt.Rows[i][3].ToString();
                                    patientMisa.Mobile = dt.Rows[i][4].ToString();
                                    patientMisa.Fax = dt.Rows[i][5].ToString();
                                    patientMisa.EmailAddress = dt.Rows[i][6].ToString();

                                    lst.Add(patientMisa);
                                }
                                return lst;
                            }
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Service.WriteLog(ex.ToString());
                        throw ex;
                    }
                }
            }
        }

        #endregion

        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.MISA; }
        }

        #endregion
    }
}
