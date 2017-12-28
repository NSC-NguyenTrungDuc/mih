using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroManagePatientUpdateData
    {
        private string _zipCode1;
        private string _zipCode2;
        private string _address1;
        private string _address2;
        private string _tel;
        private string _tel1;
        private string _telHp;
        private string _telGubun;
        private string _telGubun2;
        private string _telGubun3;
        private string _eMail;
        private string _paceMakerYn;
        private string _selfPaceMaker;
        private string _patientCode;

        public NuroManagePatientUpdateData()
        {
        }

        public NuroManagePatientUpdateData(string zipCode1, string zipCode2, string address1, string address2, string tel, string tel1, string telHp, string telGubun, string telGubun2, string telGubun3, string eMail, string paceMakerYn, string selfPaceMaker, string patientCode)
        {
            _zipCode1 = zipCode1;
            _zipCode2 = zipCode2;
            _address1 = address1;
            _address2 = address2;
            _tel = tel;
            _tel1 = tel1;
            _telHp = telHp;
            _telGubun = telGubun;
            _telGubun2 = telGubun2;
            _telGubun3 = telGubun3;
            _eMail = eMail;
            _paceMakerYn = paceMakerYn;
            _selfPaceMaker = selfPaceMaker;
            _patientCode = patientCode;
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

        public string TelGubun
        {
            get { return _telGubun; }
            set { _telGubun = value; }
        }

        public string TelGubun2
        {
            get { return _telGubun2; }
            set { _telGubun2 = value; }
        }

        public string TelGubun3
        {
            get { return _telGubun3; }
            set { _telGubun3 = value; }
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

        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }
    }
}
