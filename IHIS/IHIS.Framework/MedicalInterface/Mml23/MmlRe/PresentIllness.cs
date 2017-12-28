using System;
using System.Collections.Generic;
using System.Text;
using MedicalInterface.Mml23.MmlCm;
using System.Xml;

namespace IHIS.Framework.Mml23.MmlRe
{
    public class PresentIllness
    {
        private string text;
        private List<ExternalReference> exRef;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public List<ExternalReference> ExRef
        {
            get { return exRef; }
            set { exRef = value; }
        }

        public string NameSpaceURI
        {
            get { return ReferralModule.NameSpaceURI; }
        }

        public string NameSpacePrefix
        {
            get { return ReferralModule.NameSpacePrefix; }
        }

        public PresentIllness()
        {
            ExRef = new List<ExternalReference>();
        }

        public PresentIllness(XmlNode node)
        {
            ExRef = new List<ExternalReference>();
            this.LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            nsmgr.AddNamespace(MedicalInterface.Mml23.MmlCm.ExternalReference.NameSpacePrefix, MedicalInterface.Mml23.MmlCm.ExternalReference.NameSpaceURI);
            //XmlNode subnode = node.SelectSingleNode("mmlRe:presentIllness", nsmgr);
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
            XmlElement node = doc.CreateElement(NameSpacePrefix, "presentIllness", NameSpaceURI);
            node.AppendChild(doc.CreateTextNode(this.Text));

            foreach (ExternalReference item in this.ExRef)
            {
                node.AppendChild(item.WriteXml(doc));
            }

            return node;
        }
    }
}
