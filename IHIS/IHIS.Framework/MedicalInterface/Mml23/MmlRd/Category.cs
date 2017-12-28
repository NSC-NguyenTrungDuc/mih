using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlRd {
    public class Category {
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

        public Category() {
            this.TableId = "";
            this.Text = "";
        }

        public Category(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            this.TableId = node.Attributes["tableId", NameSpaceURI].Value;

            this.Text = node.InnerText;

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "category", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }

    }
}
