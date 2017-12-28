using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class AppointItem {
        private string _code;
        private string _tableId;
        private string _memo;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        public AppointItem() {

        }

        public AppointItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace("claim", NameSpaceURI);
            XmlAttribute attr;
            attr = node.Attributes["appCode", NameSpaceURI];
            if (attr != null) {
                this.Code = attr.Value;
            }
            attr = node.Attributes["appCodeId", NameSpaceURI];
            if (attr != null) {
                this.TableId = attr.Value;
            }

            this.Memo = node.InnerText.Trim();

        }

    }
}
