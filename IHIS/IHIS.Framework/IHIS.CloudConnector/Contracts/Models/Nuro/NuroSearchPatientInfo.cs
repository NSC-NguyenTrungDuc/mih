using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroSearchPatientInfo
    {
        private string _birth;
        private string _patientName1;
        private string _patientName2;

        public NuroSearchPatientInfo()
        {
            
        }

        public NuroSearchPatientInfo(string birth, string patientName1, string patientName2)
        {
            _birth = birth;
            _patientName1 = patientName1;
            _patientName2 = patientName2;
        }

        public string Birth
        {
            get { return _birth; }
            set { _birth = value; }
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
    }
}