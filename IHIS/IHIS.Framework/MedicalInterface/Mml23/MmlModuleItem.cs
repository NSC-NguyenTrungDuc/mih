using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {
    using MedicalInterface.Mml23.MmlPc;
    using IHIS.Framework.Mml23.MmlRe;

    public class MmlModuleItem {
        private MmlDocumentInfo _docInfo;
        private MmlContent _content;

        public MmlDocumentInfo DocInfo
        {
            get { return _docInfo; }
            set { _docInfo = value; }
        }

        public MmlContent Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public MmlModuleItem() {
            this.DocInfo = new MmlDocumentInfo();
            this.Content = null;
        }

        public MmlModuleItem(XmlNode node) {
            LoadFromXml(node);
        }

        public void LoadFromXml(XmlNode node) {
            this.DocInfo = new MmlDocumentInfo(node.SelectSingleNode("docInfo"));
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);

            XmlNode content = node.SelectSingleNode("content");
            if (this.DocInfo.ContentModuleType == "patientInfo") {
                nsmgr.AddNamespace(MmlPi.PatientModule.NameSpacePrefix, MmlPi.PatientModule.NameSpaceURI);
                this.Content = new MmlPi.PatientModule(content.SelectSingleNode("mmlPi:PatientModule",nsmgr));
            } else if (this.DocInfo.ContentModuleType == "healthInsurance") {
                nsmgr.AddNamespace(MmlHi.HealthInsurance.NameSpacePrefix, MmlHi.HealthInsurance.NameSpaceURI);
                this.Content = new MmlHi.HealthInsurance(content.SelectSingleNode("mmlHi:HealthInsuranceModule", nsmgr));
            } else if (this.DocInfo.ContentModuleType == "registeredDiagnosis") {
                nsmgr.AddNamespace(MmlRd.RegisteredDiagnosisModule.NameSpacePrefix, MmlRd.RegisteredDiagnosisModule.NameSpaceURI);
                this.Content = new MmlRd.RegisteredDiagnosisModule(content.SelectSingleNode("mmlRd:RegisteredDiagnosisModule", nsmgr));
            } else if (this.DocInfo.ContentModuleType == "lifestyle") {
            } else if (this.DocInfo.ContentModuleType == "baseClinic") {
            } else if (this.DocInfo.ContentModuleType == "firstClinic") {
            } else if (this.DocInfo.ContentModuleType == "progressCourse") {
                nsmgr.AddNamespace(MmlPc.ProgressCourseModule.NameSpacePrefix, MmlPc.ProgressCourseModule.NameSpaceURI);
                this.Content = new ProgressCourseModule(content.SelectSingleNode("mmlPc:ProgressCourseModule", nsmgr));
            } else if (this.DocInfo.ContentModuleType == "surgery") {
            } else if (this.DocInfo.ContentModuleType == "summary") {
            } else if (this.DocInfo.ContentModuleType == "claim") {
                nsmgr.AddNamespace(Claim.ClaimModule.NameSpacePrefix, Claim.ClaimModule.NameSpaceURI);
                this.Content = new Claim.ClaimModule(content.SelectSingleNode("claim:ClaimModule", nsmgr));
            } else if (this.DocInfo.ContentModuleType == "claimAmount") {
            } else if (this.DocInfo.ContentModuleType == "referral") {
                nsmgr.AddNamespace(ReferralModule.NameSpacePrefix, ReferralModule.NameSpaceURI);
                this.Content = new ReferralModule(content.SelectSingleNode("mmlRe:ReferralModule", nsmgr));
            } else if (this.DocInfo.ContentModuleType == "test") {
            } else if (this.DocInfo.ContentModuleType == "report") {
            } else {
                throw new XmlException("ContentModuleTypeが対象外です。:" + this.DocInfo.ContentModuleType);
            }
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement("MmlModuleItem");

            node.AppendChild(this.DocInfo.WriteXml(doc));

            XmlElement subnode = doc.CreateElement("content");
            subnode.AppendChild(this.Content.WriteXml(doc));
            node.AppendChild(subnode);

            return node;
        }

    }

}
