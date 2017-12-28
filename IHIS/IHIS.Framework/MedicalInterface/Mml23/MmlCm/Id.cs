using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlCm {

    public class Id {
        private string _idType;
        private string _tableId;
        private string _text;

        public const string NameSpaceURI="http://www.medxml.net/MML/SharedComponent/Common/1.0";

        public const string NameSpacePrefix = "mmlCm";

        public String IdType
        {
            get { return _idType; }
            set { _idType = value; }
        }

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


        public Id() {

        }

        public Id(XmlNode node) {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            this.IdType = node.Attributes["type", NameSpaceURI].Value;
            this.TableId = node.Attributes["tableId", NameSpaceURI].Value;
            this.Text = node.InnerText.Trim();
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlAttribute attr;

            XmlElement node = doc.CreateElement(NameSpacePrefix, "Id", NameSpaceURI);

            attr = doc.CreateAttribute(NameSpacePrefix, "type", NameSpaceURI);
            attr.Value = this.IdType;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }

        public Id Clone() {
            Id cid =new Id();

            cid.IdType = this.IdType;
            cid.TableId = this.TableId;
            cid.Text = this.Text;

            return cid;
        }

    }
}
