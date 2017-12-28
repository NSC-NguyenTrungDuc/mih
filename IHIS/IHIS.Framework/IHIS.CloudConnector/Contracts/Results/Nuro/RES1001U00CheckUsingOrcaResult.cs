using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class RES1001U00CheckUsingOrcaResult : AbstractContractResult
    {
        private String _accType;
        private String _orcaIp;
        private String _orcaUser;
        private String _orcaPassword;

        public String AccType
        {
            get { return this._accType; }
            set { this._accType = value; }
        }

        public String OrcaIp
        {
            get { return this._orcaIp; }
            set { this._orcaIp = value; }
        }

        public String OrcaUser
        {
            get { return this._orcaUser; }
            set { this._orcaUser = value; }
        }

        public String OrcaPassword
        {
            get { return this._orcaPassword; }
            set { this._orcaPassword = value; }
        }

        public RES1001U00CheckUsingOrcaResult() { }

    }
}