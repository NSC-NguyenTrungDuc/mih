using System;

namespace IHIS.CloudConnector.Contracts.Results.NURO
{
    [Serializable]
    public class NuroOUT0101U02GetInsuranceNameResult : AbstractContractResult
    {
        private String _gongbiName;

        public String GongbiName
        {
            get { return this._gongbiName; }
            set { this._gongbiName = value; }
        }

        public NuroOUT0101U02GetInsuranceNameResult() { }

    }
}