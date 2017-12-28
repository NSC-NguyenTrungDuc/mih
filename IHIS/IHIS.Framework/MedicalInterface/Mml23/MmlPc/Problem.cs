namespace MedicalInterface.Mml23.MmlPc
{
    using System;
    using System.Xml;

    public class Problem
    {
        private string _dxUid;
        private string _text;

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

        public String DxUid
        {
            get { return _dxUid; }
            set { _dxUid = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Problem() {

        }

        public Problem(XmlNode node)
        {
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            this.DxUid = node.Attributes["dxUid", NameSpaceURI].Value;
            this.Text = node.InnerText.Trim();
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlAttribute attr;

            XmlElement node = doc.CreateElement(NameSpacePrefix, "problem", NameSpaceURI);

            attr = doc.CreateAttribute(NameSpacePrefix, "dxUid", NameSpaceURI);
            attr.Value = this.DxUid;
            node.Attributes.Append(attr);

            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }
    }
}