using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class LinkEMRPatientInfo
    {
        private String _patientId;
        private String _bunho;

        public String PatientId
        {
            get { return this._patientId; }
            set { this._patientId = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public LinkEMRPatientInfo() { }

        public LinkEMRPatientInfo(String patientId, String bunho)
        {
            this._patientId = patientId;
            this._bunho = bunho;
        }

    }
}