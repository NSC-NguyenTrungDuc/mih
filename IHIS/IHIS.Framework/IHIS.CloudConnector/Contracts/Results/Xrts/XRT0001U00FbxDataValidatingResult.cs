using System;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0001U00FbxDataValidatingResult : AbstractContractResult
    {
        private String _codeName;

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public XRT0001U00FbxDataValidatingResult() { }

    }
}