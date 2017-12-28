using System;
using System.Collections.Generic;
using System.Text;
using MedicalInterface.Mml23.MmlCm;
using System.Xml;

namespace IHIS.Framework.Mml23.MmlSm
{
    public class ClinicalRecord
    {
        private DateTime? date;
        private List<ExternalReference> exRef;
        private List<RelatedDoc> relatedDoc;
        private string text;

        public DateTime? Date
        {
            get { return date; }
            set { date = value; }
        }

        public List<ExternalReference> ExRef
        {
            get { return exRef; }
            set { exRef = value; }
        }

        public List<RelatedDoc> RelatedDoc
        {
            get { return relatedDoc; }
            set { relatedDoc = value; }
        }

        public string NameSpaceURI
        {
            get { return SummaryModule.NameSpaceURI; }
        }

        public string NameSpacePrefix
        {
            get { return SummaryModule.NameSpacePrefix; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public ClinicalRecord()
        {
            this.RelatedDoc = new List<RelatedDoc>();
            this.ExRef = new List<ExternalReference>();
        }

        public ClinicalRecord(DateTime? date, List<ExternalReference> exRef, List<RelatedDoc> relatedDoc, string text)
        {
            this.date = date;
            this.exRef = exRef;
            this.relatedDoc = relatedDoc;
            this.text = text;
        }

        public ClinicalRecord(XmlNode node)
        {
            this.RelatedDoc = new List<RelatedDoc>();
            this.ExRef = new List<ExternalReference>();
            this.LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            nsmgr.AddNamespace(MedicalInterface.Mml23.MmlCm.ExternalReference.NameSpacePrefix, MedicalInterface.Mml23.MmlCm.ExternalReference.NameSpaceURI);
            XmlNode subnode;
            //subnode = node.SelectSingleNode("mmlRe:clinicalRecord", nsmgr);
            subnode = node;
            if (subnode != null)
            {
                DateTime dt;
                if (subnode.Attributes["mmlSm:date", NameSpaceURI] != null)
                {
                    if (DateTime.TryParse(subnode.Attributes["mmlSm:date", NameSpaceURI].Value, out dt))
                    {
                        this.Date = dt;
                    } 
                }

                this.Text = subnode.InnerText;
            }

            this.ExRef = new List<ExternalReference>();
            foreach (XmlNode nd in node.SelectNodes("mmlCm:extRef", nsmgr))
            {
                ExternalReference er = new ExternalReference(nd);
                this.ExRef.Add(er);
            }

            this.ExRef = new List<ExternalReference>();
            foreach (XmlNode nd in node.SelectNodes("mmlSm:relatedDoc", nsmgr))
            {
                ExternalReference er = new ExternalReference(nd);
                this.ExRef.Add(er);
            }
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "clinicalRecord", NameSpaceURI);
            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "date", NameSpaceURI);
            attr.Value = this.Date.HasValue ? this.Date.Value.ToString("yyyy-MM-dd") : "";
            node.Attributes.Append(attr);
            node.AppendChild(doc.CreateTextNode(this.Text));

            foreach (ExternalReference eRef in ExRef)
            {
                node.AppendChild(eRef.WriteXml(doc));
            }

            foreach (RelatedDoc reDoc in RelatedDoc)
            {
                node.AppendChild(reDoc.WriteXml(doc));
            }

            return node;
        }
    }
}
