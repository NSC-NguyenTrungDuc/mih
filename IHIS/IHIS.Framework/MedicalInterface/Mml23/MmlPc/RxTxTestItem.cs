namespace MedicalInterface.Mml23.MmlPc
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using MedicalInterface.Mml23.MmlCm;

    public class RxTxTestItem
    {
        private string _text;
        private List<ExternalReference> _references;

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

        public String Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public List<ExternalReference> References
        {
            get { return _references; }
            set { _references = value; }
        }

        public RxTxTestItem()
        {
            References = new List<ExternalReference>();
        }

        public RxTxTestItem(XmlNode node)
        {
            References = new List<ExternalReference>();
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            this.Text = node.InnerText;
            this.References = new List<ExternalReference>();
            foreach (XmlNode elm in node.ChildNodes)
            {
                if (elm.LocalName.Equals("extRef"))
                {
                    this.References.Add(new MmlCm.ExternalReference(elm));
                }                
            }
        }

        public XmlElement WriteXml(XmlDocument doc, string localName)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, localName, NameSpaceURI);

            node.AppendChild(doc.CreateTextNode(this.Text));
            //XmlElement elm;

            foreach (MmlCm.ExternalReference itm in this.References)
            {
                node.AppendChild(itm.WriteXml(doc));
            }

            return node;
        }
    }
}