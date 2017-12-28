using System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0801U00GetCodeNameResult : AbstractContractResult
    {
        private String _codeName;

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public OCS0801U00GetCodeNameResult() { }

    }
}