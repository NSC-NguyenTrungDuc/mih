using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCSACT2GetPatientListOCSInfo
    {
        private String _inOutGubun;
        private String _bunho;
        private String _suname;
        private String _suname2;
        private String _gwa;
        private String _gwaName;
        private String _doctor;
        private String _doctorName;
        private String _jundalTable;
        private String _reserYn;
        private String _emergency;
        private String _trial;
        private String _pkocs1003;
        private String _pkout1001;

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
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

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
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

        public String JundalTable
        {
            get { return this._jundalTable; }
            set { this._jundalTable = value; }
        }

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
        }

        public String Emergency
        {
            get { return this._emergency; }
            set { this._emergency = value; }
        }

        public String Trial
        {
            get { return this._trial; }
            set { this._trial = value; }
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

        public OCSACT2GetPatientListOCSInfo() { }

        public OCSACT2GetPatientListOCSInfo(String inOutGubun, String bunho, String suname, String suname2, String gwa, String gwaName, String doctor, String doctorName, String jundalTable, String reserYn, String emergency, String trial, String pkocs1003, String pkout1001)
        {
            this._inOutGubun = inOutGubun;
            this._bunho = bunho;
            this._suname = suname;
            this._suname2 = suname2;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._jundalTable = jundalTable;
            this._reserYn = reserYn;
            this._emergency = emergency;
            this._trial = trial;
            this._pkocs1003 = pkocs1003;
            this._pkout1001 = pkout1001;
        }

    }
}