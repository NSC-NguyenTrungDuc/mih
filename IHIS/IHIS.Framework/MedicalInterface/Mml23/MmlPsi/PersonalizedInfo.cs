using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using MedicalInterface.Mml23.MmlDp;
using MedicalInterface.Mml23.MmlFc;

namespace MedicalInterface.Mml23.MmlPsi {
    using MedicalInterface.Mml23.MmlAd;
    using MedicalInterface.Mml23.MmlCm;
    using MedicalInterface.Mml23.MmlNm;
    using MedicalInterface.Mml23.MmlPh;

    public class PersonalizedInfo {
        private Id _parsonId;
        private Name _parsonName;
        private List<Name> _otherNameList;
        private Facility _facility;
        private Department _department;
        private List<Address> _addressList;
        private List<MailAddress> _mailAddressList;
        private List<Phone> _phoneList;

        public const string NameSpaceURI = "http://www.medxml.net/MML/SharedComponent/PersonalizedInfo/1.0";

        public const string NameSpacePrefix = "mmlPsi";

        public MmlCm.Id ParsonId
        {
            get { return _parsonId; }
            set { _parsonId = value; }
        }

        public MmlNm.Name ParsonName
        {
            get { return _parsonName; }
            set { _parsonName = value; }
        }

        public List<MmlNm.Name> OtherNameList
        {
            get { return _otherNameList; }
            set { _otherNameList = value; }
        }

        public MmlFc.Facility Facility
        {
            get { return _facility; }
            set { _facility = value; }
        }

        public MmlDp.Department Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public List<MmlAd.Address> AddressList
        {
            get { return _addressList; }
            set { _addressList = value; }
        }

        public List<MmlCm.MailAddress> MailAddressList
        {
            get { return _mailAddressList; }
            set { _mailAddressList = value; }
        }

        public List<MmlPh.Phone> PhoneList
        {
            get { return _phoneList; }
            set { _phoneList = value; }
        }

        public PersonalizedInfo() {
            this.ParsonId = new MmlCm.Id();
            this.ParsonId.IdType = "facility";
            this.ParsonId.TableId = "MML0024";

            this.ParsonName = new MmlNm.Name();

            this.Facility = new MmlFc.Facility();

            this.Department = new MmlDp.Department();

            OtherNameList = new List<MmlNm.Name>();
            AddressList = new List<MmlAd.Address>();
            MailAddressList = new List<MmlCm.MailAddress>();
            PhoneList = new List<MmlPh.Phone>();

        }

        public PersonalizedInfo(XmlNode node) {
            this.ParsonName = null;
            OtherNameList = new List<MmlNm.Name>();
            AddressList = new List<MmlAd.Address>();
            MailAddressList = new List<MmlCm.MailAddress>();
            PhoneList = new List<MmlPh.Phone>();

            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            foreach (XmlNode elm in node.ChildNodes) {
                if (elm.LocalName == "Id") {
                    this.ParsonId = new MmlCm.Id(elm);
                }
                if (elm.LocalName == "personName") {
                    foreach (XmlNode name in elm.ChildNodes) {
                        if (this.ParsonName == null) {
                            this.ParsonName = new MmlNm.Name(name);
                        } else {
                            this.OtherNameList.Add(new MmlNm.Name(name));
                        }
                    }
                }
                if (elm.LocalName == "Facility") {
                    this.Facility = new MmlFc.Facility(elm);
                }
                if (elm.LocalName == "Department") {
                    this.Department = new MmlDp.Department(elm);
                }
                if (elm.LocalName == "addresses") {
                    foreach (XmlNode addr in elm.ChildNodes) {
                        this.AddressList.Add(new MmlAd.Address(addr));
                    }
                }
                if (elm.LocalName == "emailAddresses") {
                    foreach (XmlNode mail in elm.ChildNodes) {
                        this.MailAddressList.Add(new MmlCm.MailAddress(mail));
                    }
                }
                if (elm.LocalName == "phones") {
                    foreach (XmlNode phone in elm.ChildNodes) {
                        this.PhoneList.Add(new MmlPh.Phone(phone));
                    }
                }

            }
        }

        public XmlElement WriteXml(XmlDocument doc) {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "PersonalizedInfo", NameSpaceURI);

            node.AppendChild(this.ParsonId.WriteXml(doc));

            XmlElement elm = doc.CreateElement(NameSpacePrefix, "personName", NameSpaceURI);
            elm.AppendChild(this.ParsonName.WriteXml(doc));
            foreach (Name itm in this.OtherNameList) {
                elm.AppendChild(itm.WriteXml(doc));
            }
            node.AppendChild(elm);

            node.AppendChild(this.Facility.WriteXml(doc));

            node.AppendChild(this.Department.WriteXml(doc));

            if (this.AddressList.Count > 0) {
                elm = doc.CreateElement(NameSpacePrefix, "addresses", NameSpaceURI);
                foreach (Address itm in this.AddressList) {
                    elm.AppendChild(itm.WriteXml(doc));
                }
                node.AppendChild(elm);
            }

            if (this.MailAddressList.Count > 0) {
                elm = doc.CreateElement(NameSpacePrefix, "emailAddresses", NameSpaceURI);
                foreach (MailAddress itm in this.MailAddressList) {
                    elm.AppendChild(itm.WriteXml(doc));
                }
                node.AppendChild(elm);
            }

            if (this.PhoneList.Count > 0) {
                elm = doc.CreateElement(NameSpacePrefix, "phones", NameSpaceURI);
                foreach (Phone itm in this.PhoneList) {
                    elm.AppendChild(itm.WriteXml(doc));
                }
                node.AppendChild(elm);
            }


            return node;
        }


        public PersonalizedInfo Clone() {
            PersonalizedInfo pi = new PersonalizedInfo();

            pi.ParsonId = this.ParsonId.Clone();
            pi.ParsonName = this.ParsonName.Clone();

            foreach (Name item in this.OtherNameList) {
                pi.OtherNameList.Add(item.Clone());
            }

            pi.Facility = this.Facility.Clone();
            pi.Department = this.Department.Clone();

            foreach (Address item in this.AddressList) {
                pi.AddressList.Add(item.Clone());
            }

            foreach (Phone item in this.PhoneList) {
                pi.PhoneList.Add(item.Clone());
            }

            foreach (MailAddress item in this.MailAddressList) {
                pi.MailAddressList.Add(item.Clone());
            }

            return pi;
        }
    }
}
