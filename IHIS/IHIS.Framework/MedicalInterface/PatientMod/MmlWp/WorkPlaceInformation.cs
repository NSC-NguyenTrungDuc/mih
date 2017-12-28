using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IHIS.Framework.PatientMod.MmlWp
{
    class WorkPlaceInformation
    {
        private string wholeName = "";
        private string zipCode = "";
        private string wholeAddress1 = "";
        private string wholeAddress2 = "";
        private string phoneNumber = "";

        public string WholeName
        {
            get { return wholeName; }
            set { wholeName = value; }
        }

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

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public WorkPlaceInformation(string wholeName, string zipCode, string wholeAddress1, string wholeAddress2, string phoneNumber)
        {
            this.wholeName = wholeName;
            this.zipCode = zipCode;
            this.wholeAddress1 = wholeAddress1;
            this.wholeAddress2 = wholeAddress2;
            this.phoneNumber = phoneNumber;
        }

        public WorkPlaceInformation()
        { }

        private void LoadFromXml(XmlNode node)
        {
            // TODO
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("WorkPlace_Information");
            node.Attributes = Helpers.CreateAttr(doc, "type", "record");

            XmlElement elm;

            if (!string.IsNullOrEmpty(this.WholeName))
            {
                elm = doc.CreateElement("WholeName");
                elm.AppendChild(doc.CreateTextNode(this.WholeName));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

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

            if (!string.IsNullOrEmpty(this.PhoneNumber))
            {
                elm = doc.CreateElement("PhoneNumber");
                elm.AppendChild(doc.CreateTextNode(this.PhoneNumber));
                elm.Attributes = Helpers.CreateAttr(doc, "type", "string");
                node.AppendChild(elm);
            }

            return node;
        }
    }
}
