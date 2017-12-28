namespace MedicalInterface.Mml23.MmlPc
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class Plan
    {
        private string _planNotes;
        private RxTxTestItem _testOrder;
        private RxTxTestItem _txOrder;
        private RxTxTestItem _rxOrder;
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

        public String PlanNotes
        {
            get { return _planNotes; }
            set { _planNotes = value; }
        }

        public RxTxTestItem TestOrder
        {
            get { return _testOrder; }
            set { _testOrder = value; }
        }

        public RxTxTestItem TxOrder
        {
            get { return _txOrder; }
            set { _txOrder = value; }
        }

        public RxTxTestItem RxOrder
        {
            get { return _rxOrder; }
            set { _rxOrder = value; }
        }

        public int Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }

        public Plan()
        {
        }

        public Plan(XmlNode node)
        {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            bool ok = int.TryParse(
                node.Attributes["permission", NameSpaceURI] != null ? node.Attributes["permission", NameSpaceURI].Value : "15",
                out this._permission);
            this._permission = ok ? _permission : 15;

            foreach (XmlNode elm in node.ChildNodes)
            {
                if (elm.LocalName == "planNotes")
                {
                    this.PlanNotes = elm.InnerText;
                }
                if (elm.LocalName == "testOrder")
                {
                    this.TestOrder = new RxTxTestItem(elm);
                }
                if (elm.LocalName == "rxOrder")
                {
                    this.RxOrder = new RxTxTestItem(elm);
                }
                if (elm.LocalName == "txOrder")
                {
                    this.TxOrder = new RxTxTestItem(elm);
                }
            }
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "plan", NameSpaceURI);
            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "permission", NameSpaceURI);
            attr.Value = this._permission.ToString();
            node.Attributes.Append(attr);

            XmlElement elm;

            if (!string.IsNullOrEmpty(PlanNotes))
            {
                elm = doc.CreateElement(NameSpacePrefix, "planNotes", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.PlanNotes));
                node.AppendChild(elm);
            }

            if (TestOrder != null)
            {
                node.AppendChild(TestOrder.WriteXml(doc, "testOrder"));
            }

            if (RxOrder != null)
            {
                node.AppendChild(RxOrder.WriteXml(doc, "rxOrder"));
            }

            if (TxOrder != null)
            {
                node.AppendChild(TxOrder.WriteXml(doc, "txOrder"));
            }

            return node;
        }
    }
}