using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class NUR2016Q00GrdPatientListInfo
    {
        private String _bunho;
        private String _patientName;
        private String _address;
        private String _birth;
        private String _suname;
        private String _suname2;
        private String _sex;
        private String _tel;
        private String _linkEmr;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String PatientName
        {
            get { return this._patientName; }
            set { this._patientName = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
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

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String LinkEmr
        {
            get { return this._linkEmr; }
            set { this._linkEmr = value; }
        }

        public NUR2016Q00GrdPatientListInfo() { }

        public NUR2016Q00GrdPatientListInfo(String bunho, String patientName, String address, String birth, String suname, String suname2, String sex, String tel, String linkEmr)
        {
            this._bunho = bunho;
            this._patientName = patientName;
            this._address = address;
            this._birth = birth;
            this._suname = suname;
            this._suname2 = suname2;
            this._sex = sex;
            this._tel = tel;
            this._linkEmr = linkEmr;
        }

    }
}