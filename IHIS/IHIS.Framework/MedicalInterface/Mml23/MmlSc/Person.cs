using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlSc {
    public class Person {
        private string _personCode;
        private string _tableId;
        private string _personId;
        private string _personIdType;
        private string _name;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/MML/SharedComponent/Security/1.0"; }
        }

        public string NameSpacePrefix {
            get { return "mmlSc"; }
        }

        public string PersonCode
        {
            get { return _personCode; }
            set { _personCode = value; }
        }

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string PersonId
        {
            get { return _personId; }
            set { _personId = value; }
        }

        public string PersonIdType
        {
            get { return _personIdType; }
            set { _personIdType = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public Person() {

        }

        public Person(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            this.Name = node.InnerText.Trim();

            XmlAttribute attr;
            attr = node.Attributes["personCode", NameSpaceURI];
            this.PersonCode = attr.Value;

            attr = node.Attributes["tableId", NameSpaceURI];
            if (attr != null) {
                this.TableId = attr.Value;
            }

            attr = node.Attributes["personId", NameSpaceURI];
            if (attr != null) {
                this.PersonId = attr.Value;
            }

            attr = node.Attributes["personIdType", NameSpaceURI];
            if (attr != null) {
                this.PersonIdType = attr.Value;
            }

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "person", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "personCode", NameSpaceURI);
            attr.Value = this.PersonCode;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "personId", NameSpaceURI);
            attr.Value = this.PersonId;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "personIdType", NameSpaceURI);
            attr.Value = this.PersonIdType;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Name));

            return node;
        }

    }
}
