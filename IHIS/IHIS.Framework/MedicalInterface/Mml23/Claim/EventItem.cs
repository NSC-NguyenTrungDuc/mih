using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class EventItem {
        private DateTime _startDate;
        private DateTime _endDate;
        private string _text;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public EventItem() {

        }

        public EventItem(XmlNode node) {
            if (node != null) {
                LoadFromXml(node);
            }
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp = new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.StartDate = ndhp.GetAttributeDate("claim:eventStart", DateTime.MinValue);
            this.EndDate = ndhp.GetAttributeDate("claim:eventEnd", DateTime.MinValue);
            this.Text = ndhp.Node.InnerText;

        }
    }
}
