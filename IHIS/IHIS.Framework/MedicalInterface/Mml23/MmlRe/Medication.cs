using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using MedicalInterface.Mml23.MmlCm;

namespace IHIS.Framework.Mml23.MmlRe
{
    public class Medication
    {
        private List<ExternalReference> exRef;
        private string text;

        public List<ExternalReference> ExRef
        {
            get { return exRef; }
            set { exRef = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string NameSpaceURI
        {
            get { return ReferralModule.NameSpaceURI; }
        }

        public string NameSpacePrefix
        {
            get { return ReferralModule.NameSpacePrefix; }
        }

        public Medication()
        {
            ExRef = new List<ExternalReference>();
        }

        public Medication(XmlNode node)
        {
            ExRef = new List<ExternalReference>();
            this.LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            nsmgr.AddNamespace(MedicalInterface.Mml23.MmlCm.ExternalReference.NameSpacePrefix, MedicalInterface.Mml23.MmlCm.ExternalReference.NameSpaceURI);
            //XmlNode subnode = node.SelectSingleNode("mmlRe:medication", nsmgr);
            XmlNode subnode = node;
            this.Text = subnode != null ? subnode.InnerText : "";

            this.ExRef = new List<ExternalReference>();
            foreach (XmlNode nd in subnode.SelectNodes("mmlCm:extRef", nsmgr))
            {
                ExternalReference er = new ExternalReference(nd);
                this.ExRef.Add(er);
            }
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "medication", NameSpaceURI);
            node.AppendChild(doc.CreateTextNode(this.Text));

            foreach (ExternalReference item in this.ExRef)
            {
                node.AppendChild(item.WriteXml(doc));
            }

            return node;
        }
    }
}
