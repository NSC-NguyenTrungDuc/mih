using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess.Entities;
using IHIS.CloudConnector.DataAccess;
using IHIS.CloudConnector.DataAccess.AdoNet;
using System.Data;
using IHIS.Framework;
using System.Data.Common;

namespace NURO.MisaLib
{
    public class SqlServerSaOrderDetailDao : ISaOrderDetailDao
    {
        #region IDao Members

        public DataSource Source
        {
            get { return DataSource.MISA; }
        }

        #endregion

        #region ISaOrderDetailDao Members

        public int Insert(List<SaOrderDetail> lst, Guid refId)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  INSERT INTO SAOrderDetail");
            query.Append("  (RefID, InventoryItemID, Description, Quantity,");
            query.Append("  MainQuantity, MainConvertRate, UnitID, UnitPrice, AmountOC, Amount)");

            query.Append(" 	VALUES (@RefID, @InventoryItemID, @Description, @Quantity,");
            query.Append("  @MainQuantity, @MainConvertRate, @UnitID, @UnitPrice, @AmountOC, @Amount)");

            using (DbConnection connection = Db.CreateConnection(this))
            {

                using (DbCommand command = Db.CreateCommand(this))
                {
                    command.Connection = connection;
                    connection.Open();
                    DbTransaction trans = connection.BeginTransaction();
                    command.Transaction = trans;
                    try
                    {
                        foreach (SaOrderDetail saOrder in lst)
                        {
                            command.CommandText = query.ToString();
                            command.CommandType = CommandType.Text;
                            command.Parameters.Clear();
                            command.Parameters.Add(Db.CreateParameter("@RefID", DbType.Guid, refId, this));
                            command.Parameters.Add(Db.CreateParameter("@InventoryItemID", DbType.Guid, saOrder.Inventoryitemid, this));
                            command.Parameters.Add(Db.CreateParameter("@Description", DbType.String, saOrder.Description, this));
                            command.Parameters.Add(Db.CreateParameter("@Quantity", DbType.Decimal, saOrder.Quantity, this));
                            command.Parameters.Add(Db.CreateParameter("@MainQuantity", DbType.Decimal, saOrder.Mainquantity, this));
                            command.Parameters.Add(Db.CreateParameter("@MainConvertRate", DbType.Decimal, saOrder.Mainconvertrate, this));
                            if (saOrder.Unitid == null || saOrder.Unitid == Guid.Empty)
                            {
                                command.Parameters.Add(Db.CreateParameter("@UnitID", DbType.Guid, DBNull.Value, this));
                            }
                            else
                            {
                                command.Parameters.Add(Db.CreateParameter("@UnitID", DbType.Guid, saOrder.Unitid, this));
                            }
                            if (saOrder.Unitprice == null)
                            {
                                command.Parameters.Add(Db.CreateParameter("@UnitPrice", DbType.Decimal, DBNull.Value, this));
                            }
                            else
                            {
                                command.Parameters.Add(Db.CreateParameter("@UnitPrice", DbType.Decimal, saOrder.Unitprice, this));
                            }

                            command.Parameters.Add(Db.CreateParameter("@AmountOC", DbType.Decimal, saOrder.Amountoc, this));
                            command.Parameters.Add(Db.CreateParameter("@Amount", DbType.Decimal, saOrder.Amount, this));

                            command.ExecuteNonQuery();
                        }
                        trans.Commit();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Service.WriteLog(ex.ToString());
                        return -1;
                    }
                }
            }
        }

        #endregion

        #region ISaOrderDetailDao Members

        public int Insert(DbTransaction trans, List<SaOrderDetail> lst, Guid refId)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  INSERT INTO SAOrderDetail");
            query.Append("  (RefID, InventoryItemID, Description, Quantity,");
            query.Append("  MainQuantity, MainConvertRate, UnitID, UnitPrice, AmountOC, Amount)");

            query.Append(" 	VALUES (@RefID, @InventoryItemID, @Description, @Quantity,");
            query.Append("  @MainQuantity, @MainConvertRate, @UnitID, @UnitPrice, @AmountOC, @Amount)");

            using (DbCommand command = Db.CreateCommand(this))
            {
                command.Connection = trans.Connection;
                command.Transaction = trans;
                try
                {
                    foreach (SaOrderDetail saOrder in lst)
                    {
                        command.CommandText = query.ToString();
                        command.CommandType = CommandType.Text;
                        command.Parameters.Clear();
                        command.Parameters.Add(Db.CreateParameter("@RefID", DbType.Guid, refId, this));
                        command.Parameters.Add(Db.CreateParameter("@InventoryItemID", DbType.Guid, saOrder.Inventoryitemid, this));
                        command.Parameters.Add(Db.CreateParameter("@Description", DbType.String, saOrder.Description, this));
                        command.Parameters.Add(Db.CreateParameter("@Quantity", DbType.Decimal, saOrder.Quantity, this));
                        command.Parameters.Add(Db.CreateParameter("@MainQuantity", DbType.Decimal, saOrder.Mainquantity, this));
                        command.Parameters.Add(Db.CreateParameter("@MainConvertRate", DbType.Decimal, saOrder.Mainconvertrate, this));
                        if (saOrder.Unitid == null || saOrder.Unitid == Guid.Empty)
                        {
                            command.Parameters.Add(Db.CreateParameter("@UnitID", DbType.Guid, DBNull.Value, this));
                        }
                        else
                        {
                            command.Parameters.Add(Db.CreateParameter("@UnitID", DbType.Guid, saOrder.Unitid, this));
                        }
                        if (saOrder.Unitprice == null)
                        {
                            command.Parameters.Add(Db.CreateParameter("@UnitPrice", DbType.Decimal, DBNull.Value, this));
                        }
                        else
                        {
                            command.Parameters.Add(Db.CreateParameter("@UnitPrice", DbType.Decimal, saOrder.Unitprice, this));
                        }

                        command.Parameters.Add(Db.CreateParameter("@AmountOC", DbType.Decimal, saOrder.Amountoc, this));
                        command.Parameters.Add(Db.CreateParameter("@Amount", DbType.Decimal, saOrder.Amount, this));

                        command.ExecuteNonQuery();
                    }
                    return 0;
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
