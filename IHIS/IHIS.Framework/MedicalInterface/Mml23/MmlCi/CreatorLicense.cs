using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlCi {
    public class CreatorLicense {
        private string _tableId;
        private string _text;

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0";

        public const string NameSpacePrefix = "mmlCi";

        public String TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public CreatorLicense() {
            this.TableId = "MML0026";
        }

        public CreatorLicense(string license) {
            this.TableId = "MML0026";
            this.Text = license;
        }

        public CreatorLicense(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.TableId = node.Attributes["tableId", NameSpaceURI].Value;
            this.Text = node.InnerText.Trim();

        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "creatorLicense", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }

        public CreatorLicense Clone() {
            CreatorLicense cl = new CreatorLicense();

            cl.TableId = this.TableId;
            cl.Text = this.Text;

            return cl;
        }

    }
}
