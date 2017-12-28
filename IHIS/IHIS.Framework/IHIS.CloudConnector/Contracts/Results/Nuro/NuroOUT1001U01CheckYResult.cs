using System;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NuroOUT1001U01CheckYResult : AbstractContractResult
    {
        private String _yValue;

        public String YValue
        {
            get { return this._yValue; }
            set { this._yValue = value; }
        }

        public NuroOUT1001U01CheckYResult() { }

    }
}
