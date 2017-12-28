using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class NuroOUT0101U02GridPatientInfo
    {
        private String _bunho;
        private String _suname;
        private String _sex;
        private String _birth;
        private String _zipCode1;
        private String _zipCode2;
        private String _address1;
        private String _address2;
        private String _tel;
        private String _tel1;
        private String _type;
        private String _telHp;
        private String _email;
        private String _gubunName;
        private String _dongName;
        private String _suname2;
        private String _age;
        private String _telType;
        private String _telType2;
        private String _telType3;
        private String _deleteYn;
        private String _paceMakerYn;
        private String _selfPaceMaker;
        private String _patientType;
        private String _retrieveYn;
        private String _iuGubun;
        private String _refId;
        private String _pass;
        private String _parentCode;
        private String _billingType;
        private String _autoRecept;

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

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
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

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
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

        public String GubunName
        {
            get { return this._gubunName; }
            set { this._gubunName = value; }
        }

        public String DongName
        {
            get { return this._dongName; }
            set { this._dongName = value; }
        }

        public String Suname2
        {
            get { return this._suname2; }
            set { this._suname2 = value; }
        }

        public String Age
        {
            get { return this._age; }
            set { this._age = value; }
        }

        public String TelType
        {
            get { return this._telType; }
            set { this._telType = value; }
        }

        public String TelType2
        {
            get { return this._telType2; }
            set { this._telType2 = value; }
        }

        public String TelType3
        {
            get { return this._telType3; }
            set { this._telType3 = value; }
        }

        public String DeleteYn
        {
            get { return this._deleteYn; }
            set { this._deleteYn = value; }
        }

        public String PaceMakerYn
        {
            get { return this._paceMakerYn; }
            set { this._paceMakerYn = value; }
        }

        public String SelfPaceMaker
        {
            get { return this._selfPaceMaker; }
            set { this._selfPaceMaker = value; }
        }

        public String PatientType
        {
            get { return this._patientType; }
            set { this._patientType = value; }
        }

        public String RetrieveYn
        {
            get { return this._retrieveYn; }
            set { this._retrieveYn = value; }
        }

        public String IuGubun
        {
            get { return this._iuGubun; }
            set { this._iuGubun = value; }
        }

        public String RefId
        {
            get { return this._refId; }
            set { this._refId = value; }
        }

        public String Pass
        {
            get { return this._pass; }
            set { this._pass = value; }
        }

        public String ParentCode
        {
            get { return this._parentCode; }
            set { this._parentCode = value; }
        }

        public String BillingType
        {
            get { return this._billingType; }
            set { this._billingType = value; }
        }

        public String AutoRecept
        {
            get { return this._autoRecept; }
            set { this._autoRecept = value; }
        }

        public NuroOUT0101U02GridPatientInfo() { }

        public NuroOUT0101U02GridPatientInfo(String bunho, String suname, String sex, String birth, String zipCode1, String zipCode2, String address1, String address2, String tel, String tel1, String type, String telHp, String email, String gubunName, String dongName, String suname2, String age, String telType, String telType2, String telType3, String deleteYn, String paceMakerYn, String selfPaceMaker, String patientType, String retrieveYn, String iuGubun, String refId, String pass, String parentCode, String billingType, String autoRecept)
        {
            this._bunho = bunho;
            this._suname = suname;
            this._sex = sex;
            this._birth = birth;
            this._zipCode1 = zipCode1;
            this._zipCode2 = zipCode2;
            this._address1 = address1;
            this._address2 = address2;
            this._tel = tel;
            this._tel1 = tel1;
            this._type = type;
            this._telHp = telHp;
            this._email = email;
            this._gubunName = gubunName;
            this._dongName = dongName;
            this._suname2 = suname2;
            this._age = age;
            this._telType = telType;
            this._telType2 = telType2;
            this._telType3 = telType3;
            this._deleteYn = deleteYn;
            this._paceMakerYn = paceMakerYn;
            this._selfPaceMaker = selfPaceMaker;
            this._patientType = patientType;
            this._retrieveYn = retrieveYn;
            this._iuGubun = iuGubun;
            this._refId = refId;
            this._pass = pass;
            this._parentCode = parentCode;
            this._billingType = billingType;
            this._autoRecept = autoRecept;
        }

    }
}