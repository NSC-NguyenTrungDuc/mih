using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class NumberItem {
        private string _code;
        private string _codeTableId;
        private string _unit;
        private decimal _value;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string CodeTableId
        {
            get { return _codeTableId; }
            set { _codeTableId = value; }
        }

        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public Decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public NumberItem() {

        }

        public NumberItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp = new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.Code = ndhp.GetAttributeString("claim:numberCode");
            this.CodeTableId = ndhp.GetAttributeString("claim:numberCodeId");
            this.Unit = ndhp.GetAttributeString("claim:unit");

            string tmpstr = ndhp.Node.InnerText;
            decimal val;
            if (!Decimal.TryParse(tmpstr, out val)) {
                this.Value = val;
            } else {
                this.Value = 0;
            }
        }
    }
}
