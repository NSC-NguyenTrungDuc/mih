using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuri
{
    [Serializable]
    public class NUR1016U00PrNurAlergyMappingResult : AbstractContractResult
    {
        private Boolean _saveLayoutResult;
        private String _prResult;

        public Boolean SaveLayoutResult
        {
            get { return this._saveLayoutResult; }
            set { this._saveLayoutResult = value; }
        }

        public String PrResult
        {
            get { return this._prResult; }
            set { this._prResult = value; }
        }

        public NUR1016U00PrNurAlergyMappingResult() { }

    }
}