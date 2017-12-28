using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlNm {
    public class Name {
        private string _repCode;
        private string _tableId;
        private string _familyName;
        private string _givenName;
        private string _middleName;
        private string _prefix;
        private string _degree;
        private string _fullName;

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/Name/1.0";

        public const string NameSpacePrefix = "mmlNm";

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

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

        public string FamilyName
        {
            get { return _familyName; }
            set { _familyName = value; }
        }

        public string GivenName
        {
            get { return _givenName; }
            set { _givenName = value; }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        public string Prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }

        public string Degree
        {
            get { return _degree; }
            set { _degree = value; }
        }


        public Name() {
            this.RepCode = "I";
            this.TableId = "MML0025";
        }

        public Name(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.RepCode = node.Attributes["repCode", NameSpaceURI].Value;
            this.TableId = node.Attributes["tableId", NameSpaceURI].Value;

            foreach (XmlNode elm in node.ChildNodes) {
                if (elm.LocalName == "fullname") {
                    string name = elm.InnerText.Trim();
                    string[] names = null;
                    if (this.RepCode == "A") {
                        names = name.Split(Char.Parse(" "));
                    } else {
                        names = name.Split(Char.Parse("　"));
                    }
                    if (names.Length == 2) {
                        this.FamilyName = names[0];
                        this.GivenName = names[1];
                        this.MiddleName = "";
                    } else if (names.Length == 3) {
                        this.FamilyName = names[0];
                        this.GivenName = names[1];
                        this.MiddleName = names[2];
                    } else {
                        this.FamilyName = name;
                        this.GivenName = "";
                        this.MiddleName = "";
                    }
                }
                if (elm.LocalName == "family") {
                    this.FamilyName = elm.InnerText.Trim();
                }
                if (elm.LocalName == "given") {
                    this.GivenName = elm.InnerText.Trim();
                }
                if (elm.LocalName == "middle") {
                    this.MiddleName = elm.InnerText.Trim();
                }
                if (elm.LocalName == "prefix") {
                    this.Prefix=elm.InnerText.Trim();
                }
                if (elm.LocalName == "degree") {
                    this.Degree=elm.InnerText.Trim();
                }
            }

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "Name", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "repCode", NameSpaceURI);
            attr.Value = this.RepCode;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            XmlElement elm;

            if (!string.IsNullOrEmpty(this.FamilyName))
            {
                elm = doc.CreateElement(NameSpacePrefix, "family", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.FamilyName));
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.GivenName))
            {
                elm = doc.CreateElement(NameSpacePrefix, "given", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.GivenName));
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(this.FullName))
            {
                elm = doc.CreateElement(NameSpacePrefix, "fullname", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.FullName));
                node.AppendChild(elm);
            }

            if (!String.IsNullOrEmpty(this.MiddleName)) {
                elm = doc.CreateElement(NameSpacePrefix, "middle", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.MiddleName));
                node.AppendChild(elm);
            }

            if (!String.IsNullOrEmpty(this.Prefix)) {
                elm = doc.CreateElement(NameSpacePrefix, "prefix", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Prefix));
                node.AppendChild(elm);
            }

            if (!String.IsNullOrEmpty(this.Degree)) {
                elm = doc.CreateElement(NameSpacePrefix, "degree", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Degree));
                node.AppendChild(elm);
            }

            return node;
        }

        public Name Clone() {
            Name nm = new Name();

            nm.FamilyName = this.FamilyName;
            nm.GivenName = this.GivenName;
            nm.MiddleName = this.MiddleName;
            nm.Prefix = this.Prefix;
            nm.RepCode = this.RepCode;
            nm.TableId = this.TableId;
            nm.Degree = this.Degree;

            return nm;
        }
    }
}
