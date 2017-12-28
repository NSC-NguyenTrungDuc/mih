using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlCm {
    public class ExternalReference {
        private string _contentType;
        private string _medicalRole;
        private string _title;
        private string _reference;

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/Common/1.0";

        public const string NameSpacePrefix = "mmlCm";

        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        public string MedicalRole
        {
            get { return _medicalRole; }
            set { _medicalRole = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Reference
        {
            get { return _reference; }
            set { _reference = value; }
        }

        public ExternalReference() {

        }

        public ExternalReference(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlAttribute attr;


            attr = node.Attributes["contentType", NameSpaceURI];
            if (attr != null) {
                this.ContentType = attr.Value;
            }
            attr = node.Attributes["medicalRole", NameSpaceURI];
            if (attr != null) {
                this.MedicalRole = attr.Value;
            }
            attr = node.Attributes["title", NameSpaceURI];
            if (attr != null) {
                this.Title = attr.Value;
            }
            attr = node.Attributes["href", NameSpaceURI];
            if (attr != null) {
                this.Reference = attr.Value;
            }

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "extRef", NameSpaceURI);

            if (!String.IsNullOrEmpty(this.ContentType)) {
                node.Attributes.Append(CreateAttribute(doc, "contentType", this.ContentType));
            }
            if (!String.IsNullOrEmpty(this.MedicalRole)) {
                node.Attributes.Append(CreateAttribute(doc, "medicalRole", this.MedicalRole));
            }
            if (!String.IsNullOrEmpty(this.Title)) {
                node.Attributes.Append(CreateAttribute(doc, "title", this.Title));
            }
            node.Attributes.Append(CreateAttribute(doc, "href", this.Reference));

            return node;
        }

        private XmlAttribute CreateAttribute(XmlDocument doc, string name, string value) {
            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, name, NameSpaceURI);
            attr.Value = value;
            return attr;
        }

    }
}
