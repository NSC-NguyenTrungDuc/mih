using System;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    public class PatientInfo
    {
        private String _patientName1;
        private String _patientName2;
        private String _sex;
        private String _yearAge;
        private String _monthAge;
        private String _type;
        private String _codeNm;
        private String _birth;
        private String _tel;
        private String _tel1;
        private String _telHp;
        private String _email;
        private String _zipCode1;
        private String _zipCode2;
        private String _address1;
        private String _address2;
        private String _telGubun1;
        private String _telGubun2;
        private String _telGubun3;
        private String _pwd;

        public String PatientName1
        {
            get { return this._patientName1; }
            set { this._patientName1 = value; }
        }

        public String PatientName2
        {
            get { return this._patientName2; }
            set { this._patientName2 = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String YearAge
        {
            get { return this._yearAge; }
            set { this._yearAge = value; }
        }

        public String MonthAge
        {
            get { return this._monthAge; }
            set { this._monthAge = value; }
        }

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String CodeNm
        {
            get { return this._codeNm; }
            set { this._codeNm = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String Tel1
        {
            get { return this._tel1; }
            set { this._tel1 = value; }
        }

        public String TelHp
        {
            get { return this._telHp; }
            set { this._telHp = value; }
        }

        public String Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public String ZipCode1
        {
            get { return this._zipCode1; }
            set { this._zipCode1 = value; }
        }

        public String ZipCode2
        {
            get { return this._zipCode2; }
            set { this._zipCode2 = value; }
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

        public String TelGubun1
        {
            get { return this._telGubun1; }
            set { this._telGubun1 = value; }
        }

        public String TelGubun2
        {
            get { return this._telGubun2; }
            set { this._telGubun2 = value; }
        }

        public String TelGubun3
        {
            get { return this._telGubun3; }
            set { this._telGubun3 = value; }
        }

        public String Pwd
        {
            get { return this._pwd; }
            set { this._pwd = value; }
        }

        public PatientInfo() { }

        public PatientInfo(String patientName1, String patientName2, String sex, String yearAge, String monthAge, String type, String codeNm, String birth, String tel, String tel1, String telHp, String email, String zipCode1, String zipCode2, String address1, String address2, String telGubun1, String telGubun2, String telGubun3, String pwd)
        {
            this._patientName1 = patientName1;
            this._patientName2 = patientName2;
            this._sex = sex;
            this._yearAge = yearAge;
            this._monthAge = monthAge;
            this._type = type;
            this._codeNm = codeNm;
            this._birth = birth;
            this._tel = tel;
            this._tel1 = tel1;
            this._telHp = telHp;
            this._email = email;
            this._zipCode1 = zipCode1;
            this._zipCode2 = zipCode2;
            this._address1 = address1;
            this._address2 = address2;
            this._telGubun1 = telGubun1;
            this._telGubun2 = telGubun2;
            this._telGubun3 = telGubun3;
            this._pwd = pwd;
        }

    }
}