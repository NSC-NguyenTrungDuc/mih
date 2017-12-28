using System;
using System.Collections.Generic;
using System.Text;
using IHIS.Framework.PatientMod.MmlAd;
using IHIS.Framework.PatientMod.MmlWp;
using IHIS.Framework.PatientMod.MmlHi;
using System.Xml;

namespace IHIS.Framework.PatientMod
{
    public class PatientModModule
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
        private List<HomeAddressInformation> homeAddressInformation;
        private List<WorkPlaceInformation> workPlaceInformation;
        private List<HealthInsuranceInformation> healthInsuranceInformation;

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

        public List<HomeAddressInformation> HomeAddressInformation
        {
            get { return homeAddressInformation; }
            set { homeAddressInformation = value; }
        }

        private List<WorkPlaceInformation> WorkPlaceInformation
        {
            get { return workPlaceInformation; }
            set { workPlaceInformation = value; }
        }

        private List<HealthInsuranceInformation> HealthInsuranceInformation
        {
            get { return healthInsuranceInformation; }
            set { healthInsuranceInformation = value; }
        }

        private void LoadFromXml(XmlNode node)
        {
            // TODO
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("data");
            XmlElement node = doc.CreateElement("patientmodreq");
            node.Attributes = Helpers.CreateAttr(doc, "type", "record");
            baseNode.AppendChild(node);

            XmlElement elm;

            if (!string.IsNullOrEmpty(this.ModKey))
            {
                elm = doc.CreateElement("Mod_Key");
                elm.AppendChild(doc.CreateTextNode(this.ModKey));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.PatientID))
            {
                elm = doc.CreateElement("Patient_ID");
                elm.AppendChild(doc.CreateTextNode(this.PatientID));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.WholeName))
            {
                elm = doc.CreateElement("WholeName");
                elm.AppendChild(doc.CreateTextNode(this.WholeName));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.WholeNameKana))
            {
                elm = doc.CreateElement("WholeName_inKana");
                elm.AppendChild(doc.CreateTextNode(this.WholeNameKana));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.BirthDate))
            {
                elm = doc.CreateElement("BirthDate");
                elm.AppendChild(doc.CreateTextNode(this.BirthDate));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.Sex))
            {
                elm = doc.CreateElement("Sex");
                elm.AppendChild(doc.CreateTextNode(this.Sex));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.HouseHolderWholeName))
            {
                elm = doc.CreateElement("HouseHolder_WholeName");
                elm.AppendChild(doc.CreateTextNode(this.HouseHolderWholeName));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.Relationship))
            {
                elm = doc.CreateElement("Relationship");
                elm.AppendChild(doc.CreateTextNode(this.Relationship));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.Occupation))
            {
                elm = doc.CreateElement("Occupation");
                elm.AppendChild(doc.CreateTextNode(this.Occupation));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.CellularNumber))
            {
                elm = doc.CreateElement("CellularNumber");
                elm.AppendChild(doc.CreateTextNode(this.CellularNumber));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.FaxNumber))
            {
                elm = doc.CreateElement("FaxNumber");
                elm.AppendChild(doc.CreateTextNode(this.FaxNumber));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.EmailAddress))
            {
                elm = doc.CreateElement("EmailAddress");
                elm.AppendChild(doc.CreateTextNode(this.EmailAddress));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            foreach (HomeAddressInformation item in this.HomeAddressInformation)
            {
                node.AppendChild(item.WriteXml(doc));
            }

            foreach (WorkPlaceInformation item in this.WorkPlaceInformation)
            {
                node.AppendChild(item.WriteXml(doc));
            }

            if (!string.IsNullOrEmpty(this.Contraindication1))
            {
                elm = doc.CreateElement("Contraindication1");
                elm.AppendChild(doc.CreateTextNode(this.Contraindication1));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.Allergy1))
            {
                elm = doc.CreateElement("Allergy1");
                elm.AppendChild(doc.CreateTextNode(this.Allergy1));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.Infection1))
            {
                elm = doc.CreateElement("Infection1");
                elm.AppendChild(doc.CreateTextNode(this.Infection1));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.Comment1))
            {
                elm = doc.CreateElement("Comment1");
                elm.AppendChild(doc.CreateTextNode(this.Comment1));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            foreach (HealthInsuranceInformation item in this.HealthInsuranceInformation)
            {
                node.AppendChild(item.WriteXml(doc));
            }

            return node;
        }
    }
}
