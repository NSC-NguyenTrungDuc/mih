using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0503U00GetFindWorkerConsultGwaInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _doctor;
        private String _doctorName;
        private String _ampm;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

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

        public String Ampm
        {
            get { return this._ampm; }
            set { this._ampm = value; }
        }

        public OCS0503U00GetFindWorkerConsultGwaInfo() { }

        public OCS0503U00GetFindWorkerConsultGwaInfo(String hangmogCode, String hangmogName, String doctor, String doctorName, String ampm)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._doctor = doctor;
            this._doctorName = doctorName;
            this._ampm = ampm;
        }

    }
}