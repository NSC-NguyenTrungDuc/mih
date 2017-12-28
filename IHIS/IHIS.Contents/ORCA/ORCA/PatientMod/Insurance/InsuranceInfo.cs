using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class InsuranceInfo
    {
        private string insuranceProviderClass = "";
        private string insuranceProviderNumber = "";
        private string insuranceProviderWholeName = "";
        private string healthInsuredPersonSymbol = "";
        private string healthInsuredPersonNumber = "";
        private string relationToInsuredPerson = "";
        private string certificateStartDate = "";
        private List<PublicInsuranceInfo> publicInsuranceInfo;

        public string InsuranceProviderClass
        {
            get { return insuranceProviderClass; }
            set { insuranceProviderClass = value; }
        }

        public string InsuranceProviderNumber
        {
            get { return insuranceProviderNumber; }
            set { insuranceProviderNumber = value; }
        }

        public string InsuranceProviderWholeName
        {
            get { return insuranceProviderWholeName; }
            set { insuranceProviderWholeName = value; }
        }

        public string HealthInsuredPersonSymbol
        {
            get { return healthInsuredPersonSymbol; }
            set { healthInsuredPersonSymbol = value; }
        }

        public string HealthInsuredPersonNumber
        {
            get { return healthInsuredPersonNumber; }
            set { healthInsuredPersonNumber = value; }
        }

        public string RelationToInsuredPerson
        {
            get { return relationToInsuredPerson; }
            set { relationToInsuredPerson = value; }
        }

        public string CertificateStartDate
        {
            get { return certificateStartDate; }
            set { certificateStartDate = value; }
        }

        public List<PublicInsuranceInfo> PublicInsuranceInfo
        {
            get { return publicInsuranceInfo; }
            set { publicInsuranceInfo = value; }
        }
        public InsuranceInfo(string insuranceProviderClass, string insuranceProviderNumber, string insuranceProviderWholeName, string healthInsuredPersonSymbol,
            string healthInsuredPersonNumber, string relationToInsuredPerson, string certificateStartDate, List<PublicInsuranceInfo> publicInsuranceInfo)
        {
            this.insuranceProviderClass = insuranceProviderClass;
            this.insuranceProviderNumber = insuranceProviderNumber;
            this.insuranceProviderWholeName = insuranceProviderWholeName;
            this.healthInsuredPersonSymbol = healthInsuredPersonSymbol;
            this.healthInsuredPersonNumber = healthInsuredPersonNumber;
            this.relationToInsuredPerson = relationToInsuredPerson;
            this.certificateStartDate = certificateStartDate;
            this.publicInsuranceInfo = publicInsuranceInfo;


        }
    }
}
