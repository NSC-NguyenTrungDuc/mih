using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlHi {
    public class InsuranceClass {
        private string _tableId;
        private string _code;
        private string _text;

        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1";

        public const string NameSpacePrefix = "mmlHi";


        public String TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public InsuranceClass() {

        }

        public InsuranceClass(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.Code = node.Attributes["ClassCode", NameSpaceURI].Value;
            this.TableId = node.Attributes["tableId", NameSpaceURI].Value;
            this.Text = node.InnerText.Trim();
        }
    }
}
