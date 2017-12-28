using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class OUT0101U02HospitalItemInfo
    {
        private String _yoyangName;
        private String _address;
        private String _tel;
        private String _patientName;
        private String _password;

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String PatientName
        {
            get { return this._patientName; }
            set { this._patientName = value; }
        }

        public String Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public OUT0101U02HospitalItemInfo() { }

        public OUT0101U02HospitalItemInfo(String yoyangName, String address, String tel, String patientName, String password)
        {
            this._yoyangName = yoyangName;
            this._address = address;
            this._tel = tel;
            this._patientName = patientName;
            this._password = password;
        }

    }
}