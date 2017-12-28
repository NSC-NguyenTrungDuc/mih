using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class GetORCAEnvResult : AbstractContractResult
    {
        private Boolean _isUsingOrca;
        private GetORCAEnvInfo _orcaInfo;

        public Boolean IsUsingOrca
        {
            get { return this._isUsingOrca; }
            set { this._isUsingOrca = value; }
        }

        public GetORCAEnvInfo OrcaInfo
        {
            get { return this._orcaInfo; }
            set { this._orcaInfo = value; }
        }

        public GetORCAEnvResult() { }

    }
}