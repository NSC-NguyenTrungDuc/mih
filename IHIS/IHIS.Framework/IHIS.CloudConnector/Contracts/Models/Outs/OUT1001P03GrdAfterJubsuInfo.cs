using System;

namespace IHIS.CloudConnector.Contracts.Models.Outs
{
    [Serializable]
    public class OUT1001P03GrdAfterJubsuInfo
    {
        private String _ioGubun;
        private String _pkKey;
        private String _bunho;
        private String _suname;
        private String _naewonDate;
        private String _gwa;
        private String _gwaName;
        private String _doctor;
        private String _doctorName;
        private String _naewonTime;
        private String _comments;
        private String _bunhoType;
        private String _reserYn;
        private String _reserGubun;

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String PkKey
        {
            get { return this._pkKey; }
            set { this._pkKey = value; }
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

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String NaewonTime
        {
            get { return this._naewonTime; }
            set { this._naewonTime = value; }
        }

        public String Comments
        {
            get { return this._comments; }
            set { this._comments = value; }
        }

        public String BunhoType
        {
            get { return this._bunhoType; }
            set { this._bunhoType = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String ReserGubun
        {
            get { return this._reserGubun; }
            set { this._reserGubun = value; }
        }

        public OUT1001P03GrdAfterJubsuInfo() { }

        public OUT1001P03GrdAfterJubsuInfo(String ioGubun, String pkKey, String bunho, String suname, String naewonDate, String gwa, String gwaName, String doctor, String doctorName, String naewonTime, String comments, String bunhoType, String reserYn, String reserGubun)
        {
            this._ioGubun = ioGubun;
            this._pkKey = pkKey;
            this._bunho = bunho;
            this._suname = suname;
            this._naewonDate = naewonDate;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._naewonTime = naewonTime;
            this._comments = comments;
            this._bunhoType = bunhoType;
            this._reserYn = reserYn;
            this._reserGubun = reserGubun;
        }

    }
}