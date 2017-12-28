using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlRd {
    public class OutcomeItem {
        private string _tableId;
        private string _text;

        public string NameSpaceURI {
            get {
                return RegisteredDiagnosisModule.NameSpaceURI;
            }
        }

        public string NameSpacePrefix {
            get {
                return RegisteredDiagnosisModule.NameSpacePrefix;
            }
        }

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public OutcomeItem() {
            this.TableId = "MML0016";
            this.Text = "";
        }

        public OutcomeItem(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            this.TableId = "MML0016";

            this.Text = node.InnerText;

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "outcome", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }

        public bool IsNull() {
            if (String.IsNullOrEmpty(this.Text)) {
                return true;
            } else {
                return false;
            }
        }

    }
}
