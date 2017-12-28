using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlRd {
    public class DiagnosisItem {
        private string _code;
        private string _system;
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

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string System
        {
            get { return _system; }
            set { _system = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public DiagnosisItem() {

        }

        public DiagnosisItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            XmlNode subnode = node.SelectSingleNode("mmlRd:name", nsmgr);

            this.Code = subnode.Attributes["code", NameSpaceURI].Value;

            this.System = subnode.Attributes["system", NameSpaceURI].Value;

            this.Text = subnode.InnerText.Trim();

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "dxItem", NameSpaceURI);
            
            XmlElement subnode = doc.CreateElement(NameSpacePrefix, "name", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "code", NameSpaceURI);
            attr.Value = this.Code;
            subnode.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "system", NameSpaceURI);
            attr.Value = this.System;
            subnode.Attributes.Append(attr);

            subnode.AppendChild(doc.CreateTextNode(this.Text));

            node.AppendChild(subnode);

            return node;
        }

    }
}
