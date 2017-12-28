using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
    public class NuroCheckBookingInfo
    {
        private String _patientCode;
        private String _reserData;

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String ReserData
        {
            get { return this._reserData; }
            set { this._reserData = value; }
        }

        public NuroCheckBookingInfo() { }

        public NuroCheckBookingInfo(String patientCode, String reserData)
        {
            this._patientCode = patientCode;
            this._reserData = reserData;
        }

    }
}
