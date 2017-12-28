using System;
using System.Collections.Generic;
using System.Text;
using MedicalInterface.Mml23;
using MedicalInterface.Mml23.MmlPi;
using MedicalInterface.Mml23.MmlCm;
using IHIS.Framework.Mml23.MmlSm;
using System.Xml;

namespace IHIS.Framework.Mml23.MmlRe
{
    public class ReferralModule : MmlContent
    {
        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/Referral/1.0";
        public const string NameSpacePrefix = "mmlRe";

        private string occupation;
        private string title;
        private string greeting;
        private string chiefComplaints;
        private string clinicalDiagnosis;
        private string referPurpose;
        private string referToUnknownName;
        private PatientModule patient;
        private ReferFrom referFrom;
        private PastHistory pastHistory;
        private FamilyHistory familyHistory;
        private PresentIllness presentIllness;
        private TestResults testResults;
        private ClinicalCourse clinicalCourse;
        private Medication medication;
        private Remarks remarks;
        private ReferToFacility referToFacility;
        private ReferToPerson referToPerson;

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Greeting
        {
            get { return greeting; }
            set { greeting = value; }
        }

        public string ChiefComplaints
        {
            get { return chiefComplaints; }
            set { chiefComplaints = value; }
        }

        public string ClinicalDiagnosis
        {
            get { return clinicalDiagnosis; }
            set { clinicalDiagnosis = value; }
        }

        public string ReferPurpose
        {
            get { return referPurpose; }
            set { referPurpose = value; }
        }

        public string ReferToUnknownName
        {
            get { return referToUnknownName; }
            set { referToUnknownName = value; }
        }

        public PatientModule Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public ReferFrom ReferFrom
        {
            get { return referFrom; }
            set { referFrom = value; }
        }

        public PastHistory PastHistory
        {
            get { return pastHistory; }
            set { pastHistory = value; }
        }

        public FamilyHistory FamilyHistory
        {
            get { return familyHistory; }
            set { familyHistory = value; }
        }

        public PresentIllness PresentIllness
        {
            get { return presentIllness; }
            set { presentIllness = value; }
        }

        public TestResults TestResults
        {
            get { return testResults; }
            set { testResults = value; }
        }

        public ClinicalCourse ClinicalCourse
        {
            get { return clinicalCourse; }
            set { clinicalCourse = value; }
        }

        public Medication Medication
        {
            get { return medication; }
            set { medication = value; }
        }

        public Remarks Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public ReferToFacility ReferToFacility
        {
            get { return referToFacility; }
            set { referToFacility = value; }
        }

        public ReferToPerson ReferToPerson
        {
            get { return referToPerson; }
            set { referToPerson = value; }
        }

        public ReferralModule()
        {
            // Required elements
            this.Patient = new PatientModule();
            this.ReferFrom = new ReferFrom();
            this.Title = "";
            this.ChiefComplaints = "";
            this.PresentIllness = new PresentIllness();
            this.ReferPurpose = "";
            this.ReferToFacility = new ReferToFacility();
        }

        public ReferralModule(XmlNode node)
        {
            // Required elements
            this.Patient = new PatientModule();
            this.ReferFrom = new ReferFrom();
            this.Title = "";
            this.ChiefComplaints = "";
            this.PresentIllness = new PresentIllness();
            this.ReferPurpose = "";
            this.ReferToFacility = new ReferToFacility();
            this.LoadFromXml(node);
        }

        public override void LoadFromXml(XmlNode node)
        {
            //base.LoadFromXml(node);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            nsmgr.AddNamespace(MedicalInterface.Mml23.MmlPi.PatientModule.NameSpacePrefix, MedicalInterface.Mml23.MmlPi.PatientModule.NameSpaceURI);
            nsmgr.AddNamespace(SummaryModule.NameSpacePrefix, SummaryModule.NameSpaceURI);

            XmlNode refNode;
            XmlNode subNode;
            //refNode = node.SelectSingleNode("mmlRe:ReferralModule", nsmgr);
            refNode = node;

            if (refNode != null)
            {
                subNode = node.SelectSingleNode("mmlPi:PatientModule", nsmgr);
                if (subNode != null) this.Patient = new PatientModule(subNode);

                subNode = node.SelectSingleNode("mmlRe:occupation", nsmgr);
                this.Occupation = (subNode != null) ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("mmlRe:referFrom", nsmgr);
                if (subNode != null) this.ReferFrom = new ReferFrom(subNode);

                subNode = node.SelectSingleNode("mmlRe:title", nsmgr);
                this.Title = subNode != null ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("mmlRe:greeting", nsmgr);
                this.Greeting = subNode != null ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("mmlRe:chiefComplaints", nsmgr);
                this.ChiefComplaints = subNode != null ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("mmlRe:clinicalDiagnosis", nsmgr);
                this.ClinicalDiagnosis = subNode != null ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("mmlRe:pastHistory", nsmgr);
                this.PastHistory = subNode != null ? new PastHistory(subNode) : new PastHistory();

                subNode = node.SelectSingleNode("mmlRe:familyHistory", nsmgr);
                this.FamilyHistory = subNode != null ? new FamilyHistory(subNode) : new FamilyHistory();

                subNode = node.SelectSingleNode("mmlRe:presentIllness", nsmgr);
                this.PresentIllness = subNode != null ? new PresentIllness(subNode) : new PresentIllness();

                subNode = node.SelectSingleNode("mmlRe:testResults", nsmgr);
                this.TestResults = subNode != null ? new TestResults(subNode) : new TestResults();

                subNode = node.SelectSingleNode("mmlSm:clinicalCourse", nsmgr);
                this.ClinicalCourse = subNode != null ? new ClinicalCourse(subNode) : new ClinicalCourse();

                subNode = node.SelectSingleNode("mmlRe:medication", nsmgr);
                this.Medication = subNode != null ? new Medication(subNode) : new Medication();

                subNode = node.SelectSingleNode("mmlRe:referPurpose", nsmgr);
                this.ReferPurpose = subNode != null ? subNode.InnerText : "";

                subNode = node.SelectSingleNode("mmlRe:remarks", nsmgr);
                this.Remarks = subNode != null ? new Remarks(subNode) : new Remarks();

                subNode = node.SelectSingleNode("mmlRe:referToFacility", nsmgr);
                this.ReferToFacility = subNode != null ? new ReferToFacility(subNode) : new ReferToFacility();

                subNode = node.SelectSingleNode("mmlRe:referToPerson", nsmgr);
                this.ReferToPerson = subNode != null ? new ReferToPerson(subNode) : new ReferToPerson();

                subNode = node.SelectSingleNode("mmlRe:referToUnknownName", nsmgr);
                this.ReferToUnknownName = subNode != null ? subNode.InnerText : "";
            }
        }

        public override XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "ReferralModule", NameSpaceURI);
            XmlElement elm;
            node.AppendChild(this.Patient.WriteXml(doc));

            if (!string.IsNullOrEmpty(this.Occupation))
            {
                elm = doc.CreateElement(NameSpacePrefix, "occupation", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Occupation));
                node.AppendChild(elm);
            }

            node.AppendChild(this.ReferFrom.WriteXml(doc));

            elm = doc.CreateElement(NameSpacePrefix, "title", NameSpaceURI);
            elm.AppendChild(doc.CreateTextNode(this.Title));
            node.AppendChild(elm);

            if (!string.IsNullOrEmpty(this.Greeting))
            {
                elm = doc.CreateElement(NameSpacePrefix, "greeting", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.Greeting));
                node.AppendChild(elm);
            }

            elm = doc.CreateElement(NameSpacePrefix, "chiefComplaints", NameSpaceURI);
            elm.AppendChild(doc.CreateTextNode(this.ChiefComplaints));
            node.AppendChild(elm);

            if (!string.IsNullOrEmpty(this.ClinicalDiagnosis))
            {
                elm = doc.CreateElement(NameSpacePrefix, "clinicalDiagnosis", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.ClinicalDiagnosis));
                node.AppendChild(elm);
            }

            if (this.PastHistory != null)
            {
                node.AppendChild(this.PastHistory.WriteXml(doc));
            }

            if (this.FamilyHistory != null)
            {
                node.AppendChild(this.FamilyHistory.WriteXml(doc));
            }

            if (this.PresentIllness != null)
            {
                node.AppendChild(this.PresentIllness.WriteXml(doc));
            }

            if (this.TestResults != null)
            {
                node.AppendChild(this.TestResults.WriteXml(doc));
            }

            if (this.ClinicalCourse != null)
            {
                node.AppendChild(this.ClinicalCourse.WriteXml(doc));
            }

            if (this.Medication != null)
            {
                node.AppendChild(this.Medication.WriteXml(doc));
            }

            elm = doc.CreateElement(NameSpacePrefix, "referPurpose", NameSpaceURI);
            elm.AppendChild(doc.CreateTextNode(this.ReferPurpose));
            node.AppendChild(elm);

            if (this.Remarks != null)
            {
                node.AppendChild(this.Remarks.WriteXml(doc));
            }

            node.AppendChild(this.ReferToFacility.WriteXml(doc));

            if (this.ReferToPerson != null)
            {
                node.AppendChild(this.ReferToPerson.WriteXml(doc));
            }

            if (!string.IsNullOrEmpty(this.ReferToUnknownName))
            {
                elm = doc.CreateElement(NameSpacePrefix, "referToUnknownName", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(this.ReferToUnknownName));
                node.AppendChild(elm);
            }

            return node;
        }
    }
}
