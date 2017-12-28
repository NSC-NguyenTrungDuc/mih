namespace EmrDocker.Models
{
    using System;

    public class HospitalModelInfo
    {
        private string hospName;

        private string doctorRequest;

        private string hospAddress;

        private string hospTel;

        private string hospFax;

        public string HospName
        {
            get { return hospName; }
            set { hospName = value; }
        }

        public string DoctorRequest
        {
            get { return doctorRequest; }
            set { doctorRequest = value; }
        }

        public string HospAddress
        {
            get { return hospAddress; }
            set { hospAddress = value; }
        }

        public string HospTel
        {
            get { return hospTel; }
            set { hospTel = value; }
        }

        public string HospFax
        {
            get { return hospFax; }
            set { hospFax = value; }
        }

        public HospitalModelInfo()
        {
        }


        public HospitalModelInfo(string hospName, string doctorRequest, string hospAddress, string hospTel, string hospFax)
        {
            this.hospName = hospName;
            this.doctorRequest = doctorRequest;
            this.hospAddress = hospAddress;
            this.hospTel = hospTel;
            this.hospFax = hospFax;
        }
    }
}