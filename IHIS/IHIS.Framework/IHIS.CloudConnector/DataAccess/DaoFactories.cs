using IHIS.CloudConnector.DataAccess.AdoNet.Sqlite;
using IHIS.CloudConnector.DataAccess.AdoNet.SqlServer;
using System.Reflection;
using System;
using IHIS.Framework;

namespace IHIS.CloudConnector.DataAccess
{
    /// <summary>
    /// Factory of factories. This class is a factory class that creates
    /// data-base specific factories which in turn create data acces objects.
    /// </summary>
    /// <remarks>
    /// GoF Design Patterns: Factory.
    /// 
    /// This is the abstract factory design pattern applied in a hierarchy
    /// in which there is a factory of factories.
    /// </remarks>
    public class DaoFactories
    {
        /// <summary>
        /// Gets a provider specific (i.e. database specific) factory 
        /// 
        /// GoF Design Pattern: Factory
        /// </summary>
        /// <param name="dataProvider">Database provider.</param>
        /// <returns>Data access object factory.</returns>
        public static DaoFactory GetFactory(string dataProvider, DataSource datasource)
        {
            // Return the requested DaoFactory
            switch (dataProvider)
            {
                case "ADO.NET.SqlExpress": return new SqlServerDaoFactory();
                case "ADO.NET.SqlServer":
                    switch (datasource)
                    {
                        case DataSource.MISA:
                            try
                            {
                                Assembly asm = Assembly.LoadFile(Environment.CurrentDirectory + "\\NURO\\NURO.MisaLib.dll");
                                Type type = asm.GetType("NURO.MisaLib.SqlServerDaoFactory", false, true);
                                return (DaoFactory)Activator.CreateInstance(type);
                            }
                            catch (Exception ex)
                            {
                                Logs.WriteLog("GetFactory" + ex.InnerException.ToString());
                                return null;
                            }
                            
                        default:
                            return new SqlServerDaoFactory();
                    }
                case "ADO.NET.Sqlite": return new SqliteDaoFactory();
                
                // Just in case: the Design Pattern Framework always has MS Access available.
                default: return new SqliteDaoFactory();
            }
        }

        public static DaoFactory GetFactory(string dataProvider)
        {
            return GetFactory(dataProvider, DataSource.CACHE);
        }
    }
}

