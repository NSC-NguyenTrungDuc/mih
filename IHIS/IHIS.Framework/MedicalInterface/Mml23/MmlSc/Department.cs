using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.MmlSc {
    public class Department {
        private string _departmentCode;
        private string _tableId;
        private string _name;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/MML/SharedComponent/Security/1.0"; }
        }

        public string NameSpacePrefix {
            get { return "mmlSc"; }
        }

        public string DepartmentCode
        {
            get { return _departmentCode; }
            set { _departmentCode = value; }
        }

        public string TableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Department() {

        }

        public Department(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            this.Name = null;

            this.Name = node.InnerText.Trim();

            XmlAttribute attr;
            attr = node.Attributes["departmentCode", NameSpaceURI];
            this.DepartmentCode = attr.Value;

            attr = node.Attributes["tableId", NameSpaceURI];
            if (attr != null) {
                this.TableId = attr.Value;
            }

        }

        public XmlNode WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix,"department",NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "departmentCode", NameSpaceURI);
            attr.Value = this.DepartmentCode;
            node.Attributes.Append(attr);

            attr = doc.CreateAttribute(NameSpacePrefix, "tableId", NameSpaceURI);
            attr.Value = this.TableId;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Name));

            return node;
        }


    }
}
