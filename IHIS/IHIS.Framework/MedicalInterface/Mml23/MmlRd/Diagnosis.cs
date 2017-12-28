using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlRd {
    public class Diagnosis {
        private string _code;
        private string _system;
        private string _text;
        private int _permission;

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

        public int Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }

        public Diagnosis() {

        }

        public Diagnosis(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            int permission;
            bool ok = int.TryParse(node.Attributes["permission", NameSpaceURI] != null ? node.Attributes["permission", NameSpaceURI].Value : "15", out permission);
            permission = ok ? permission : 15;

            this.Permission = permission;

            this.Code = node.Attributes["code", NameSpaceURI].Value;

            this.System = node.Attributes["system", NameSpaceURI].Value;

            this.Text = node.InnerText;

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "diagnosis", NameSpaceURI);

            XmlAttribute attrPermission = doc.CreateAttribute(NameSpacePrefix, "permission", NameSpaceURI);
            attrPermission.Value = this.Permission.ToString();
            node.Attributes.Append(attrPermission);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "code", NameSpaceURI);
            attr.Value = this.Code;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "system", NameSpaceURI);
            attr.Value = this.System;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }

    }
}
