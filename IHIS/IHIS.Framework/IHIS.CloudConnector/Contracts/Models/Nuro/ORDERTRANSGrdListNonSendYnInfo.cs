using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdListNonSendYnInfo
    {
        private String _fkout1001;
        private String _bunho;
        private String _suname;
        private String _actingDate;
        private String _gwa;
        private String _gwaName;
        private String _doctor;
        private String _doctorName;
        private String _gubun;
        private String _gubunName;
        private String _sendedYn;
        private String _naewonYn;
        private String _orderByKey;
        private String _chojaeName;

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
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

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
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

        public String SendedYn
        {
            get { return this._sendedYn; }
            set { this._sendedYn = value; }
        }

        public String NaewonYn
        {
            get { return this._naewonYn; }
            set { this._naewonYn = value; }
        }

        public String OrderByKey
        {
            get { return this._orderByKey; }
            set { this._orderByKey = value; }
        }

        public String ChojaeName
        {
            get { return this._chojaeName; }
            set { this._chojaeName = value; }
        }

        public ORDERTRANSGrdListNonSendYnInfo() { }

        public ORDERTRANSGrdListNonSendYnInfo(String fkout1001, String bunho, String suname, String actingDate, String gwa, String gwaName, String doctor, String doctorName, String gubun, String gubunName, String sendedYn, String naewonYn, String orderByKey, String chojaeName)
        {
            this._fkout1001 = fkout1001;
            this._bunho = bunho;
            this._suname = suname;
            this._actingDate = actingDate;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._gubun = gubun;
            this._gubunName = gubunName;
            this._sendedYn = sendedYn;
            this._naewonYn = naewonYn;
            this._orderByKey = orderByKey;
            this._chojaeName = chojaeName;
        }

    }
}