using System;

namespace IHIS.CloudConnector.Contracts.Models.OcsEmr
{
    public class OCS2015U00GetDoctorPatientReportInfo
    {
        private String _doctorName;
        private String _gwaName;
        private String _yotangName;
        private String _adressDoc;
        private String _telDoc;
        private String _seqvalue;
        private String _suname;
        private String _birth;
        private String _sex;
        private String _adressPa;
        private String _telPa;
        private String _faxDoc;
        private String _website;

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String YotangName
        {
            get { return this._yotangName; }
            set { this._yotangName = value; }
        }

        public String AdressDoc
        {
            get { return this._adressDoc; }
            set { this._adressDoc = value; }
        }

        public String TelDoc
        {
            get { return this._telDoc; }
            set { this._telDoc = value; }
        }

        public String Seqvalue
        {
            get { return this._seqvalue; }
            set { this._seqvalue = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String AdressPa
        {
            get { return this._adressPa; }
            set { this._adressPa = value; }
        }

        public String TelPa
        {
            get { return this._telPa; }
            set { this._telPa = value; }
        }

        public String FaxDoc
        {
            get { return this._faxDoc; }
            set { this._faxDoc = value; }
        }

        public String Website
        {
            get { return this._website; }
            set { this._website = value; }
        }

        public OCS2015U00GetDoctorPatientReportInfo() { }

        public OCS2015U00GetDoctorPatientReportInfo(String doctorName, String gwaName, String yotangName, String adressDoc, String telDoc, String seqvalue, String suname, String birth, String sex, String adressPa, String telPa, String faxDoc, String website)
        {
            this._doctorName = doctorName;
            this._gwaName = gwaName;
            this._yotangName = yotangName;
            this._adressDoc = adressDoc;
            this._telDoc = telDoc;
            this._seqvalue = seqvalue;
            this._suname = suname;
            this._birth = birth;
            this._sex = sex;
            this._adressPa = adressPa;
            this._telPa = telPa;
            this._faxDoc = faxDoc;
            this._website = website;
        }

    }
}