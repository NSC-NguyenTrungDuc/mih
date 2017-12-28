using System;

namespace IHIS.CloudConnector.Contracts.Models.Orca
{
    [Serializable]
    public class PatientInformation
    {
        private string _patientId;
        private string _wholeName;
        private string _wholeNameInKana;
        private string _birthDate;
        private string _sex;

        public PatientInformation()
        {
        }

        public PatientInformation(string patientId, string wholeName, string wholeNameInKana, string birthDate, string sex)
        {
            _patientId = patientId;
            _wholeName = wholeName;
            _wholeNameInKana = wholeNameInKana;
            _birthDate = birthDate;
            _sex = sex;
        }

        public string PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }

        public string WholeName
        {
            get { return _wholeName; }
            set { _wholeName = value; }
        }

        public string WholeNameInKana
        {
            get { return _wholeNameInKana; }
            set { _wholeNameInKana = value; }
        }

        public string BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
    }
}