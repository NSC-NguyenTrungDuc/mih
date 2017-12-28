using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCSACT2GetGrdPaListInfo
    {
        private String _trialFlg;
        private String _suname;
        private String _jundalTable;
        private String _gwa;
        private String _gwaName;
        private String _doctor;
        private String _doctorName;
        private String _suname2;
        private String _bunho;
        private String _pkocs1003;
        private String _fkout1001;
        private String _reserGubun;
        private String _orderDate;
        private String _reserDate;
        private String _inOutGubun;
        private String _reserYn;
        private String _kijunDate;
        private String _naewonTime;
        private String _emergencyYn;
        private String _actingYn;

        public String TrialFlg
        {
            get { return this._trialFlg; }
            set { this._trialFlg = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
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

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String ReserGubun
        {
            get { return this._reserGubun; }
            set { this._reserGubun = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String KijunDate
        {
            get { return this._kijunDate; }
            set { this._kijunDate = value; }
        }

        public String NaewonTime
        {
            get { return this._naewonTime; }
            set { this._naewonTime = value; }
        }

        public String EmergencyYn
        {
            get { return this._emergencyYn; }
            set { this._emergencyYn = value; }
        }

        public String ActingYn
        {
            get { return this._actingYn; }
            set { this._actingYn = value; }
        }

        public OCSACT2GetGrdPaListInfo() { }

        public OCSACT2GetGrdPaListInfo(String trialFlg, String suname, String jundalTable, String gwa, String gwaName, String doctor, String doctorName, String suname2, String bunho, String pkocs1003, String fkout1001, String reserGubun, String orderDate, String reserDate, String inOutGubun, String reserYn, String kijunDate, String naewonTime, String emergencyYn, String actingYn)
        {
            this._trialFlg = trialFlg;
            this._suname = suname;
            this._jundalTable = jundalTable;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._suname2 = suname2;
            this._bunho = bunho;
            this._pkocs1003 = pkocs1003;
            this._fkout1001 = fkout1001;
            this._reserGubun = reserGubun;
            this._orderDate = orderDate;
            this._reserDate = reserDate;
            this._inOutGubun = inOutGubun;
            this._reserYn = reserYn;
            this._kijunDate = kijunDate;
            this._naewonTime = naewonTime;
            this._emergencyYn = emergencyYn;
            this._actingYn = actingYn;
        }

    }
}