using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANOcs1003UpdateResult : AbstractContractResult
    {
        private String _pkout1003;

        public String Pkout1003
        {
            get { return this._pkout1003; }
            set { this._pkout1003 = value; }
        }

        public ORDERTRANOcs1003UpdateResult() { }

    }
}