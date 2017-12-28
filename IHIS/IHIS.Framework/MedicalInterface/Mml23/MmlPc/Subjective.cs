namespace MedicalInterface.Mml23.MmlPc
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class Subjective
    {
        private string _freeNotes;
        private List<SubjectiveItem> _items;

        public string NameSpaceURI
        {
            get
            {
                return ProgressCourseModule.NameSpaceURI;
            }
        }

        public string NameSpacePrefix
        {
            get
            {
                return ProgressCourseModule.NameSpacePrefix;
            }
        }

        public String FreeNotes
        {
            get { return _freeNotes; }
            set { _freeNotes = value; }
        }

        public List<SubjectiveItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public Subjective()
        {
            this.Items = new List<SubjectiveItem>();
        }

        public Subjective(XmlNode node)
        {
            this.Items = new List<SubjectiveItem>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node)
        {
            foreach (XmlNode elm in node.ChildNodes)
            {
                if (elm.LocalName == "freeNotes")
                {
                    this.FreeNotes = elm.InnerText;
                }

                if (elm.LocalName == "subjectiveItem")
                {
                    this.Items.Add(new SubjectiveItem(elm));
                }
            }
        }

        public XmlNode WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "subjective", NameSpaceURI);

            XmlElement elm;

            if (!string.IsNullOrEmpty(FreeNotes))
            {
                elm = doc.CreateElement(NameSpacePrefix, "freeNotes", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.FreeNotes));
                node.AppendChild(elm);
            }

            foreach (SubjectiveItem itm in this.Items)
            {
                node.AppendChild(itm.WriteXml(doc));
            }
            return node;
        }
    }
}