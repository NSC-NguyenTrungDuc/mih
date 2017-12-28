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
    public class SqlServerSaOrderDao : ISaOrderDao
    {
        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.MISA; }
        }

        #endregion

        #region ISaOrderDao Members

        public Guid Insert(SaOrder saOrder)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  INSERT INTO SAOrder ");
            query.Append("  (RefDate, RefNo, Status, RefType, BranchID, AccountObjectID, AccountObjectName,");
            query.Append("  AccountObjectAddress,EmployeeID, IsCalculatedCost, PaymentTermID, CurrencyID, ExchangeRate,");
            query.Append("  TotalAmountOC, TotalAmount, TotalDiscountAmountOC, TotalDiscountAmount, TotalVATAmountOC,");
            query.Append("  TotalVATAmount, CreatedDate)");
            query.Append("  OUTPUT inserted.RefID");
            query.Append(" 	VALUES ( GETDATE(), @RefNo, @Status, @RefType, @BranchID, @AccountObjectID, @AccountObjectName,");
            query.Append("  @AccountObjectAddress, @EmployeeID, @IsCalculatedCost, @PaymentTermID, @CurrencyID, @ExchangeRate,");
            query.Append("  @TotalAmountOC, @TotalAmount, @TotalDiscountAmountOC, @TotalDiscountAmount, @TotalVATAmountOC,");
            query.Append("  @TotalVATAmount, GETDATE())");

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
                        command.Parameters.Add(Db.CreateParameter("@RefNo", DbType.String, saOrder.Refno, this));
                        command.Parameters.Add(Db.CreateParameter("@Status", DbType.Int32, saOrder.Status, this));
                        command.Parameters.Add(Db.CreateParameter("@RefType", DbType.Int32, saOrder.Reftype, this));
                        command.Parameters.Add(Db.CreateParameter("@BranchID", DbType.Guid, saOrder.Branchid, this));
                        command.Parameters.Add(Db.CreateParameter("@AccountObjectID", DbType.Guid, saOrder.Accountobjectid, this));
                        command.Parameters.Add(Db.CreateParameter("@AccountObjectName", DbType.String, saOrder.Accountobjectname, this));

                        command.Parameters.Add(Db.CreateParameter("@AccountObjectAddress", DbType.String, saOrder.Accountobjectaddress, this));
                        command.Parameters.Add(Db.CreateParameter("@EmployeeID", DbType.Guid, saOrder.Employeeid, this));
                        command.Parameters.Add(Db.CreateParameter("@IsCalculatedCost", DbType.Boolean, saOrder.Iscalculatedcost, this));
                        if (saOrder.Paymenttermid == null)
                        {
                            command.Parameters.Add(Db.CreateParameter("@PaymentTermID", DbType.Guid, DBNull.Value, this));
                        }
                        else
                        {
                            command.Parameters.Add(Db.CreateParameter("@PaymentTermID", DbType.Guid, saOrder.Paymenttermid, this));
                        }
                        command.Parameters.Add(Db.CreateParameter("@CurrencyID", DbType.String, saOrder.Currencyid, this));
                        command.Parameters.Add(Db.CreateParameter("@ExchangeRate", DbType.Decimal, saOrder.Exchangerate, this));

                        command.Parameters.Add(Db.CreateParameter("@TotalAmountOC", DbType.Decimal, saOrder.Totalamountoc, this));
                        command.Parameters.Add(Db.CreateParameter("@TotalAmount", DbType.Decimal, saOrder.Totalamount, this));
                        command.Parameters.Add(Db.CreateParameter("@TotalDiscountAmountOC", DbType.Decimal, saOrder.Totaldiscountamountoc, this));
                        command.Parameters.Add(Db.CreateParameter("@TotalDiscountAmount", DbType.Decimal, saOrder.Totaldiscountamount, this));
                        command.Parameters.Add(Db.CreateParameter("@TotalVATAmountOC", DbType.Decimal, saOrder.Totalvatamountoc, this));

                        command.Parameters.Add(Db.CreateParameter("@TotalVATAmount", DbType.Decimal, saOrder.Totalvatamount, this));

                        return (Guid)command.ExecuteScalar();

                    }
                    catch (Exception ex)
                    {
                        Service.WriteLog(ex.ToString());
                        throw ex;
                    }
                }
            }
        }


        int ISaOrderDao.Update(SaOrder saOrder)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  Update SAOrder  ");
            query.Append("  Set TotalAmountOC = @TotalAmountOC, TotalAmount = @TotalAmount  ");
            query.Append("  Where RefID = @RefID   ");

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

                        command.Parameters.Add(Db.CreateParameter("@TotalAmountOC", DbType.Decimal, saOrder.Totalamountoc, this));
                        command.Parameters.Add(Db.CreateParameter("@TotalAmount", DbType.Decimal, saOrder.Totalamount, this));
                        command.Parameters.Add(Db.CreateParameter("@RefID", DbType.Guid, saOrder.Refid, this));
                        return command.ExecuteNonQuery();

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

        #region ISaOrderDao Members

        public Guid Insert(DbTransaction trans, SaOrder saOrder)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  INSERT INTO SAOrder ");
            query.Append("  (RefDate, RefNo, Status, RefType, BranchID, AccountObjectID, AccountObjectName,");
            query.Append("  AccountObjectAddress,EmployeeID, IsCalculatedCost, PaymentTermID, CurrencyID, ExchangeRate,");
            query.Append("  TotalAmountOC, TotalAmount, TotalDiscountAmountOC, TotalDiscountAmount, TotalVATAmountOC,");
            query.Append("  TotalVATAmount, CreatedDate)");
            query.Append("  OUTPUT inserted.RefID");
            query.Append(" 	VALUES ( GETDATE(), @RefNo, @Status, @RefType, @BranchID, @AccountObjectID, @AccountObjectName,");
            query.Append("  @AccountObjectAddress, @EmployeeID, @IsCalculatedCost, @PaymentTermID, @CurrencyID, @ExchangeRate,");
            query.Append("  @TotalAmountOC, @TotalAmount, @TotalDiscountAmountOC, @TotalDiscountAmount, @TotalVATAmountOC,");
            query.Append("  @TotalVATAmount, GETDATE())");
            using (DbCommand command = Db.CreateCommand(this))
            {
                command.Connection = trans.Connection;
                command.Transaction = trans;
                try
                {
                    command.CommandText = query.ToString();
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(Db.CreateParameter("@RefNo", DbType.String, saOrder.Refno, this));
                    command.Parameters.Add(Db.CreateParameter("@Status", DbType.Int32, saOrder.Status, this));
                    command.Parameters.Add(Db.CreateParameter("@RefType", DbType.Int32, saOrder.Reftype, this));
                    command.Parameters.Add(Db.CreateParameter("@BranchID", DbType.Guid, saOrder.Branchid, this));
                    command.Parameters.Add(Db.CreateParameter("@AccountObjectID", DbType.Guid, saOrder.Accountobjectid, this));
                    command.Parameters.Add(Db.CreateParameter("@AccountObjectName", DbType.String, saOrder.Accountobjectname, this));

                    command.Parameters.Add(Db.CreateParameter("@AccountObjectAddress", DbType.String, saOrder.Accountobjectaddress, this));
                    command.Parameters.Add(Db.CreateParameter("@EmployeeID", DbType.Guid, saOrder.Employeeid, this));
                    command.Parameters.Add(Db.CreateParameter("@IsCalculatedCost", DbType.Boolean, saOrder.Iscalculatedcost, this));
                    if (saOrder.Paymenttermid == null)
                    {
                        command.Parameters.Add(Db.CreateParameter("@PaymentTermID", DbType.Guid, DBNull.Value, this));
                    }
                    else
                    {
                        command.Parameters.Add(Db.CreateParameter("@PaymentTermID", DbType.Guid, saOrder.Paymenttermid, this));
                    }
                    command.Parameters.Add(Db.CreateParameter("@CurrencyID", DbType.String, saOrder.Currencyid, this));
                    command.Parameters.Add(Db.CreateParameter("@ExchangeRate", DbType.Decimal, saOrder.Exchangerate, this));

                    command.Parameters.Add(Db.CreateParameter("@TotalAmountOC", DbType.Decimal, saOrder.Totalamountoc, this));
                    command.Parameters.Add(Db.CreateParameter("@TotalAmount", DbType.Decimal, saOrder.Totalamount, this));
                    command.Parameters.Add(Db.CreateParameter("@TotalDiscountAmountOC", DbType.Decimal, saOrder.Totaldiscountamountoc, this));
                    command.Parameters.Add(Db.CreateParameter("@TotalDiscountAmount", DbType.Decimal, saOrder.Totaldiscountamount, this));
                    command.Parameters.Add(Db.CreateParameter("@TotalVATAmountOC", DbType.Decimal, saOrder.Totalvatamountoc, this));

                    command.Parameters.Add(Db.CreateParameter("@TotalVATAmount", DbType.Decimal, saOrder.Totalvatamount, this));

                    return (Guid)command.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    Service.WriteLog(ex.ToString());
                    throw ex;
                }
            }
        }

        public int Update(DbTransaction trans, SaOrder saOrder)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  Update SAOrder  ");
            query.Append("  Set TotalAmountOC = @TotalAmountOC, TotalAmount = @TotalAmount  ");
            query.Append("  Where RefID = @RefID   ");

            using (DbCommand command = Db.CreateCommand(this))
            {
                command.Connection = trans.Connection;
                command.Transaction = trans;
                try
                {
                    command.CommandText = query.ToString();
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(Db.CreateParameter("@TotalAmountOC", DbType.Decimal, saOrder.Totalamountoc, this));
                    command.Parameters.Add(Db.CreateParameter("@TotalAmount", DbType.Decimal, saOrder.Totalamount, this));
                    command.Parameters.Add(Db.CreateParameter("@RefID", DbType.Guid, saOrder.Refid, this));
                    return command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Service.WriteLog(ex.ToString());
                    throw ex;
                }
            }
        }

        #endregion
    }
}
