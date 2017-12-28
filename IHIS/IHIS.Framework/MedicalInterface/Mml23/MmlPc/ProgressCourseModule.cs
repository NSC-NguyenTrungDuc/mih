namespace MedicalInterface.Mml23.MmlPc
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using MedicalInterface.Mml23.MmlCm;

    public class ProgressCourseModule : Mml23.MmlContent 
    {
        private List<ExternalReference> _freeExpression;
        private List<ProblemItem> _structuredExpression;
        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/ProgressCourse/1.0";

        public const string NameSpacePrefix = "mmlPc";

        public List<ExternalReference> FreeExpression
        {
            get { return _freeExpression; }
            set { _freeExpression = value; }
        }

        public List<ProblemItem> StructuredExpression
        {
            get { return _structuredExpression; }
            set { _structuredExpression = value; }
        }

        public ProgressCourseModule() {
            this.FreeExpression = new List<ExternalReference>();
            this.StructuredExpression = new List<ProblemItem>();
        }

        public ProgressCourseModule(XmlNode node)
        {
            this.FreeExpression = new List<ExternalReference>();
            this.StructuredExpression = new List<ProblemItem>();
            LoadFromXml(node);
        }

        public override void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            XmlNode tmpnode;
            tmpnode = node.SelectSingleNode("mmlPc:structuredExpression", nsmgr);
            if (tmpnode != null) {
                foreach (XmlNode er in tmpnode.ChildNodes)
                {
                    if (er.LocalName.Equals("problemItem"))
                    this.StructuredExpression.Add(new ProblemItem(er));
                }
            }

            tmpnode = node.SelectSingleNode("mmlPc:FreeExpression", nsmgr);
            if (tmpnode != null)
            {
                foreach (XmlNode er in tmpnode.ChildNodes)
                {
                    if (er.LocalName.Equals("extRef"))
                    this.FreeExpression.Add(new MmlCm.ExternalReference(er));
                }
            }          
        }

        public override XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "ProgressCourseModule", NameSpaceURI);
            XmlElement elm;

            if (this.FreeExpression.Count > 0)
            {
                elm = doc.CreateElement(NameSpacePrefix, "FreeExpression", NameSpaceURI);
                foreach (MmlCm.ExternalReference itm in this.FreeExpression)
                {
                    elm.AppendChild(itm.WriteXml(doc));
                }
                node.AppendChild(elm);
            }
            if (this.StructuredExpression.Count > 0)
            {
                elm = doc.CreateElement(NameSpacePrefix, "structuredExpression", NameSpaceURI);
                foreach (ProblemItem itm in this.StructuredExpression)
                {
                    elm.AppendChild(itm.WriteXml(doc));
                }
                node.AppendChild(elm);
            }            

            return node;
        }
    }
}