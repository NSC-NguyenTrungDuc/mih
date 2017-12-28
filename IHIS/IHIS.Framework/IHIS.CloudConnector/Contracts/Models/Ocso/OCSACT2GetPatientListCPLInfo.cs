using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCSACT2GetPatientListCPLInfo
    {
        private String _bunho;
        private String _suname;
        private String _inOutGubun;
        private String _gwa;
        private String _gwaName;
        private String _reserYn;
        private String _doctor;
        private String _doctorName;
        private String _kijunDate;
        private String _emergencyYn;
        private String _naewonTime;
        private String _trialYn;
        private String _suname2;
        private String _pkocs1003;
        private String _pkout1001;
        private String _jundalTable;

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

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
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

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
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

        public String KijunDate
        {
            get { return this._kijunDate; }
            set { this._kijunDate = value; }
        }

        public String EmergencyYn
        {
            get { return this._emergencyYn; }
            set { this._emergencyYn = value; }
        }

        public String NaewonTime
        {
            get { return this._naewonTime; }
            set { this._naewonTime = value; }
        }

        public String TrialYn
        {
            get { return this._trialYn; }
            set { this._trialYn = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public OCSACT2GetPatientListCPLInfo() { }

        public OCSACT2GetPatientListCPLInfo(String bunho, String suname, String inOutGubun, String gwa, String gwaName, String reserYn, String doctor, String doctorName, String kijunDate, String emergencyYn, String naewonTime, String trialYn, String suname2, String pkocs1003, String pkout1001, String jundalTable)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._inOutGubun = inOutGubun;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._reserYn = reserYn;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._kijunDate = kijunDate;
            this._emergencyYn = emergencyYn;
            this._naewonTime = naewonTime;
            this._trialYn = trialYn;
            this._suname2 = suname2;
            this._pkocs1003 = pkocs1003;
            this._pkout1001 = pkout1001;
            this._jundalTable = jundalTable;
        }

    }
}