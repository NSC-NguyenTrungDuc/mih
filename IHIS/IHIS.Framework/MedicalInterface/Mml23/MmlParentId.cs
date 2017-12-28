using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlParentId {
        private string _relation;
        private string _tableId;
        private string _docId;

        public string Relation
        {
            get { return _relation; }
            set { _relation = value; }
        }

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string DocId
        {
            get { return _docId; }
            set { _docId = value; }
        }

        public MmlParentId() {
        }

        public MmlParentId(XmlNode node) {
            this.TableId = "MML0008";
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlAttribute attr;

            attr = node.Attributes["relation"];
            if (attr != null) {
                this.Relation = attr.Value;
            }

            this.DocId = node.InnerText.Trim();

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement("parentid");

            XmlAttribute attr = doc.CreateAttribute("relation");
            attr.Value = this.Relation;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute("tableId");
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.DocId));

            return node;
        }

    }
}
