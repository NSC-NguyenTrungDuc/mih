using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0270U00FwdDoctorInfo
    {
        private String _doctor;
        private String _doctorName;
        private String _doctorGwa;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String DoctorGwa
        {
            get { return this._doctorGwa; }
            set { this._doctorGwa = value; }
        }

        public BAS0270U00FwdDoctorInfo() { }

        public BAS0270U00FwdDoctorInfo(String doctor, String doctorName, String doctorGwa)
        {
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._doctorGwa = doctorGwa;
        }

    }
}