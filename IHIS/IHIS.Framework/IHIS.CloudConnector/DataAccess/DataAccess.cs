using System.Configuration;

namespace IHIS.CloudConnector.DataAccess
{
    /// <summary>
    /// This class shields the client from the details of database specific 
    /// data-access objects. It returns the appropriate data-access objects 
    /// according to the configuration in web.config.
    /// </summary>
    /// <remarks>
    /// GoF Design Patterns: Factory, Singleton, Proxy.
    /// 
    /// This class makes extensive use of the Factory pattern in determining which 
    /// database specific DAOs (Data Access Objects) to return.
    /// 
    /// This class is like a Singleton -- it is a static class (Shared in VB) and 
    /// therefore only one 'instance' will ever exist.
    /// 
    /// This class is a Proxy as it 'stands in' for the actual Data Access Object Factory.
    /// </remarks>
    public static class DataAccess
    {
        // The static field initializers below are thread safe.
        // Furthermore, they are executed in the order in which they appear
        // in the class declaration. Note: if a static constructor
        // is present you want to initialize these in that constructor.
        private static readonly string connectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
        private static readonly DaoFactory factory = DaoFactories.GetFactory(connectionStringName);

        private static readonly string connectionStringNameMisa = ConfigurationManager.AppSettings.Get("ConnectionStringNameMisa");
        private static readonly DaoFactory factoryMisa = DaoFactories.GetFactory(connectionStringNameMisa, DataSource.MISA);

        public static class Cache
        {
            public static IDiseaseTempDao DiseaseTempDao
            {
                get { return factory.DiseaseTempDao; }
            }

            public static IDrugCheckingDao DrugCheckingDao
            {
                get { return factory.DrugCheckingDao; }
            }

            public static IDrugDosageAddtionDao DrugDosageAddtionDao
            {
                get { return factory.DrugDosageAddtionDao; }
            }

            public static IDrugDosageDao DrugDosageDao
            {
                get { return factory.DrugDosageDao; }
            }

            public static IDrugDosageNormalDao DrugDosageNormalDao
            {
                get { return factory.DrugDosageNormalDao; }
            }

            public static IDrugDosageStandardDao DrugDosageStandardDao
            {
                get { return factory.DrugDosageStandardDao; }
            }

            public static IDrugGenericNameDao DrugGenericNameDao
            {
                get { return factory.DrugGenericNameDao; }
            }

            public static IDrugInteractionDao DrugInteractionDao
            {
                get { return factory.DrugInteractionDao; }
            }

            public static IDrugKinkiDiseaseDao DrugKinkiDiseaseDao
            {
                get { return factory.DrugKinkiDiseaseDao; }
            }

            public static IDrugKinkiMessageDao DrugKinkiMessageDao
            {
                get { return factory.DrugKinkiMessageDao; }
            }

            public static IOrderTempDao OrderTempDao
            {
                get { return factory.OrderTempDao; }
            }

            public static IWarningDao WarningDao
            {
                get { return factory.WarningDao; }
            }

            public static IClassificationDao ClassificationDao
            {
                get { return factory.ClassificationDao; }
            }

            public static IDrugDoNoStaAdd DrugDoNoStaAdd
            {
                get { return factory.DrugDoNoStaAddDao; }
            }
        }

        public static class Misa
        {
            public static ISaOrderDao SaOrderDao
            {
                get { return factoryMisa.SaOrderDao; }
            }

            public static ISaOrderDetailDao SaOrderDetailDao
            {
                get { return factoryMisa.SaOrderDetailDao; }
            }

            public static IMisaOrderDao MisaOrderDao
            {
                get { return factoryMisa.MisaOrderDao; }
            }

            public static IMisaSyncDao MisaSyncDao
            {
                get { return factoryMisa.MisaSyncDao; }
            }
        }
    }
}
