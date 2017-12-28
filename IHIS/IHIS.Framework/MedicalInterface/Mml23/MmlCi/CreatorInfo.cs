using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using MedicalInterface.Mml23.MmlPsi;

namespace MedicalInterface.Mml23.MmlCi {
    public class CreatorInfo {
        private PersonalizedInfo _parson;
        private List<CreatorLicense> _licenseList;

        public const string NameSpaceURI ="http://www.medxml.net/MML/SharedComponent/CreatorInfo/1.0";

        public const string NameSpacePrefix = "mmlCi";

        public MmlPsi.PersonalizedInfo Parson
        {
            get { return _parson; }
            set { _parson = value; }
        }

        public List<CreatorLicense> LicenseList
        {
            get { return _licenseList; }
            set { _licenseList = value; }
        }

        public CreatorInfo() {
            this.Parson = new MmlPsi.PersonalizedInfo();
            this.LicenseList = new List<CreatorLicense>();
        }

        public CreatorInfo(XmlNode node) {
            this.LicenseList = new List<CreatorLicense>();
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            foreach (XmlNode elm in node.ChildNodes){
                if (elm.LocalName == "PersonalizedInfo") {
                    this.Parson = new MmlPsi.PersonalizedInfo(elm);
                }
                if (elm.LocalName == "creatorLicense") {
                    this.LicenseList.Add(new CreatorLicense(elm));
                }
            }
            
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "CreatorInfo", NameSpaceURI);

            node.AppendChild(this.Parson.WriteXml(doc));

            foreach (CreatorLicense itm in this.LicenseList) {
                node.AppendChild(itm.WriteXml(doc));
            }

            return node;
        }

        public CreatorInfo Clone() {
            CreatorInfo ci = new CreatorInfo();

            ci.Parson = this.Parson.Clone();

            foreach (CreatorLicense itm in this.LicenseList) {
                ci.LicenseList.Add(itm.Clone());
            }
            return ci;
        }

    }
}
