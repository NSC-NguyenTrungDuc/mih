using System;

namespace IHIS.CloudConnector.Contracts.Models.Clis
{
    [Serializable]
    public class CLIS2015U03CheckPatientRequestInfo
    {
        private String _bunho;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public CLIS2015U03CheckPatientRequestInfo() { }

        public CLIS2015U03CheckPatientRequestInfo(String bunho)
        {
            this._bunho = bunho;
        }

    }
}