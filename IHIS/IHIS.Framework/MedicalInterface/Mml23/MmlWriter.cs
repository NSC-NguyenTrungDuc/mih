using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace MedicalInterface.Mml23 {
    using System.IO;
    using System.Windows.Forms;

    class MmlWriter {

        private System.Xml.Schema.XmlSchemaSet MmlSchemaSet;

        

        public MmlWriter() {
            //string schemapath = System.Environment.CurrentDirectory + "\\MML23\\xsd";
            string schemapath = Application.StartupPath + "\\MML23\\xsd";
            MmlSchemaSet = new System.Xml.Schema.XmlSchemaSet();
            foreach (string xsdfile in System.IO.Directory.GetFiles(schemapath)) {
                MmlSchemaSet.Add(null, xsdfile);
            }
        }

        public void Write(Mml mml, string filename) {                     
            using (XmlWriter writer = XmlWriter.Create(filename)) {
                Write(mml, writer);          
            }
        }

        public string Write(Mml mml)
        {
            MemoryStream stream = new MemoryStream();
            //StringBuilder builder = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(stream))
            {
                Write(mml, writer);
            }
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public void Write(Mml mml, XmlWriter writer)
        {

            mml.SetSupplementData();

            XmlDocument doc = CreateXmlDocument();

            XmlDeclaration def = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(def);

            XmlElement mmlnode = doc.CreateElement("Mml");

            XmlAttribute attr = doc.CreateAttribute("version");
            attr.Value = mml.Version;
            mmlnode.Attributes.Append(attr);

            attr = doc.CreateAttribute("createDate");
            attr.Value = mml.CreateDate.ToString("yyyy/MM/dd Thh:mm:ss");
            mmlnode.Attributes.Append(attr);

            doc.AppendChild(mmlnode);

            doc = AddMmlXmlNamespaces(doc);

            mmlnode.AppendChild(mml.Header.WriteXml(doc));

            mmlnode.AppendChild(mml.Body.WriteXml(doc));

            doc.Validate(new ValidationEventHandler(ValidationEventHandler));

            if (writer != null) doc.Save(writer);
        }

        public XmlDocument CreateXmlDocument() {
            XmlDocument doc = new XmlDocument();
            doc.Schemas = this.MmlSchemaSet;
            
            return doc;
        }

        private XmlDocument AddMmlXmlNamespaces(XmlDocument doc) {
            XmlAttribute attr;

            attr = doc.CreateAttribute("xmlns:" + MmlCm.Id.NameSpacePrefix);
            attr.Value = MmlCm.Id.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlCi.CreatorInfo.NameSpacePrefix);
            attr.Value = MmlCi.CreatorInfo.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlCi.CreatorLicense.NameSpacePrefix);
            attr.Value = MmlCi.CreatorLicense.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlPsi.PersonalizedInfo.NameSpacePrefix);
            attr.Value = MmlPsi.PersonalizedInfo.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlCm.MailAddress.NameSpacePrefix);
            attr.Value = MmlCm.MailAddress.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlCm.ExternalReference.NameSpacePrefix);
            attr.Value = MmlCm.ExternalReference.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlAd.Address.NameSpacePrefix);
            attr.Value = MmlAd.Address.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlDp.Department.NameSpacePrefix);
            attr.Value = MmlDp.Department.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlFc.Facility.NameSpacePrefix);
            attr.Value = MmlFc.Facility.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlNm.Name.NameSpacePrefix);
            attr.Value = MmlNm.Name.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlPh.Phone.NameSpacePrefix);
            attr.Value = MmlPh.Phone.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlRd.RegisteredDiagnosisModule.NameSpacePrefix);
            attr.Value = MmlRd.RegisteredDiagnosisModule.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + Claim.ClaimModule.NameSpacePrefix);
            attr.Value = Claim.ClaimModule.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            attr = doc.CreateAttribute("xmlns:" + MmlHi.HealthInsurance.NameSpacePrefix);
            attr.Value = MmlHi.HealthInsurance.NameSpaceURI;
            doc.DocumentElement.Attributes.Append(attr);

            return doc;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e) {
            switch (e.Severity) {
                case XmlSeverityType.Error:
                    throw new ApplicationException("MMLの検証でエラー発生。" + e.Message,e.Exception);
                case XmlSeverityType.Warning:
                    throw new ApplicationException("MMLの検証で警告発生。" + e.Message, e.Exception);
                default:
                    break;
            }

        }

    }
}
