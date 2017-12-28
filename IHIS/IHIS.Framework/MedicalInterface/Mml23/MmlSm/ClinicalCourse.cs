using System;
using System.Collections.Generic;
using System.Text;
using MedicalInterface.Mml23.MmlCm;
using System.Xml;

namespace IHIS.Framework.Mml23.MmlSm
{
    public class ClinicalCourse
    {
        private List<ClinicalRecord> clinicalRecord;

        public List<ClinicalRecord> ClinicalRecord
        {
            get { return clinicalRecord; }
            set { clinicalRecord = value; }
        }

        public string NameSpaceURI
        {
            get { return SummaryModule.NameSpaceURI; }
        }

        public string NameSpacePrefix
        {
            get { return SummaryModule.NameSpacePrefix; }
        }

        public ClinicalCourse()
        {
            this.ClinicalRecord = new List<ClinicalRecord>();
        }

        public ClinicalCourse(XmlNode node)
        {
            this.ClinicalRecord = new List<ClinicalRecord>();
            this.LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            //XmlNode subnode = node.SelectSingleNode("mmlRe:clinicalCourse", nsmgr);
            XmlNode subnode = node;

            this.ClinicalRecord = new List<ClinicalRecord>();
            foreach (XmlNode nd in subnode.SelectNodes("mmlSm:clinicalRecord", nsmgr))
            {
                ClinicalRecord er = new ClinicalRecord(nd);
                this.ClinicalRecord.Add(er);
            }
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "clinicalCourse", NameSpaceURI);
            foreach (ClinicalRecord cr in ClinicalRecord)
            {
                node.AppendChild(cr.WriteXml(doc));
            }

            return node;
        }
    }
}
