namespace EmrDocker.Models
{
    using System;

    public class PatientModelInfo
    {
        private string patientId;

        private string patientName;

        private string patientKanaName;

        private string patientBirthday;

        private string patientGender;

        private string patientAddress;

        private string patientZip;

        private string patientTelephone;

        private string gwa;

        private string naewonDate;

        private string patientEmail;

        public PatientModelInfo()
        {
        }

        public PatientModelInfo(string patientId, string patientName, string patientKanaName, string patientBirthday, string patientGender, string patientAddress, string patientZip, string patientTelephone)
        {
            this.patientId = patientId;
            this.patientName = patientName;
            this.patientKanaName = patientKanaName;
            this.patientBirthday = patientBirthday;
            this.patientGender = patientGender;
            this.patientAddress = patientAddress;
            this.patientZip = patientZip;
            this.patientTelephone = patientTelephone;
        }

        public string PatientEmail
        {
            get
            {
                return patientEmail;
            }
            set
            {
                patientEmail = value;
            }
        }

        public string PatientId
        {
            get
            {
                return patientId;
            }
            set
            {
                patientId = value;
            }
        }

        public string PatientName
        {
            get
            {
                return patientName;
            }
            set
            {
                patientName = value;
            }
        }

        public string PatientKanaName
        {
            get
            {
                return patientKanaName;
            }
            set
            {
                patientKanaName = value;
            }
        }

        public string PatientBirthday
        {
            get
            {
                return patientBirthday;
            }
            set
            {
                patientBirthday = value;
            }
        }

        public string PatientGender
        {
            get
            {
                return patientGender;
            }
            set
            {
                patientGender = value;
            }
        }

        public string PatientAddress
        {
            get
            {
                return patientAddress;
            }
            set
            {
                patientAddress = value;
            }
        }

        public string PatientZip
        {
            get
            {
                return patientZip;
            }
            set
            {
                patientZip = value;
            }
        }

        public string PatientTelephone
        {
            get
            {
                return patientTelephone;
            }
            set
            {
                patientTelephone = value;
            }
        }

        public string Gwa
        {
            get
            {
                return gwa;
            }
            set
            {
                gwa = value;
            }
        }

        public string NaewonDate
        {
            get
            {
                return naewonDate;
            }
            set
            {
                naewonDate = value;
            }
        }
        
    }
}