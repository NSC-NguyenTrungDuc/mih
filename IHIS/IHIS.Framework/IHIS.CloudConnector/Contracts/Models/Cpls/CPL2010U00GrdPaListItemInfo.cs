using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL2010U00GrdPaListItemInfo
    {
        private String _bunho;
        private String _suname;
        private String _inOutGubun;
        private String _gwaName;
        private String _reserYn;
        private String _doctor;
        private String _doctorName;
        private String _kijunDate;
        private String _emergencyYn;
        private String _naewonTime;
        private String _trialYn;

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

        public CPL2010U00GrdPaListItemInfo() { }

        public CPL2010U00GrdPaListItemInfo(String bunho, String suname, String inOutGubun, String gwaName, String reserYn, String doctor, String doctorName, String kijunDate, String emergencyYn, String naewonTime, String trialYn)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._inOutGubun = inOutGubun;
            this._gwaName = gwaName;
            this._reserYn = reserYn;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._kijunDate = kijunDate;
            this._emergencyYn = emergencyYn;
            this._naewonTime = naewonTime;
            this._trialYn = trialYn;
        }

    }
}