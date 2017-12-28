using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using MedicalInterface;

namespace IHIS.Framework.PatientMod.MmlAd
{
    public class HomeAddressInformation
    {
        private string zipCode;
        private string wholeAddress1;
        private string wholeAddress2;
        private string phoneNumber1;
        private string phoneNumber2;

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string WholeAddress1
        {
            get { return wholeAddress1; }
            set { wholeAddress1 = value; }
        }

        public string WholeAddress2
        {
            get { return wholeAddress2; }
            set { wholeAddress2 = value; }
        }

        public string PhoneNumber1
        {
            get { return phoneNumber1; }
            set { phoneNumber1 = value; }
        }

        public string PhoneNumber2
        {
            get { return phoneNumber2; }
            set { phoneNumber2 = value; }
        }

        public HomeAddressInformation(string zipCode, string wholeAddress1, string wholeAddress2, string phoneNumber1, string phoneNumber2)
        {
            this.zipCode = zipCode;
            this.wholeAddress1 = wholeAddress1;
            this.wholeAddress2 = wholeAddress2;
            this.phoneNumber1 = phoneNumber1;
            this.phoneNumber2 = phoneNumber2;
        }

        public HomeAddressInformation()
        {
        }

        private void LoadFromXml(XmlNode node)
        {
            // TODO
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("Home_Address_Information");
            node.Attributes = Helpers.CreateAttr(doc, "type", "record");

            XmlElement elm;

            if (!string.IsNullOrEmpty(this.ZipCode))
            {
                elm = doc.CreateElement("Address_ZipCode");
                elm.AppendChild(doc.CreateTextNode(this.ZipCode));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.WholeAddress1))
            {
                elm = doc.CreateElement("WholeAddress1");
                elm.AppendChild(doc.CreateTextNode(this.WholeAddress1));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.WholeAddress2))
            {
                elm = doc.CreateElement("WholeAddress2");
                elm.AppendChild(doc.CreateTextNode(this.WholeAddress2));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.PhoneNumber1))
            {
                elm = doc.CreateElement("PhoneNumber1");
                elm.AppendChild(doc.CreateTextNode(this.PhoneNumber1));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.PhoneNumber2))
            {
                elm = doc.CreateElement("PhoneNumber2");
                elm.AppendChild(doc.CreateTextNode(this.PhoneNumber2));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            return node;
        }
    }
}
