using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;
using MedicalInterface.Mml23.MmlAd;
using MedicalInterface.Mml23.MmlCm;
using MedicalInterface.Mml23.MmlNm;
using MedicalInterface.Mml23.MmlPh;

namespace MedicalInterface.Mml23.MmlPi {
    public class PatientModule : Mml23.MmlContent {
        private Id _masterId;
        private Name _kanjiName;
        private Name _kanaName;
        private Name _alphaName;
        private DateTime _birthday;
        private string _sex;
        private string _nationality;
        private string _secondNationality;
        private string _marital;
        private List<Address> _addressList;
        private List<MailAddress> _mailAddressList;
        private List<Phone> _phoneList;
        private string _accountNumber;
        private string _socialIdentification;
        private bool _deathFlag;
        private DateTime? _deathDate;
        private Dictionary<string, List<Id>> _otherIdList;

        public const string NameSpaceURI = "http://www.medxml.net/MML/ContentModule/PatientInfo/1.0";

        public const string NameSpacePrefix = "mmlPi";

        public MmlCm.Id MasterId
        {
            get { return _masterId; }
            set { _masterId = value; }
        }

        public Dictionary<string, List<MmlCm.Id>> OtherIdList
        {
            get { return _otherIdList; }
            set { _otherIdList = value; }
        }

        public MmlNm.Name KanjiName
        {
            get { return _kanjiName; }
            set { _kanjiName = value; }
        }

        public MmlNm.Name KanaName
        {
            get { return _kanaName; }
            set { _kanaName = value; }
        }

        public MmlNm.Name AlphaName
        {
            get { return _alphaName; }
            set { _alphaName = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        public string SecondNationality
        {
            get { return _secondNationality; }
            set { _secondNationality = value; }
        }

        public string Marital
        {
            get { return _marital; }
            set { _marital = value; }
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

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public string SocialIdentification
        {
            get { return _socialIdentification; }
            set { _socialIdentification = value; }
        }

        public bool DeathFlag
        {
            get { return _deathFlag; }
            set { _deathFlag = value; }
        }

        public Nullable<DateTime> DeathDate
        {
            get { return _deathDate; }
            set { _deathDate = value; }
        }


        public PatientModule() {
            OtherIdList = new Dictionary<string, List<MmlCm.Id>>();
            AddressList = new List<MmlAd.Address>();
            MailAddressList = new List<MmlCm.MailAddress>();
            PhoneList = new List<MmlPh.Phone>();
        }

        public PatientModule(XmlNode node) {
            OtherIdList = new Dictionary<string, List<MmlCm.Id>>();
            AddressList = new List<MmlAd.Address>();
            MailAddressList = new List<MmlCm.MailAddress>();
            PhoneList = new List<MmlPh.Phone>();
            LoadFromXml(node);
        }

        public override void LoadFromXml(XmlNode node) {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
            nsmgr.AddNamespace(NameSpacePrefix, NameSpaceURI);
            nsmgr.AddNamespace(MmlNm.Name.NameSpacePrefix, MmlNm.Name.NameSpaceURI);
            nsmgr.AddNamespace(MmlAd.Address.NameSpacePrefix, MmlAd.Address.NameSpaceURI);
            nsmgr.AddNamespace(MmlCm.MailAddress.NameSpacePrefix, MmlCm.MailAddress.NameSpaceURI);
            nsmgr.AddNamespace(MmlPh.Phone.NameSpacePrefix, MmlPh.Phone.NameSpaceURI);

            this.MasterId = new MmlCm.Id(node.SelectSingleNode("mmlPi:uniqueInfo/mmlPi:masterId", nsmgr).FirstChild);

            foreach (XmlNode oid in node.SelectNodes("mmlPi:uniqueInfo/mmlPi:otherId",nsmgr)) {
                XmlAttribute attr = oid.Attributes["mmlPi:type"];
                if (!this.OtherIdList.ContainsKey(attr.Value)) {
                    this.OtherIdList.Add(attr.Value,new List<MmlCm.Id>());
                }
                this.OtherIdList[attr.Value].Add(new MmlCm.Id(oid.FirstChild));
            }

            foreach (XmlNode nm in node.SelectNodes("mmlPi:personName/mmlNm:Name", nsmgr)) {
                MmlNm.Name name=new MmlNm.Name(nm);
                if (name.RepCode == "I") {
                    this.KanjiName = name;
                } else if(name.RepCode=="P"){
                    this.KanaName = name;
                } else {
                    this.AlphaName = name;
                }
            }

            this.Birthday = DateTime.Parse(node.SelectSingleNode("mmlPi:birthday", nsmgr).InnerText.Trim());
            this.Sex = node.SelectSingleNode("mmlPi:sex", nsmgr).InnerText.Trim();
            XmlNode marital = node.SelectSingleNode("mmlPi:marital", nsmgr);
            if (marital != null) {
                this.Marital = marital.InnerText.Trim();
            }

            XmlNode nation = node.SelectSingleNode("mmlPi:nationality", nsmgr);
            if (nation != null) {
                this.Nationality = nation.InnerText.Trim();
                XmlAttribute attr = nation.Attributes["mmlPi:subtype"];
                if (attr != null) {
                    this.SecondNationality = attr.Value;
                } else {
                    this.SecondNationality = "";
                }
            } else {
                this.Nationality = "JPN";
                this.SecondNationality = "";
            }

            XmlNode death = node.SelectSingleNode("mmlPi:death", nsmgr);
            if (death != null) {
                if (Boolean.Parse(death.InnerText.Trim()) == true) {
                    this.DeathFlag = true;
                } else {
                    this.DeathFlag = false;
                }
                XmlAttribute attr = GetAttribute(death, "mmlPi:date");
                if (attr != null) {
                    this.DeathDate = DateTime.Parse(attr.Value);
                }
            }

            XmlNode acc = node.SelectSingleNode("mmlPi:accountNumber", nsmgr);
            if (acc != null) {
                this.AccountNumber = acc.InnerText.Trim();
            }

            XmlNode sid = node.SelectSingleNode("mmlPi:socialIdentification", nsmgr);
            if (sid != null) {
                this.SocialIdentification = sid.InnerText.Trim();
            }

            foreach (XmlNode addr in node.SelectNodes("mmlPi:addresses/mmlAd:Address",nsmgr)) {
                this.AddressList.Add(new MmlAd.Address(addr));                
            }
            foreach (XmlNode email in node.SelectNodes("mmlPi:emailAddresses/mmlCm:email", nsmgr)) {
                this.MailAddressList.Add(new MmlCm.MailAddress(email));
            }
            foreach (XmlNode phone in node.SelectNodes("mmlPi:phones/mmlPh:Phone", nsmgr)) {
                this.PhoneList.Add(new MmlPh.Phone(phone));
            }

            
        }

        public override XmlElement WriteXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement(NameSpacePrefix, "PatientModule", NameSpaceURI);
            XmlElement uniqueInfo = doc.CreateElement(NameSpacePrefix, "uniqueInfo", NameSpaceURI);
            XmlElement elm = doc.CreateElement(NameSpacePrefix, "masterId", NameSpaceURI);

            elm.AppendChild(this.MasterId.WriteXml(doc));
            node.AppendChild(elm);

            uniqueInfo.AppendChild(elm);
            foreach (KeyValuePair<string, List<Id>> pair in OtherIdList)
            {
                foreach (Id id in pair.Value)
                {
                    elm = doc.CreateElement(NameSpacePrefix, "otherId", NameSpaceURI);
                    XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "type", NameSpaceURI);
                    attr.Value = pair.Key;
                    elm.Attributes.Append(attr);
                    elm.AppendChild(id.WriteXml(doc));
                    uniqueInfo.AppendChild(elm);
                }
            }
            node.AppendChild(uniqueInfo);

            elm = doc.CreateElement(NameSpacePrefix, "personName", NameSpaceURI);
            if (KanaName != null)
            {
                KanaName.RepCode = "P";
                elm.AppendChild(KanaName.WriteXml(doc));
            }
            if (KanjiName != null)
            {
                KanjiName.RepCode = "I";
                elm.AppendChild(KanjiName.WriteXml(doc));
            }
            if (AlphaName != null)
            {
                AlphaName.RepCode = "A";
                elm.AppendChild(AlphaName.WriteXml(doc));
            }            

            if (Birthday != null)
            {
                elm = doc.CreateElement(NameSpacePrefix, "birthday", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(Birthday.ToString("yyyy/MM/dd")));
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(Sex))
            {
                elm = doc.CreateElement(NameSpacePrefix, "sex", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(Sex));
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(Marital))
            {
                elm = doc.CreateElement(NameSpacePrefix, "marital", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(Marital));
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(Nationality))
            {
                elm = doc.CreateElement(NameSpacePrefix, "nationality", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(Nationality));
                if (!string.IsNullOrEmpty(SecondNationality))
                {
                    XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "subtype", NameSpaceURI);
                    attr.Value = SecondNationality;
                    elm.Attributes.Append(attr);
                }
                node.AppendChild(elm);
            }

            if (DeathFlag)
            {
                elm = doc.CreateElement(NameSpacePrefix, "death", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode("true"));
                if (DeathDate != null)
                {
                    XmlAttribute attr = doc.CreateAttribute(NameSpacePrefix, "date", NameSpaceURI);
                    attr.Value = DeathDate.Value.ToString("yyyy/MM/dd");
                    elm.Attributes.Append(attr);
                }
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(AccountNumber))
            {
                elm = doc.CreateElement(NameSpacePrefix, "accountNumber", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(AccountNumber));
                node.AppendChild(elm);
            }

            if (!string.IsNullOrEmpty(SocialIdentification))
            {
                elm = doc.CreateElement(NameSpacePrefix, "socialIdentification", NameSpaceURI);
                elm.AppendChild(doc.CreateTextNode(SocialIdentification));
                node.AppendChild(elm);
            }
            if (AddressList.Count > 0)
            {
                elm = doc.CreateElement(NameSpacePrefix, "addresses", NameSpaceURI);
                foreach (Address address in AddressList)
                {
                    elm.AppendChild(address.WriteXml(doc));
                }
                node.AppendChild(elm);
            }
            if (MailAddressList.Count > 0)
            {
                elm = doc.CreateElement(NameSpacePrefix, "emailAddresses", NameSpaceURI);
                foreach (MailAddress address in MailAddressList)
                {
                    elm.AppendChild(address.WriteXml(doc));
                }
                node.AppendChild(elm);
            }
            if (PhoneList.Count > 0)
            {
                elm = doc.CreateElement(NameSpacePrefix, "phones", NameSpaceURI);
                foreach (Phone address in PhoneList)
                {
                    elm.AppendChild(address.WriteXml(doc));
                }
                node.AppendChild(elm);
            }          

            return node;
        }
    }
}
