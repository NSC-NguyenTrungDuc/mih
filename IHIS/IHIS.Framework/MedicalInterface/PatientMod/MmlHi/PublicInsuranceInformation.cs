using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IHIS.Framework.PatientMod.MmlHi
{
    public class PublicInsuranceInformation
    {
        private List<PublicInsuranceInformationChild> publicInsuranceInformationChild;

        public List<PublicInsuranceInformationChild> PublicInsuranceInformationChild
        {
            get { return publicInsuranceInformationChild; }
            set { publicInsuranceInformationChild = value; }
        }

        public PublicInsuranceInformation(List<PublicInsuranceInformationChild> publicInsuranceInformationChild)
        {
            this.publicInsuranceInformationChild = publicInsuranceInformationChild;
        }

        private void LoadFromXml(XmlNode node)
        {
            // TODO
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("PublicInsurance_Information");
            node.Attributes = Helpers.CreateAttr(doc, "type", "array");

            foreach (PublicInsuranceInformationChild item in this.PublicInsuranceInformationChild)
            {
                node.AppendChild(item.WriteXml(doc));
            }
        }
    }
}
