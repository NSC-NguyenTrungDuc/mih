namespace IHIS.CloudConnector.DataAccess
{
    /// <summary>
    /// Abstract factory class that creates data access objects.
    /// </summary>
    /// <remarks>
    /// GoF Design Pattern: Factory.
    /// </remarks>
    public abstract class DaoFactory
    {
        public abstract IDrugCheckingDao DrugCheckingDao { get; }

        public abstract IDrugDosageAddtionDao DrugDosageAddtionDao { get; }

        public abstract IDrugDosageDao DrugDosageDao { get; }

        public abstract IDrugDosageNormalDao DrugDosageNormalDao { get; }

        public abstract IDrugDosageStandardDao DrugDosageStandardDao { get; }

        public abstract IDrugGenericNameDao DrugGenericNameDao { get; }

        public abstract IDrugInteractionDao DrugInteractionDao { get; }

        public abstract IDrugKinkiDiseaseDao DrugKinkiDiseaseDao { get; }

        public abstract IDrugKinkiMessageDao DrugKinkiMessageDao { get; }

        public abstract IDiseaseTempDao DiseaseTempDao { get; }

        public abstract IOrderTempDao OrderTempDao { get; }

        public abstract IWarningDao WarningDao { get; }

        public abstract IClassificationDao ClassificationDao { get; }

        public abstract IDrugDoNoStaAdd DrugDoNoStaAddDao { get; }

        public abstract ISaOrderDao SaOrderDao { get; }

        public abstract ISaOrderDetailDao SaOrderDetailDao { get; }

        public abstract IMisaOrderDao MisaOrderDao { get;}

        public abstract IMisaSyncDao MisaSyncDao { get;}
    }

    /// <summary>
    /// Abstract factory class that creates data access objects.
    /// </summary>
    /// <remarks>
    /// GoF Design Pattern: Factory.
    /// </remarks>
    public abstract class CopyOfDaoFactory
    {
    }
}
