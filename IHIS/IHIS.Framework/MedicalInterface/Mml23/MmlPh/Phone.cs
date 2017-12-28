using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlPh {
    public class Phone {
        private string _equipType;
        private string _tableId;
        private string _area;
        private string _city;
        private string _number;
        private string _extension;
        private string _memo;
        private string _country;

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/Phone/1.0";

        public const string NameSpacePrefix = "mmlPh";

        public string EquipType
        {
            get { return _equipType; }
            set { _equipType = value; }
        }

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public Phone() {
            this.TableId = "MML0003 ";
            this.Country = "JPN";
            this.EquipType = "PH";

        }

        public Phone(XmlNode node) {
            this.TableId = "MML0003 ";
            this.Country = "JPN";

            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlAttribute attr;
            attr = node.Attributes["telEquipType", NameSpaceURI];
            if (attr != null) {
                this.EquipType = attr.Value;
            }

            foreach (XmlNode elm in node.ChildNodes) {
                if (elm.LocalName == "area") {
                    this.Area = elm.InnerText.Trim();
                }
                if (elm.LocalName == "city") {
                    this.City = elm.InnerText.Trim();
                }
                if (elm.LocalName == "number") {
                    this.Number = elm.InnerText.Trim();
                }
                if (elm.LocalName == "extension") {
                    this.Extension = elm.InnerText.Trim();
                }
                if (elm.LocalName == "memo") {
                    this.Memo = elm.InnerText.Trim();
                }
                if (elm.LocalName == "country") {
                    this.Country = elm.InnerText.Trim();
                }

            }

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "Phone", NameSpaceURI);
            XmlElement elm;
            XmlAttribute attr;

            attr = doc.CreateAttribute(NameSpacePrefix, "telEquipType", NameSpaceURI);
            attr.Value = this.EquipType;
            node.Attributes.Append(attr);

            elm = doc.CreateElement(NameSpacePrefix, "area", NameSpaceURI);
            elm.AppendChild(doc.CreateTextNode(this.Area));
            node.AppendChild(elm);

            elm = doc.CreateElement(NameSpacePrefix, "city", NameSpaceURI);
            elm.AppendChild(doc.CreateTextNode(this.City));
            node.AppendChild(elm);

            elm = doc.CreateElement(NameSpacePrefix, "number", NameSpaceURI);
            elm.AppendChild(doc.CreateTextNode(this.Number));
            node.AppendChild(elm);

            if (!String.IsNullOrEmpty(this.Extension)) {
                elm = doc.CreateElement(NameSpacePrefix, "extension", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Extension));
                node.AppendChild(elm);
            }
            if (!String.IsNullOrEmpty(this.Country)) {
                elm = doc.CreateElement(NameSpacePrefix, "country", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Country));
                node.AppendChild(elm);
            }
            if (!String.IsNullOrEmpty(this.Memo)) {
                elm = doc.CreateElement(NameSpacePrefix, "memo", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Memo));
                node.AppendChild(elm);
            }


            return node;
        }

        public Phone Clone() {
            Phone ph = new Phone();

            ph.Country = this.Country;
            ph.City = this.City;
            ph.Area = this.Area;
            ph.Number = this.Number;
            ph.Extension = this.Extension;
            ph.TableId = this.TableId;
            ph.EquipType = this.EquipType;
            ph.Memo = this.Memo;
            

            return ph;
        }

    }
}
