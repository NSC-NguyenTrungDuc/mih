using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class OUT0101U02ImportPatientInfo
    {
        private String _sex;
        private String _bunho;
        private String _suname;
        private String _suname2;
        private String _birth;
        private String _zipCode;
        private String _tel;
        private String _bunhoType;
        private String _address1;
        private String _address2;
        private String _address3;

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
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

        public String ZipCode
        {
            get { return this._zipCode; }
            set { this._zipCode = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String BunhoType
        {
            get { return this._bunhoType; }
            set { this._bunhoType = value; }
        }

        public String Address1
        {
            get { return this._address1; }
            set { this._address1 = value; }
        }

        public String Address2
        {
            get { return this._address2; }
            set { this._address2 = value; }
        }

        public String Address3
        {
            get { return this._address3; }
            set { this._address3 = value; }
        }

        public OUT0101U02ImportPatientInfo() { }

        public OUT0101U02ImportPatientInfo(String sex, String bunho, String suname, String suname2, String birth, String zipCode, String tel, String bunhoType, String address1, String address2, String address3)
        {
            this._sex = sex;
            this._bunho = bunho;
            this._suname = suname;
            this._suname2 = suname2;
            this._birth = birth;
            this._zipCode = zipCode;
            this._tel = tel;
            this._bunhoType = bunhoType;
            this._address1 = address1;
            this._address2 = address2;
            this._address3 = address3;
        }

    }
}