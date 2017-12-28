using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANInsertOcsTempResult : AbstractContractResult
    {
        private String _outputList0;
        private String _outputList1;

        public String OutputList0
        {
            get { return this._outputList0; }
            set { this._outputList0 = value; }
        }

        public String OutputList1
        {
            get { return this._outputList1; }
            set { this._outputList1 = value; }
        }

        public ORDERTRANInsertOcsTempResult() { }

    }
}