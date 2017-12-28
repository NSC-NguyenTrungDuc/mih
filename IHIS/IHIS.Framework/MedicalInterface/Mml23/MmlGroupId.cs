using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    public class MmlGroupId {
        private string _groupClass;
        private string _tableId;
        private string _docId;

        public string GroupClass
        {
            get { return _groupClass; }
            set { _groupClass = value; }
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

        public MmlGroupId() {
        }

        public MmlGroupId(XmlNode node) {
            this.TableId = "MML0007";
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlAttribute attr;

            attr = node.Attributes["groupClass"];
            if (attr != null) {
                this.GroupClass = attr.Value;
            }

            this.DocId = node.InnerText.Trim();

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement("groupid");

            XmlAttribute attr = doc.CreateAttribute("groupClass");
            attr.Value = this.GroupClass;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute("tableId");
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.DocId));

            return node;
        }

    }
}
