namespace MedicalInterface.Mml23.MmlPc
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ProblemItem
    {
        private Problem _problem;
        private List<MiTuple<string, int>> _assessment;
        private Objective _objective;
        private Subjective _subjective;
        private Plan _plan;        

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

        public Problem Problem
        {
            get { return _problem; }
            set { _problem = value; }
        }

        public List<MiTuple<string, int>> Assessment
        {
            get { return _assessment; }
            set { _assessment = value; }
        }

        public Objective Objective
        {
            get { return _objective; }
            set { _objective = value; }
        }

        public Subjective Subjective
        {
            get { return _subjective; }
            set { _subjective = value; }
        }

        public Plan Plan
        {
            get { return _plan; }
            set { _plan = value; }
        }

        public ProblemItem()
        {
            this.Assessment = new List<MiTuple<string, int>>();
        }

        public ProblemItem(XmlNode node)
        {
            this.Assessment = new List<MiTuple<string, int>>();
            LoadFromXml(node);
        }


        public void LoadFromXml(XmlNode node)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);

            foreach (XmlNode elm in node.ChildNodes)
            {
                if (elm.LocalName == "assessment")
                {
                    foreach (XmlNode cn in elm.ChildNodes)
                    {
                        if (cn.LocalName.Equals("assessmentItem"))
                        {
                            int permission;
                            bool ok = int.TryParse(cn.Attributes["permission", NameSpaceURI] != null ? cn.Attributes["permission", NameSpaceURI].Value : "15", out permission);
                            permission = ok ? permission : 15;

                            this.Assessment.Add(new MiTuple<string, int>(cn.InnerText, permission));
                        }
                    }
                }

                if (elm.LocalName == "problem")
                {
                    this.Problem = new Problem(elm);
                }

                if (elm.LocalName == "subjective")
                {
                    this.Subjective = new Subjective(elm);
                }

                if (elm.LocalName == "objective")
                {
                    this.Objective = new Objective(elm);
                }

                if (elm.LocalName == "plan")
                {
                    this.Plan = new Plan(elm);
                }
            }
        }

        public XmlNode WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "problemItem", NameSpaceURI);

            XmlElement elm;

            if (Assessment.Count > 0)
            {
                elm = doc.CreateElement(NameSpacePrefix, "assessment", NameSpaceURI);
                foreach (MiTuple<string, int> ai in Assessment)
                {
                    XmlElement elmChild = doc.CreateElement(NameSpacePrefix, "assessmentItem", NameSpaceURI);
                    elmChild.AppendChild(doc.CreateTextNode(ai.V1));
                    elm.AppendChild(elmChild);

                    XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "permission", NameSpaceURI);
                    attr.Value = ai.V2.ToString();
                    elmChild.Attributes.Append(attr);
                }
                node.AppendChild(elm);
            }

            if (Problem != null)
            {
                node.AppendChild(Problem.WriteXml(doc));
            }

            if (Subjective != null)
            {
                node.AppendChild(Subjective.WriteXml(doc));
            }

            if (Objective != null)
            {
                node.AppendChild(Objective.WriteXml(doc));
            }

            if (Plan != null)
            {
                node.AppendChild(Plan.WriteXml(doc));
            }

            return node;
        }
    }
}