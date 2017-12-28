using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroManagePatientInfo
    {
        private string _patientCode;
        private string _patientName1;
        private string _patientName2;
        private string _birth;
        private string _sex;
        private string _zipCode1;
        private string _zipCode2;
        private string _address1;
        private string _address2;
        private string _tel;
        private string _tel1;
        private string _telHp;
        private string _telType;
        private string _telType2;
        private string _telType3;
        private string _eMail;
        private string _paceMakerYn;
        private string _selfPaceMaker;

        public NuroManagePatientInfo()
        {
        }

        public NuroManagePatientInfo(string patientCode, string patientName1, string patientName2, string birth, string sex, string zipCode1, string zipCode2, string address1, string address2, string tel, string tel1, string telHp, string telType, string telType2, string telType3, string eMail, string paceMakerYn, string selfPaceMaker)
        {
            _patientCode = patientCode;
            _patientName1 = patientName1;
            _patientName2 = patientName2;
            _birth = birth;
            _sex = sex;
            _zipCode1 = zipCode1;
            _zipCode2 = zipCode2;
            _address1 = address1;
            _address2 = address2;
            _tel = tel;
            _tel1 = tel1;
            _telHp = telHp;
            _telType = telType;
            _telType2 = telType2;
            _telType3 = telType3;
            _eMail = eMail;
            _paceMakerYn = paceMakerYn;
            _selfPaceMaker = selfPaceMaker;
        }

        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }

        public string PatientName1
        {
            get { return _patientName1; }
            set { _patientName1 = value; }
        }

        public string PatientName2
        {
            get { return _patientName2; }
            set { _patientName2 = value; }
        }

        public string Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public string ZipCode1
        {
            get { return _zipCode1; }
            set { _zipCode1 = value; }
        }

        public string ZipCode2
        {
            get { return _zipCode2; }
            set { _zipCode2 = value; }
        }

        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public string Tel1
        {
            get { return _tel1; }
            set { _tel1 = value; }
        }

        public string TelHp
        {
            get { return _telHp; }
            set { _telHp = value; }
        }

        public string TelType
        {
            get { return _telType; }
            set { _telType = value; }
        }

        public string TelType2
        {
            get { return _telType2; }
            set { _telType2 = value; }
        }

        public string TelType3
        {
            get { return _telType3; }
            set { _telType3 = value; }
        }

        public string EMail
        {
            get { return _eMail; }
            set { _eMail = value; }
        }

        public string PaceMakerYn
        {
            get { return _paceMakerYn; }
            set { _paceMakerYn = value; }
        }

        public string SelfPaceMaker
        {
            get { return _selfPaceMaker; }
            set { _selfPaceMaker = value; }
        }
    }
}
