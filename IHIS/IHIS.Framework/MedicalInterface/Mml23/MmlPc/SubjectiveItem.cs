namespace MedicalInterface.Mml23.MmlPc
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class SubjectiveItem
    {
        private string _timeExpression;
        private List<string> _eventExpression;
        private int _permission;

        public string NameSpaceURI
        {
            get
            {
                return ProgressCourseModule.NameSpaceURI;
            }
        }

        public int Permission
        {
            get { return _permission; }
            set { _permission = value; }
        }

        public string NameSpacePrefix
        {
            get
            {
                return ProgressCourseModule.NameSpacePrefix;
            }
        }

        public String TimeExpression
        {
            get { return _timeExpression; }
            set { _timeExpression = value; }
        }

        public List<String> EventExpression
        {
            get { return _eventExpression; }
            set { _eventExpression = value; }
        }

        public SubjectiveItem()
        {
            this.EventExpression = new List<string>();
        }

        public SubjectiveItem(XmlNode node)
        {
            this.EventExpression = new List<string>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node)
        {
            this.EventExpression = new List<string>();
            bool ok = int.TryParse(
                node.Attributes["permission", NameSpaceURI] != null ? node.Attributes["permission", NameSpaceURI].Value : "15",
                out this._permission);
            this._permission = ok ? _permission : 15;
            foreach (XmlNode elm in node.ChildNodes)
            {
                if (elm.LocalName == "timeExpression")
                {
                    this.TimeExpression = elm.InnerText;
                }

                if (elm.LocalName == "eventExpression")
                {
                    this.EventExpression.Add(elm.InnerText);
                }
            }
        }

        public XmlNode WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "subjectiveItem", NameSpaceURI);

            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "permission", NameSpaceURI);
            attr.Value = this._permission.ToString();
            node.Attributes.Append(attr);

            XmlElement elm;

            if (!string.IsNullOrEmpty(TimeExpression))
            {
                elm = doc.CreateElement(NameSpacePrefix, "timeExpression", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.TimeExpression));
                node.AppendChild(elm);
            }
            
            foreach (String itm in this.EventExpression)
            {
                elm = doc.CreateElement(NameSpacePrefix, "eventExpression", NameSpaceURI);                

                elm.AppendChild(doc.CreateTextNode(itm));
                node.AppendChild(elm);
            }
            return node;
        }
    }
}