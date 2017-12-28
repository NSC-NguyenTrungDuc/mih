using System;
using System.Collections.Generic;
using System.Text;
using MedicalInterface.Mml23.MmlPsi;
using System.Xml;

namespace IHIS.Framework.Mml23.MmlRe
{
    public class ReferFrom
    {
        private PersonalizedInfo parson;
        public PersonalizedInfo Parson
        {
            get { return parson; }
            set { parson = value; }
        }

        public string NameSpaceURI
        {
            get { return ReferralModule.NameSpaceURI; }
        }

        public string NameSpacePrefix
        {
            get { return ReferralModule.NameSpacePrefix; }
        }

        public ReferFrom()
        {
            this.Parson = new PersonalizedInfo();
        }

        public ReferFrom(XmlNode node)
        {
            this.Parson = new PersonalizedInfo();
            this.LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            nsmgr.AddNamespace(MedicalInterface.Mml23.MmlPsi.PersonalizedInfo.NameSpacePrefix, MedicalInterface.Mml23.MmlPsi.PersonalizedInfo.NameSpaceURI);
            XmlNode subnode = node;
            this.Parson = new PersonalizedInfo(subnode.SelectSingleNode("mmlPsi:PersonalizedInfo", nsmgr));
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "referFrom", NameSpaceURI);
            node.AppendChild(Parson.WriteXml(doc));
            return node;
        }
    }
}
