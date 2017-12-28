using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class BundleItem {
        private string _classCode;
        private string _classCodeTableId;
        private string _className;
        private string _administrationCode;
        private string _administrationCodeTableId;
        private string _administrationMemo;
        private int _bundleNumber;
        private string _memo;
        private string _code;
        private string _numberCode;
        private string _number;
        private List<BundleDetailItem> _detailList;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string ClassCode
        {
            get { return _classCode; }
            set { _classCode = value; }
        }

        public string ClassCodeTableId
        {
            get { return _classCodeTableId; }
            set { _classCodeTableId = value; }
        }

        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        public string AdministrationCode
        {
            get { return _administrationCode; }
            set { _administrationCode = value; }
        }

        public string AdministrationCodeTableId
        {
            get { return _administrationCodeTableId; }
            set { _administrationCodeTableId = value; }
        }

        public string AdministrationMemo
        {
            get { return _administrationMemo; }
            set { _administrationMemo = value; }
        }

        public int BundleNumber
        {
            get { return _bundleNumber; }
            set { _bundleNumber = value; }
        }

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string NumberCode
        {
            get { return _numberCode; }
            set { _numberCode = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public List<BundleDetailItem> DetailList
        {
            get { return _detailList; }
            set { _detailList = value; }
        }

        public BundleItem() {
            _detailList = new List<BundleDetailItem>();
        }

        public BundleItem(XmlNode node) {
            _detailList = new List<BundleDetailItem>();
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp= new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.ClassCode = ndhp.GetAttributeString("claim:classCode");
            this.ClassCodeTableId = ndhp.GetAttributeString("claim:classCodeId");
            this.ClassName = ndhp.GetNodeText("claim:className");

            this.AdministrationCode = ndhp.GetChildNodeAttributeString("claim:administration", "claim:adminCode");
            this.AdministrationCodeTableId = ndhp.GetChildNodeAttributeString("claim:administration", "claim:adminCodeId");
            this.AdministrationMemo = ndhp.GetNodeText("admMemo");

            this.BundleNumber = ndhp.GetNodeTextToInteger("claim:bundleNumber", 1);

            this.DetailList = new List<BundleDetailItem>();
            foreach (XmlNode dtnode in ndhp.SelectNodes("claim:item")) {
                BundleDetailItem dt = new BundleDetailItem(dtnode);
                this.DetailList.Add(dt);
            }

            this.Memo = ndhp.GetNodeText("claim:memo");
        }

    }
}
