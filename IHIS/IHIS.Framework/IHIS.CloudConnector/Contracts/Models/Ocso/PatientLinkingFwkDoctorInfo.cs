using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class PatientLinkingFwkDoctorInfo
    {
        private String _doctorCode;
        private String _doctorName;

        public String DoctorCode
        {
            get { return this._doctorCode; }
            set { this._doctorCode = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public PatientLinkingFwkDoctorInfo() { }

        public PatientLinkingFwkDoctorInfo(String doctorCode, String doctorName)
        {
            this._doctorCode = doctorCode;
            this._doctorName = doctorName;
        }

    }
}