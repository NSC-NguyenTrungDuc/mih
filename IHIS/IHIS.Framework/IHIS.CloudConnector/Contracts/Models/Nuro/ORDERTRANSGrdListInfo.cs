using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdListInfo
    {
        private String _fkinp1001;
        private String _bunho;
        private String _suname;
        private String _ipwonDate;
        private String _ipwonTime;
        private String _gwa;
        private String _doctor;
        private String _gwaName;
        private String _doctorName;
        private String _gubun;
        private String _gubunName;
        private String _gongbiYn;
        private String _chojae;
        private String _chojaeName;
        private String _pkinp1002;
        private String _actingDate;
        private String _orderDate;
        private String _gubunOld;
        private String _chojaeOld;
        private String _gongbiCode1;
        private String _gongbiCode2;
        private String _gongbiCode3;
        private String _gongbiCode4;
        private String _gongbiCode1Name;
        private String _gongbiCode2Name;
        private String _gongbiCode3Name;
        private String _gongbiCode4Name;
        private String _pkout;
        private String _sendDate;
        private String _sanjungGubun;
        private String _sanjungGubunName;
        private String _ifValidYn;

        public String Fkinp1001
        {
            get { return this._fkinp1001; }
            set { this._fkinp1001 = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String IpwonDate
        {
            get { return this._ipwonDate; }
            set { this._ipwonDate = value; }
        }

        public String IpwonTime
        {
            get { return this._ipwonTime; }
            set { this._ipwonTime = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String Gubun
        {
            get { return this._gubun; }
            set { this._gubun = value; }
        }

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
        }

        public String GongbiYn
        {
            get { return this._gongbiYn; }
            set { this._gongbiYn = value; }
        }

        public String Chojae
        {
            get { return this._chojae; }
            set { this._chojae = value; }
        }

        public String ChojaeName
        {
            get { return this._chojaeName; }
            set { this._chojaeName = value; }
        }

        public String Pkinp1002
        {
            get { return this._pkinp1002; }
            set { this._pkinp1002 = value; }
        }

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String GubunOld
        {
            get { return this._gubunOld; }
            set { this._gubunOld = value; }
        }

        public String ChojaeOld
        {
            get { return this._chojaeOld; }
            set { this._chojaeOld = value; }
        }

        public String GongbiCode1
        {
            get { return this._gongbiCode1; }
            set { this._gongbiCode1 = value; }
        }

        public String GongbiCode2
        {
            get { return this._gongbiCode2; }
            set { this._gongbiCode2 = value; }
        }

        public String GongbiCode3
        {
            get { return this._gongbiCode3; }
            set { this._gongbiCode3 = value; }
        }

        public String GongbiCode4
        {
            get { return this._gongbiCode4; }
            set { this._gongbiCode4 = value; }
        }

        public String GongbiCode1Name
        {
            get { return this._gongbiCode1Name; }
            set { this._gongbiCode1Name = value; }
        }

        public String GongbiCode2Name
        {
            get { return this._gongbiCode2Name; }
            set { this._gongbiCode2Name = value; }
        }

        public String GongbiCode3Name
        {
            get { return this._gongbiCode3Name; }
            set { this._gongbiCode3Name = value; }
        }

        public String GongbiCode4Name
        {
            get { return this._gongbiCode4Name; }
            set { this._gongbiCode4Name = value; }
        }

        public String Pkout
        {
            get { return this._pkout; }
            set { this._pkout = value; }
        }

        public String SendDate
        {
            get { return this._sendDate; }
            set { this._sendDate = value; }
        }

        public String SanjungGubun
        {
            get { return this._sanjungGubun; }
            set { this._sanjungGubun = value; }
        }

        public String SanjungGubunName
        {
            get { return this._sanjungGubunName; }
            set { this._sanjungGubunName = value; }
        }

        public String IfValidYn
        {
            get { return this._ifValidYn; }
            set { this._ifValidYn = value; }
        }

        public ORDERTRANSGrdListInfo() { }

        public ORDERTRANSGrdListInfo(String fkinp1001, String bunho, String suname, String ipwonDate, String ipwonTime, String gwa, String doctor, String gwaName, String doctorName, String gubun, String gubunName, String gongbiYn, String chojae, String chojaeName, String pkinp1002, String actingDate, String orderDate, String gubunOld, String chojaeOld, String gongbiCode1, String gongbiCode2, String gongbiCode3, String gongbiCode4, String gongbiCode1Name, String gongbiCode2Name, String gongbiCode3Name, String gongbiCode4Name, String pkout, String sendDate, String sanjungGubun, String sanjungGubunName, String ifValidYn)
        {
            this._fkinp1001 = fkinp1001;
            this._bunho = bunho;
            this._suname = suname;
            this._ipwonDate = ipwonDate;
            this._ipwonTime = ipwonTime;
            this._gwa = gwa;
            this._doctor = doctor;
            this._gwaName = gwaName;
            this._doctorName = doctorName;
            this._gubun = gubun;
            this._gubunName = gubunName;
            this._gongbiYn = gongbiYn;
            this._chojae = chojae;
            this._chojaeName = chojaeName;
            this._pkinp1002 = pkinp1002;
            this._actingDate = actingDate;
            this._orderDate = orderDate;
            this._gubunOld = gubunOld;
            this._chojaeOld = chojaeOld;
            this._gongbiCode1 = gongbiCode1;
            this._gongbiCode2 = gongbiCode2;
            this._gongbiCode3 = gongbiCode3;
            this._gongbiCode4 = gongbiCode4;
            this._gongbiCode1Name = gongbiCode1Name;
            this._gongbiCode2Name = gongbiCode2Name;
            this._gongbiCode3Name = gongbiCode3Name;
            this._gongbiCode4Name = gongbiCode4Name;
            this._pkout = pkout;
            this._sendDate = sendDate;
            this._sanjungGubun = sanjungGubun;
            this._sanjungGubunName = sanjungGubunName;
            this._ifValidYn = ifValidYn;
        }

    }
}