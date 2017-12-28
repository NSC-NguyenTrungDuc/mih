using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    public class PublicInsuranceInfo
    {
        private string publicInsuranceClass = "";
        private string publicInsuranceName = "";
        private string publicInsurerNumber = "";
        private string publicInsuredPersonNumber = "";
        private string certificateIssuedDate = "";

        public string PublicInsuranceClass
        {
            get { return publicInsuranceClass; }
            set { publicInsuranceClass = value; }
        }

        public string PublicInsuranceName
        {
            get { return publicInsuranceName; }
            set { publicInsuranceName = value; }
        }

        public string PublicInsurerNumber
        {
            get { return publicInsurerNumber; }
            set { publicInsurerNumber = value; }
        }

        public string PublicInsuredPersonNumber
        {
            get { return publicInsuredPersonNumber; }
            set { publicInsuredPersonNumber = value; }
        }

        public string CertificateIssuedDate
        {
            get { return certificateIssuedDate; }
            set { certificateIssuedDate = value; }
        }

        public PublicInsuranceInfo()
        { }
        public PublicInsuranceInfo(string publicInsuranceClass, string publicInsuranceName, string publicInsurerNumber, string publicInsuredPersonNumber, string certificateIssuedDate)
        {
            this.publicInsuranceClass = publicInsuranceClass;
            this.publicInsuranceName = publicInsuranceName;
            this.publicInsurerNumber = publicInsurerNumber;
            this.publicInsuredPersonNumber = publicInsuredPersonNumber;
            this.certificateIssuedDate = certificateIssuedDate;
        }
    }
}
