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
    public class SqlServerMisaOrderDao : IMisaOrderDao
    {
        #region IMisaOrderDao Members

        public Guid GetAccountId(string code)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  Select AccountObjectID From AccountObject ");
            query.Append("  Where AccountObjectCode = @AccountObjectCode");

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
                        command.Parameters.Add(Db.CreateParameter("@AccountObjectCode", DbType.String, code, this));

                        using (DbDataAdapter adapter = Db.CreateDataAdapter(this))
                        {
                            adapter.SelectCommand = command;

                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                                return new Guid(dt.Rows[0][0].ToString());
                            return Guid.Empty;
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

        public Guid GetBrandId()
        {
            StringBuilder query = new StringBuilder();
            query.Append("  Select top 1 BranchID from OrganizationUnit ");

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
                        using (DbDataAdapter adapter = Db.CreateDataAdapter(this))
                        {
                            adapter.SelectCommand = command;

                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                                return new Guid(dt.Rows[0][0].ToString());
                            return Guid.Empty;
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

        public MisaOrder GetMisaOrder(string code)
        {
            StringBuilder query = new StringBuilder();
            query.Append("  SELECT InventoryItemID,SalePrice1,UnitID,InventoryItemName FROM InventoryItem ");
            query.Append("  WHERE InventoryItemCode = @InventoryItemCode ");

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
                        command.Parameters.Add(Db.CreateParameter("@InventoryItemCode", DbType.String, code, this));
                        using (DbDataAdapter adapter = Db.CreateDataAdapter(this))
                        {
                            adapter.SelectCommand = command;

                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                MisaOrder misaOrder = new MisaOrder();
                                misaOrder.InventoryItemId = new Guid(dt.Rows[0][0].ToString());
                                misaOrder.SalePrice1 = Decimal.Parse(dt.Rows[0][1].ToString());
                                misaOrder.UnitId = new Guid(dt.Rows[0][2].ToString());
                                misaOrder.InventoryItemName = dt.Rows[0][3].ToString();
                                return misaOrder;
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
