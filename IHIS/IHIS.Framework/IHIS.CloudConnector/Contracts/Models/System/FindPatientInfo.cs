using System;
using System.Collections.Generic;
using System.Text;

namespace IHIS.CloudConnector.Contracts.Models.System
{
    [Serializable]
    public class FindPatientInfo
    {
        private String _patientCode;
        private String _patientName;
        private String _patientName2;
        private String _sex;
        private String _birth;
        private String _lastCommingDate;
        private String _address;
        private String _ipwonYn;
        private String _treatmentArea;
        private String _tel;

        public FindPatientInfo()
        {
        }

        public FindPatientInfo(string patientCode, string patientName, string patientName2, string sex, string birth, string lastCommingDate, string address, string ipwonYn, string treatmentArea, string tel)
        {
            _patientCode = patientCode;
            _patientName = patientName;
            _patientName2 = patientName2;
            _sex = sex;
            _birth = birth;
            _lastCommingDate = lastCommingDate;
            _address = address;
            _ipwonYn = ipwonYn;
            _treatmentArea = treatmentArea;
            _tel = tel;
        }

        public string PatientCode
        {
            get { return _patientCode; }
            set { _patientCode = value; }
        }

        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; }
        }

        public string PatientName2
        {
            get { return _patientName2; }
            set { _patientName2 = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public string Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        public string LastCommingDate
        {
            get { return _lastCommingDate; }
            set { _lastCommingDate = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string IpwonYn
        {
            get { return _ipwonYn; }
            set { _ipwonYn = value; }
        }

        public string TreatmentArea
        {
            get { return _treatmentArea; }
            set { _treatmentArea = value; }
        }

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
    }
}
