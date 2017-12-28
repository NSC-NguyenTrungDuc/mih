namespace IHIS.CloudConnector.DataAccess.AdoNet.Sqlite
{
    /// <summary>
    /// Sqlite specific factory that creates Sql Server specific data access objects.
    /// </summary>
    /// <remarks>
    /// GoF Design Pattern: Factory.
    /// </remarks>
    public class SqliteDaoFactory : DaoFactory
    {

        public override IDrugCheckingDao DrugCheckingDao
        {
            get { return new SqliteDrugCheckingDao(); }
        }

        public override IDrugDosageAddtionDao DrugDosageAddtionDao
        {
            get { return new SqliteDrugDosageAddtionDao();}
        }

        public override IDrugDosageDao DrugDosageDao
        {
            get { return new SqliteDrugDosageDao();}
        }

        public override IDrugDosageNormalDao DrugDosageNormalDao
        {
            get { return new SqliteDrugDosageNormalDao();}
        }

        public override IDrugDosageStandardDao DrugDosageStandardDao
        {
            get { return new SqliteDrugDosageStandardDao(); }
        }

        public override IDrugGenericNameDao DrugGenericNameDao
        {
            get { return  new SqliteDrugGenericNameDao();}
        }

        public override IDrugInteractionDao DrugInteractionDao
        {
            get { return new SqliteDrugInteractionDao(); }
        }

        public override IDrugKinkiDiseaseDao DrugKinkiDiseaseDao
        {
            get { return new SqliteDrugKinkiDiseaseDao(); }
        }

        public override IDrugKinkiMessageDao DrugKinkiMessageDao
        {
            get { return new SqliteDrugKinkiMessageDao();}
        }

        public override IDiseaseTempDao DiseaseTempDao
        {
            get { return new SqliteDiseaseTempDao(); }
        }

        public override IOrderTempDao OrderTempDao
        {
            get { return new SqliteOrderTempDao(); }
        }

        public override IWarningDao WarningDao
        {
            get { return new SqliteWarningDao(); }
        }

        public override IClassificationDao ClassificationDao
        {
            get { return new SqliteClassificationDao(); }
        }

        public override IDrugDoNoStaAdd DrugDoNoStaAddDao
        {
            get { return new SqliteDrugDoNoStaAddDao(); }
        }

        public override ISaOrderDao SaOrderDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override ISaOrderDetailDao SaOrderDetailDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IMisaOrderDao MisaOrderDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IMisaSyncDao MisaSyncDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }
    }
}