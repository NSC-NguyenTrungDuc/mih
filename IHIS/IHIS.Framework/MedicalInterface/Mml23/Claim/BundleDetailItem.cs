using System;
using System.Collections.Generic;

using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23.Claim {
    public class BundleDetailItem {
        private string _subClassCode;
        private string _subClassCodeTableId;
        private string _code;
        private string _codeTableId;
        private string _name;
        private string _aliasCode;
        private string _aliasCodeTableId;
        private List<NumberItem> _numberList;
        private TimeSpan _duration;
        private List<LocationItem> _locationList;
        private List<FilmItem> _filmList;
        private EventItem _event;
        private string _memo;

        public string NameSpaceURI {
            get { return "http://www.medxml.net/claim/claimModule/2.1"; }
        }

        public string SubClassCode
        {
            get { return _subClassCode; }
            set { _subClassCode = value; }
        }

        public string SubClassCodeTableId
        {
            get { return _subClassCodeTableId; }
            set { _subClassCodeTableId = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string CodeTableId
        {
            get { return _codeTableId; }
            set { _codeTableId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string AliasCode
        {
            get { return _aliasCode; }
            set { _aliasCode = value; }
        }

        public string AliasCodeTableId
        {
            get { return _aliasCodeTableId; }
            set { _aliasCodeTableId = value; }
        }

        public List<NumberItem> NumberList
        {
            get { return _numberList; }
            set { _numberList = value; }
        }

        public TimeSpan Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public List<LocationItem> LocationList
        {
            get { return _locationList; }
            set { _locationList = value; }
        }

        public List<FilmItem> FilmList
        {
            get { return _filmList; }
            set { _filmList = value; }
        }

        public EventItem Event
        {
            get { return _event; }
            set { _event = value; }
        }

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        public BundleDetailItem() {
            _locationList = new List<LocationItem>();
            _filmList = new List<FilmItem>();
            _numberList = new List<NumberItem>();
        }

        public BundleDetailItem(XmlNode node) {
            _locationList = new List<LocationItem>();
            _filmList = new List<FilmItem>();
            _numberList = new List<NumberItem>();
            LoadFromXml(node);
        }

        private void LoadFromXml(XmlNode node) {
            XmlNodeHelper ndhp = new XmlNodeHelper(node);
            ndhp.NamespaceManager.AddNamespace("claim", NameSpaceURI);

            this.SubClassCode = ndhp.GetAttributeString("claim:subclassCode");
            this.SubClassCodeTableId = ndhp.GetAttributeString("claim:subclassCodeId");

            this.Code = ndhp.GetAttributeString("claim:code");
            this.CodeTableId = ndhp.GetAttributeString("claim:tableId");

            this.AliasCode = ndhp.GetAttributeString("claim:aliasCode");
            this.AliasCodeTableId = ndhp.GetAttributeString("claim:aliasTableId");

            this.Name = ndhp.GetNodeText("claim:name");

            this.NumberList = new List<NumberItem>();
            foreach (XmlNode subnd in ndhp.SelectNodes("claim:number")) {
                NumberItem numitm = new NumberItem(subnd);
                this.NumberList.Add(numitm);
            }

            string tmpstr = ndhp.GetNodeText("claim:duration");
            this.Duration = new TimeSpan(0, 0, 0);
            if (tmpstr != null) {
                //書式PTnHnM
                tmpstr = tmpstr.Replace("RT", "");
                tmpstr = tmpstr.Replace("M", "");
                tmpstr = tmpstr.Replace("H", ":");
                string[] tm = tmpstr.Split(':');
                if (tm.Length == 2) {
                    this.Duration = new TimeSpan(int.Parse(tm[0]), int.Parse(tm[1]),0);
                }
            }

            this.LocationList = new List<LocationItem>();
            foreach (XmlNode subnd in ndhp.SelectNodes("claim:location")) {
                LocationItem numitm = new LocationItem(subnd);
                this.LocationList.Add(numitm);
            }

            this.FilmList = new List<FilmItem>();
            foreach (XmlNode subnd in ndhp.SelectNodes("claim:film")) {
                FilmItem numitm = new FilmItem(subnd);
                this.FilmList.Add(numitm);
            }

            this.Event = new EventItem(ndhp.GetNode("claim:event"));

            this.Memo = ndhp.GetNodeText("claim:memo");

        }

    }
}
