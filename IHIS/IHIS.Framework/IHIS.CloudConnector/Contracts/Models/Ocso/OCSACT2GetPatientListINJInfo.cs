using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCSACT2GetPatientListINJInfo
    {
        private String _trialYn;
        private String _reserGubun;
        private String _bunho;
        private String _suname;
        private String _jundalTable;
        private String _orderDate;
        private String _reserDate;
        private String _gwa;
        private String _gwaName;
        private String _doctor;
        private String _doctorName;
        private String _pkocs1003;
        private String _pkout1001;
        private String _suname2;

        public String TrialYn
        {
            get { return this._trialYn; }
            set { this._trialYn = value; }
        }

        public String ReserGubun
        {
            get { return this._reserGubun; }
            set { this._reserGubun = value; }
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

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
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

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public OCSACT2GetPatientListINJInfo() { }

        public OCSACT2GetPatientListINJInfo(String trialYn, String reserGubun, String bunho, String suname, String jundalTable, String orderDate, String reserDate, String gwa, String gwaName, String doctor, String doctorName, String pkocs1003, String pkout1001, String suname2)
        {
            this._trialYn = trialYn;
            this._reserGubun = reserGubun;
            this._bunho = bunho;
            this._suname = suname;
            this._jundalTable = jundalTable;
            this._orderDate = orderDate;
            this._reserDate = reserDate;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._pkocs1003 = pkocs1003;
            this._pkout1001 = pkout1001;
            this._suname2 = suname2;
        }

    }
}