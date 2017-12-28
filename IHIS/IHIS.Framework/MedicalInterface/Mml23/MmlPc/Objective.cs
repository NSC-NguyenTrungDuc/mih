namespace MedicalInterface.Mml23.MmlPc
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class Objective
    {
        private string _objectiveNotes;
        private List<PhysicalExamItem> _physicalExamContents;
        private RxTxTestItem _testResults;
        private RxTxTestItem _rxRecords;
        private RxTxTestItem _txRecords;
        private int _permission;

        public string NameSpaceURI
        {
            get
            {
                return ProgressCourseModule.NameSpaceURI;
            }
        }

        public string NameSpacePrefix
        {
            get
            {
                return ProgressCourseModule.NameSpacePrefix;
            }
        }

        public int Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }

        public String ObjectiveNotes
        {
            get { return _objectiveNotes; }
            set { _objectiveNotes = value; }
        }

        public List<PhysicalExamItem> PhysicalExamContents
        {
            get { return _physicalExamContents; }
            set { _physicalExamContents = value; }
        }

        public RxTxTestItem TestResults
        {
            get { return _testResults; }
            set { _testResults = value; }
        }

        public RxTxTestItem RxRecords
        {
            get { return _rxRecords; }
            set { _rxRecords = value; }
        }

        public RxTxTestItem TxRecords
        {
            get { return _txRecords; }
            set { _txRecords = value; }
        }

        public Objective()
        {
            this.PhysicalExamContents = new List<PhysicalExamItem>();
        }

        public Objective(XmlNode node)
        {
            this.PhysicalExamContents = new List<PhysicalExamItem>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            bool ok = int.TryParse(node.Attributes["permission", NameSpaceURI] != null ? node.Attributes["permission", NameSpaceURI].Value : "15", out this._permission);
            this._permission = ok ? _permission : 15;

            foreach (XmlNode elm in node.ChildNodes)
            {
                if (elm.LocalName == "objectiveNotes")
                {
                    this.ObjectiveNotes = elm.InnerText;
                }
                if (elm.LocalName == "physicalExam")
                {
                    this.PhysicalExamContents = new List<PhysicalExamItem>();
                    foreach (XmlNode dgnode in elm.ChildNodes)
                    {
                        PhysicalExamItem dg = new PhysicalExamItem(dgnode);
                        this.PhysicalExamContents.Add(dg);
                    }                    
                }
                if (elm.LocalName == "testResult")
                {
                    this.TestResults = new RxTxTestItem(elm);
                }
                if (elm.LocalName == "rxRecord")
                {
                    this.RxRecords = new RxTxTestItem(elm);
                }
                if (elm.LocalName == "txRecord")
                {
                    this.TxRecords = new RxTxTestItem(elm);
                }
            }
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "objective", NameSpaceURI);
            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "permission", NameSpaceURI);
            attr.Value = this._permission.ToString();
            node.Attributes.Append(attr);

            XmlElement elm;

            if (!string.IsNullOrEmpty(ObjectiveNotes))
            {
                elm = doc.CreateElement(NameSpacePrefix, "objectiveNotes", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.ObjectiveNotes));
                node.AppendChild(elm);
            }

            if (PhysicalExamContents.Count > 0)
            {
                XmlElement dcelm = doc.CreateElement(NameSpacePrefix, "physicalExam", NameSpaceURI);
                foreach (PhysicalExamItem itm in this.PhysicalExamContents)
                {
                    dcelm.AppendChild(itm.WriteXml(doc));
                }
                node.AppendChild(dcelm);
            }

            if (TestResults != null)
            {
                node.AppendChild(TestResults.WriteXml(doc, "testResult"));
            }

            if (RxRecords != null)
            {
                node.AppendChild(RxRecords.WriteXml(doc, "rxRecord"));
            }

            if (TxRecords != null)
            {
                node.AppendChild(TxRecords.WriteXml(doc, "txRecord"));
            }

            return node;
        }
    }
}