namespace IHIS.CloudConnector.DataAccess.AdoNet.SqlServer
{
    /// <summary>
    /// Sql Server specific factory that creates Sql Server specific data access objects.
    /// </summary>
    /// <remarks>
    /// GoF Design Pattern: Factory.
    /// </remarks>
    public class SqlServerDaoFactory : DaoFactory
    {
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

        public override IDrugCheckingDao DrugCheckingDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDrugDosageAddtionDao DrugDosageAddtionDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDrugDosageDao DrugDosageDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDrugDosageNormalDao DrugDosageNormalDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDrugDosageStandardDao DrugDosageStandardDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDrugGenericNameDao DrugGenericNameDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDrugInteractionDao DrugInteractionDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDrugKinkiDiseaseDao DrugKinkiDiseaseDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDrugKinkiMessageDao DrugKinkiMessageDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDiseaseTempDao DiseaseTempDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IOrderTempDao OrderTempDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IWarningDao WarningDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IClassificationDao ClassificationDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }

        public override IDrugDoNoStaAdd DrugDoNoStaAddDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }


        public override IMisaSyncDao MisaSyncDao
        {
            get { throw new System.Exception("The method or operation is not implemented."); }
        }
    }
}
