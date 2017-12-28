using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace IHIS.Framework.Mml23.MmlSm
{
    public class RelatedDoc
    {
        private string relation;
        private string text;

        public string Relation
        {
            get { return relation; }
            set { relation = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string NameSpaceURI
        {
            get { return SummaryModule.NameSpaceURI; }
        }

        public string NameSpacePrefix
        {
            get { return SummaryModule.NameSpacePrefix; }
        }

        public RelatedDoc()
        {
            this.relation = "detail";
        }

        public RelatedDoc(string relation, string text)
        {
            if (!string.IsNullOrEmpty(relation))
            {
                this.relation = relation;
            }
            else
            {
                this.relation = "detail";
            }

            this.text = text;
        }

        public RelatedDoc(XmlNode node)
        {
            this.LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            XmlNode subnode = node.SelectSingleNode("mmlSm:relatedDoc", nsmgr);

            this.Text = subnode != null ? subnode.InnerText : "";
            this.Relation = subnode != null ? subnode.Attributes["mmlSm:relation", SummaryModule.NameSpaceURI].Value : "";
        }

        public XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "relatedDoc", NameSpaceURI);
            XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "relation", NameSpaceURI);
            attr.Value = this.Relation;
            node.Attributes.Append(attr);
            node.AppendChild(doc.CreateTextNode(this.Text));

            return node;
        }
    }
}
