using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IHIS.Framework.PatientMod.MmlHi
{
    public class PublicInsuranceInformationChild
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

        private void LoadFromXml(XmlNode node)
        {
            // TODO
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("PublicInsurance_Information_child");
            node.Attributes = Helpers.CreateAttr(doc, "type", "record");
            XmlElement elm;

            if (!string.IsNullOrEmpty(this.PublicInsuranceClass))
            {
                elm = doc.CreateElement("PublicInsurance_Class");
                elm.AppendChild(doc.CreateTextNode(this.PublicInsuranceClass));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.PublicInsuranceName))
            {
                elm = doc.CreateElement("PublicInsurance_Name");
                elm.AppendChild(doc.CreateTextNode(this.PublicInsuranceName));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.PublicInsurerNumber))
            {
                elm = doc.CreateElement("PublicInsurer_Number");
                elm.AppendChild(doc.CreateTextNode(this.PublicInsurerNumber));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.PublicInsuredPersonNumber))
            {
                elm = doc.CreateElement("PublicInsuredPerson_Number");
                elm.AppendChild(doc.CreateTextNode(this.PublicInsuredPersonNumber));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.Certificate_IssuedDate))
            {
                elm = doc.CreateElement("Certificate_IssuedDate");
                elm.AppendChild(doc.CreateTextNode(this.Certificate_IssuedDate));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            return node;
        }
    }
}
