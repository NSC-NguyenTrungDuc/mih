using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlSc {
    public class Facility {
        private string _facilityCode;
        private string _tableId;
        private string _facilityId;
        private string _facilityIdType;
        private string _name;
        private string _type;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/MML/SharedComponent/Security/1.0"; }
        }

        public string NameSpacePrefix {
            get { return "mmlSc"; }
        }

        public string FacilityCode
        {
            get { return _facilityCode; }
            set { _facilityCode = value; }
        }

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string FacilityId
        {
            get { return _facilityId; }
            set { _facilityId = value; }
        }

        public string FacilityIdType
        {
            get { return _facilityIdType; }
            set { _facilityIdType = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Facility() {

        }

        public Facility(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            this.Name = node.InnerText.Trim();

            XmlAttribute attr;
            attr = node.Attributes["facilityCode",NameSpaceURI];
            this.FacilityCode = attr.Value;

            attr = node.Attributes["tableId", NameSpaceURI];
            if (attr != null) {
                this.TableId = attr.Value;
            }

            attr = node.Attributes["facilityId", NameSpaceURI];
            if (attr != null) {
                this.FacilityId = attr.Value;
            }

            attr = node.Attributes["facilityIdType", NameSpaceURI];
            if (attr != null) {
                this.FacilityIdType = attr.Value;
            }

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix,"facility",NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "facilityCode", NameSpaceURI);
            attr.Value = this.FacilityCode;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "facilityId", NameSpaceURI);
            attr.Value = this.FacilityId;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "facilityIdType", NameSpaceURI);
            attr.Value = this.FacilityIdType;
            node.Attributes.Append(attr);

            // 2015.11.03 Added
            if (!string.IsNullOrEmpty(this.Type))
            {
                attr = doc.CreateAttribute(NameSpacePrefix, "type", NameSpaceURI);
                attr.Value = this.Type;
                node.Attributes.Append(attr);
            }

            node.AppendChild(doc.CreateTextNode(this.Name));

            return node;
        }

    }
}
