using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCS1003R00LayOUT1001Info
    {
        private String _reserYn;
        private String _bunho;
        private String _suname;
        private String _suname2;
        private String _birth;
        private String _sexAge;
        private String _doctor;
        private String _doctorName;
        private String _gwa;
        private String _gwaName;
        private String _chojae;
        private String _chojaeName;
        private String _naewonDate;
        private String _inputGubun;
        private String _orderEndYn;

        public String ReserYn
        {
            get { return this._reserYn; }
            set { this._reserYn = value; }
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

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String SexAge
        {
            get { return this._sexAge; }
            set { this._sexAge = value; }
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

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String InputGubun
        {
            get { return this._inputGubun; }
            set { this._inputGubun = value; }
        }

        public String OrderEndYn
        {
            get { return this._orderEndYn; }
            set { this._orderEndYn = value; }
        }

        public OCS1003R00LayOUT1001Info() { }

        public OCS1003R00LayOUT1001Info(String reserYn, String bunho, String suname, String suname2, String birth, String sexAge, String doctor, String doctorName, String gwa, String gwaName, String chojae, String chojaeName, String naewonDate, String inputGubun, String orderEndYn)
        {
            this._reserYn = reserYn;
            this._bunho = bunho;
            this._suname = suname;
            this._suname2 = suname2;
            this._birth = birth;
            this._sexAge = sexAge;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._gwa = gwa;
            this._gwaName = gwaName;
            this._chojae = chojae;
            this._chojaeName = chojaeName;
            this._naewonDate = naewonDate;
            this._inputGubun = inputGubun;
            this._orderEndYn = orderEndYn;
        }

    }
}