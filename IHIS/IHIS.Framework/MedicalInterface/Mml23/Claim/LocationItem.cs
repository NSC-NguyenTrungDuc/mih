using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class LocationItem {
        private string _text;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public LocationItem() {

        }

        public LocationItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp = new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.Text = ndhp.Node.InnerText;

        }

    }
}
