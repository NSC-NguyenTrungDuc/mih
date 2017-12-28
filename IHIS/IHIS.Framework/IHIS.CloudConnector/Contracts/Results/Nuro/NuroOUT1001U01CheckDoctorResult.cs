using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01CheckDoctorResult : AbstractContractResult
    {
        private String _doctor;

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public NuroOUT1001U01CheckDoctorResult() { }

    }
}
