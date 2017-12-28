using System;
using System.Collections.Generic;
using System.Text;
using MedicalInterface.Mml23.MmlPsi;
using System.Xml;

namespace IHIS.Framework.Mml23.MmlRe
{
    public class ReferToPerson
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

        public ReferToPerson()
        {
            this.Parson = new PersonalizedInfo();
        }

        public ReferToPerson(XmlNode node)
        {
            this.Parson = new PersonalizedInfo();
            this.LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            nsmgr.AddNamespace(MedicalInterface.Mml23.MmlPsi.PersonalizedInfo.NameSpacePrefix, MedicalInterface.Mml23.MmlPsi.PersonalizedInfo.NameSpaceURI);
            //XmlNode subnode = node.SelectSingleNode("mmlRe:referToPerson", nsmgr);
            XmlNode subnode = node;

            if (subnode != null)
            {
                this.Parson = new PersonalizedInfo(subnode.SelectSingleNode("mmlPsi:PersonalizedInfo", nsmgr));
            }
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "referToPerson", NameSpaceURI);
            node.AppendChild(Parson.WriteXml(doc));
            return node;
        }
    }
}
