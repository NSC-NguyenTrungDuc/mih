using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class FilmItem {
        private string _sizeCode;
        private string _sizeCodeTableId;
        private string _filmName;
        private string _filmDivision;
        private int _filmNumber;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string SizeCode
        {
            get { return _sizeCode; }
            set { _sizeCode = value; }
        }

        public string SizeCodeTableId
        {
            get { return _sizeCodeTableId; }
            set { _sizeCodeTableId = value; }
        }

        public string FilmName
        {
            get { return _filmName; }
            set { _filmName = value; }
        }

        public string FilmDivision
        {
            get { return _filmDivision; }
            set { _filmDivision = value; }
        }

        public int FilmNumber
        {
            get { return _filmNumber; }
            set { _filmNumber = value; }
        }

        public FilmItem() {

        }

        public FilmItem(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp = new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.SizeCode = ndhp.GetChildNodeAttributeString("claim:filmSize", "claim:sizeCode");
            this.SizeCodeTableId = ndhp.GetChildNodeAttributeString("claim:filmSize", "claim:sizeCodeId");
            this.FilmDivision = ndhp.GetChildNodeAttributeString("claim:filmSize", "claim:filmDivision");

            this.FilmName = ndhp.GetNodeText("claim:filmSize");

            this.FilmNumber = ndhp.GetNodeTextToInteger("claim:filmNumber", 0);

        }
    }
}
