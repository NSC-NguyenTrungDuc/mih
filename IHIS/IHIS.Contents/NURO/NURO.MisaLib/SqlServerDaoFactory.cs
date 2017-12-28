using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.DataAccess;

namespace NURO.MisaLib
{
    public class SqlServerDaoFactory : DaoFactory
    {
        public override IClassificationDao ClassificationDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDiseaseTempDao DiseaseTempDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugCheckingDao DrugCheckingDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugDoNoStaAdd DrugDoNoStaAddDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugDosageAddtionDao DrugDosageAddtionDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugDosageDao DrugDosageDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugDosageNormalDao DrugDosageNormalDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugDosageStandardDao DrugDosageStandardDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugGenericNameDao DrugGenericNameDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugInteractionDao DrugInteractionDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugKinkiDiseaseDao DrugKinkiDiseaseDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IDrugKinkiMessageDao DrugKinkiMessageDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IMisaOrderDao MisaOrderDao
        {
            get { return new SqlServerMisaOrderDao(); }
        }

        public override IOrderTempDao OrderTempDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override ISaOrderDao SaOrderDao
        {
            get { return new SqlServerSaOrderDao(); }
        }

        public override ISaOrderDetailDao SaOrderDetailDao
        {
            get { return new SqlServerSaOrderDetailDao(); }
        }

        public override IWarningDao WarningDao
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override IMisaSyncDao MisaSyncDao
        {
            get { return new SqlServerMisaSyncDao(); }
        }
    }
}
