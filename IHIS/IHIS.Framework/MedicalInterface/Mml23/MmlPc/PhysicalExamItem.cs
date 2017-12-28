namespace MedicalInterface.Mml23.MmlPc
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using MedicalInterface.Mml23.MmlCm;

    public class PhysicalExamItem
    {
        private string _title;
        private string _result;
        private string _interpretation;
        private List<ExternalReference> _referenceInfos;

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

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public String Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public String Interpretation
        {
            get { return _interpretation; }
            set { _interpretation = value; }
        }

        public List<ExternalReference> ReferenceInfos
        {
            get { return _referenceInfos; }
            set { _referenceInfos = value; }
        }

        public PhysicalExamItem()
        {
            this.ReferenceInfos = new List<ExternalReference>();
        }

        public PhysicalExamItem(XmlNode node)
        {
            this.ReferenceInfos = new List<ExternalReference>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node)
        {
            foreach (XmlNode elm in node.ChildNodes)
            {
                if (elm.LocalName == "title")
                {
                    this.Title = elm.InnerText;
                }

                if (elm.LocalName == "result")
                {
                    this.Result = elm.InnerText;
                }

                if (elm.LocalName == "interpretation")
                {
                    this.Interpretation = elm.InnerText;
                }
                if (elm.LocalName == "referenceInfo")
                {
                    foreach (XmlNode er in elm.SelectNodes("extRef"))
                    {
                        this.ReferenceInfos.Add(new MmlCm.ExternalReference(er));
                    }
                }                
            }
        }

        public XmlNode WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "physicalExamItem", NameSpaceURI);

            XmlElement elm;

            if (!string.IsNullOrEmpty(Title))
            {
                elm = doc.CreateElement(NameSpacePrefix, "title", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Title));
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(Result))
            {
                elm = doc.CreateElement(NameSpacePrefix, "result", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Result));
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(Interpretation))
            {
                elm = doc.CreateElement(NameSpacePrefix, "interpretation", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Interpretation));
                node.AppendChild(elm);
            }

            if (ReferenceInfos.Count > 0)
            {
                elm = doc.CreateElement(NameSpacePrefix, "referenceInfo", NameSpaceURI);
                foreach (MmlCm.ExternalReference itm in this.ReferenceInfos)
                {
                    elm.AppendChild(itm.WriteXml(doc));
                }
                node.AppendChild(elm);
            }

            return node;
        }
    }
}