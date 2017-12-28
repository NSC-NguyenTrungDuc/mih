using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IHIS.Framework.PatientMod.MmlHi
{
    public class HealthInsuranceInformation
    {
        private string insuranceProviderClass = "";
        private string insuranceProviderNumber = "";
        private string insuranceProviderWholeName = "";
        private string healthInsuredPersonSymbol = "";
        private string healthInsuredPersonNumber = "";
        private string relationToInsuredPerson = "";
        private string certificateStartDate = "";
        private List<PublicInsuranceInformation> publicInsuranceInformation;

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

        public List<PublicInsuranceInformation> PublicInsuranceInformation
        {
            get { return publicInsuranceInformation; }
            set { publicInsuranceInformation = value; }
        }

        public HealthInsuranceInformation(List<PublicInsuranceInformation> publicInsuranceInformation)
        {
            this.PublicInsuranceInformation = publicInsuranceInformation;
        }

        private void LoadFromXml(XmlNode node)
        {
            // TODO
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("HealthInsurance_Information");
            node.Attributes = Helpers.CreateAttr(doc, "type", "record");

            XmlElement elm;

            if (!string.IsNullOrEmpty(this.InsuranceProviderClass))
            {
                elm = doc.CreateElement("InsuranceProvider_Class");
                elm.AppendChild(doc.CreateTextNode(this.InsuranceProviderClass));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.InsuranceProviderNumber))
            {
                elm = doc.CreateElement("InsuranceProvider_Number ");
                elm.AppendChild(doc.CreateTextNode(this.InsuranceProviderNumber));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.InsuranceProviderWholeName))
            {
                elm = doc.CreateElement("InsuranceProvider_WholeName ");
                elm.AppendChild(doc.CreateTextNode(this.InsuranceProviderWholeName));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.HealthInsuredPersonSymbol))
            {
                elm = doc.CreateElement("HealthInsuredPerson_Symbol ");
                elm.AppendChild(doc.CreateTextNode(this.HealthInsuredPersonSymbol));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.HealthInsuredPersonNumber))
            {
                elm = doc.CreateElement("HealthInsuredPerson_Number ");
                elm.AppendChild(doc.CreateTextNode(this.HealthInsuredPersonNumber));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.RelationToInsuredPerson))
            {
                elm = doc.CreateElement("RelationToInsuredPerson");
                elm.AppendChild(doc.CreateTextNode(this.RelationToInsuredPerson));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.CertificateStartDate))
            {
                elm = doc.CreateElement("Certificate_StartDate ");
                elm.AppendChild(doc.CreateTextNode(this.CertificateStartDate));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            return node;
        }
    }
}
