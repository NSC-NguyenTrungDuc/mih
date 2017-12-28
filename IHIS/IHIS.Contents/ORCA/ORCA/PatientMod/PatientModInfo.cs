using System;
using System.Collections.Generic;
using System.Text;

namespace ORCA
{
    /// <summary>
    /// Input patient info from KCCK
    /// </summary>
    public class PatientModInfo
    {
        private string modKey = "";
        private string patientID = "";
        private string wholeName = "";
        private string wholeNameKana = "";
        private string birthDate = "";
        private string sex = "";
        private string houseHolderWholeName = "";
        private string relationship = "";
        private string occupation = "";
        private string cellularNumber = "";
        private string faxNumber = "";
        private string emailAddress = "";
        private string contraindication1 = "";
        private string allergy1 = "";
        private string infection1 = "";
        private string comment1 = "";
        private List<HomeAddressInfo> homeAddressInfo;
        private List<WorkPlaceInfo> workPlaceInfo;
        private List<InsuranceInfo> insuranceInfo;
        private List<PublicInsuranceInfo> publicInsuranceInfo;

        public string Modkey
        {
            get { return modKey; }
            set { modKey = value; }
        }

        public string PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        public string WholeName
        {
            get { return wholeName; }
            set { wholeName = value; }
        }

        public string WholeNameKana
        {
            get { return wholeNameKana; }
            set { wholeNameKana = value; }
        }

        public string Birthdate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public string HouseHolderWholeName
        {
            get { return houseHolderWholeName; }
            set { houseHolderWholeName = value; }
        }

        public string Relationship
        {
            get { return relationship; }
            set { relationship = value; }
        }

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public string CellularNumber
        {
            get { return cellularNumber; }
            set { cellularNumber = value; }
        }

        public string FaxNumber
        {
            get { return faxNumber; }
            set { faxNumber = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string Contraindication1
        {
            get { return contraindication1; }
            set { contraindication1 = value; }
        }

        public string Allergy1
        {
            get { return allergy1; }
            set { allergy1 = value; }
        }

        public string Infection1
        {
            get { return infection1; }
            set { infection1 = value; }
        }

        public string Comment1
        {
            get { return comment1; }
            set { comment1 = value; }
        }

        public List<HomeAddressInfo> HomeAddressInfo
        {
            get { return homeAddressInfo; }
            set { homeAddressInfo = value; }
        }

        public List<WorkPlaceInfo> WorkPlaceInfo
        {
            get { return workPlaceInfo; }
            set { workPlaceInfo = value; }
        }

        public List<InsuranceInfo> InsuranceInfo
        {
            get { return insuranceInfo; }
            set { insuranceInfo = value; }
        }
        public List<PublicInsuranceInfo> PublicInsuranceInfo
        {
            get { return publicInsuranceInfo; }
            set { publicInsuranceInfo = value; }
        }
        public PatientModInfo()
        { }
    }
}
