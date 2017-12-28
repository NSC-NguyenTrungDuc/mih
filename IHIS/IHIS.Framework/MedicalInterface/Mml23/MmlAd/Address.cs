using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlAd {
    public class Address {
        private string _repCode;
        private string _tableId;
        private string _addressClass;
        private string _countryCode;
        private string _zip;
        private string _prefecture;
        private string _city;
        private string _town;
        private string _homeNumber;
        private string _fullName;

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/Address/1.0";

        public const string NameSpacePrefix = "mmlAd";

        public string RepCode
        {
            get { return _repCode; }
            set { _repCode = value; }
        }

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string AddressClass
        {
            get { return _addressClass; }
            set { _addressClass = value; }
        }

        /// <summary>
        /// 国籍コード
        /// </summary>
        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }

        /// <summary>
        /// 郵便番号
        /// </summary>
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        /// <summary>
        /// 都道府県名
        /// </summary>
        public string Prefecture
        {
            get { return _prefecture; }
            set { _prefecture = value; }
        }

        /// <summary>
        /// 市区郡名
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// 町村名
        /// </summary>
        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }

        /// <summary>
        /// 番地、丁目、マンション名、部屋番号など残りすべて
        /// </summary>
        public string HomeNumber
        {
            get { return _homeNumber; }
            set { _homeNumber = value; }
        }

        /// <summary>
        /// 住所完全名称
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        /// <summary>
        /// FullNameしか設定されていないときにTrue
        /// </summary>
        public bool IsFullNameOnly {
            get {
                if (String.IsNullOrEmpty(this.FullName)) {
                    return false;
                } else {
                    StringBuilder bldr = new StringBuilder();
                    bldr.Append(this.Prefecture);
                    bldr.Append(this.City);
                    bldr.Append(this.Town);
                    bldr.Append(this.HomeNumber);
                    if (bldr.ToString() != "") {
                        return false;
                    } else {
                        return true;
                    }
                }
            }
        }

        /// <summary>
        /// Prefecture～HomeNumberまでしか設定されていないときにTrue
        /// </summary>
        public bool IsStructureNameOnly {
            get {
                StringBuilder bldr = new StringBuilder();
                bldr.Append(this.Prefecture);
                bldr.Append(this.City);
                bldr.Append(this.Town);
                bldr.Append(this.HomeNumber);
                if (bldr.ToString() != "") {
                    return true;
                } else {
                    return false;
                }
            }
        }

        public Address() {
            this.TableId = "MML0002";
            this.CountryCode = "JPN";
            this.AddressClass = "current";
            this.RepCode = "I";
        }

        public Address(string zipno,string addrfulltext) {
            this.TableId = "MML0002";
            this.AddressClass = "current";
            this.CountryCode = "JPN";
            this.Zip = zipno;
            this.FullName = addrfulltext;
            this.RepCode = "I";
        }

        public Address(XmlNode node) {
            this.TableId = "MML0002";
            this.AddressClass = "current";
            this.CountryCode = "JPN";
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlAttribute attr;
            this.RepCode = node.Attributes["repCode", NameSpaceURI].Value;

            attr = node.Attributes["tableId", NameSpaceURI];
            if (attr != null) {
                this.TableId = attr.Value;
            }
            attr = node.Attributes["addressClass", NameSpaceURI];
            if (attr != null) {
                this.AddressClass = attr.Value;
            }

            foreach (XmlNode elm in node.ChildNodes) {
                if (elm.LocalName == "full") {
                    this.FullName = elm.InnerText.Trim();
                }
                if (elm.LocalName == "prefecture") {
                    this.Prefecture = elm.InnerText.Trim();
                }
                if (elm.LocalName == "city") {
                    this.City = elm.InnerText.Trim();
                }
                if (elm.LocalName == "town") {
                    this.Town = elm.InnerText.Trim();
                }
                if (elm.LocalName == "homeNumber") {
                    this.HomeNumber = elm.InnerText.Trim();
                }
                if (elm.LocalName == "zip") {
                    this.Zip = elm.InnerText.Trim();
                }
                if (elm.LocalName == "countryCode") {
                    this.CountryCode = elm.InnerText.Trim();
                }
                
            }
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "Address", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "repCode", NameSpaceURI);
            attr.Value = this.RepCode;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            if (!string.IsNullOrEmpty(this.AddressClass))
            {
                attr = doc.CreateAttribute(NameSpacePrefix, "addressClass", NameSpaceURI);
                attr.Value = this.AddressClass;
                node.Attributes.Append(attr);
            }

            XmlElement elm;
            if (this.IsFullNameOnly) {
                elm = doc.CreateElement(NameSpacePrefix, "full", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.FullName));
                node.AppendChild(elm);
            } else {
                elm = doc.CreateElement(NameSpacePrefix, "prefecture", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Prefecture));
                node.AppendChild(elm);
                elm = doc.CreateElement(NameSpacePrefix, "city", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.City));
                node.AppendChild(elm);
                elm = doc.CreateElement(NameSpacePrefix, "town", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Town));
                node.AppendChild(elm);
                elm = doc.CreateElement(NameSpacePrefix, "homeNumber", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.HomeNumber));
                node.AppendChild(elm);

            }

            if(!String.IsNullOrEmpty(this.Zip)){
                elm = doc.CreateElement(NameSpacePrefix, "zip", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Zip));
                node.AppendChild(elm);
            }

            if (!String.IsNullOrEmpty(this.CountryCode)) {
                elm = doc.CreateElement(NameSpacePrefix, "countryCode", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.CountryCode));
                node.AppendChild(elm);
            }

            return node;
        }

        public Address Clone() {
            Address addr = new Address();

            addr.RepCode = this.RepCode;
            addr.TableId = this.TableId;
            addr.AddressClass = this.AddressClass;
            addr.CountryCode = this.CountryCode;
            addr.Prefecture = this.Prefecture;
            addr.City = this.City;
            addr.Town = this.Town;
            addr.HomeNumber = this.HomeNumber;
            addr.Zip = this.Zip;
            addr.FullName = this.FullName;

            return addr;
        }

    }
}
