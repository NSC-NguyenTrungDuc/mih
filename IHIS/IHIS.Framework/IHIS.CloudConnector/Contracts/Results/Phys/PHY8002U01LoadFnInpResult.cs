using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY8002U01LoadFnInpResult : AbstractContractResult
    {
        private String _valueJaewon;
        private String _valueLast;

        public String ValueJaewon
        {
            get { return this._valueJaewon; }
            set { this._valueJaewon = value; }
        }

        public String ValueLast
        {
            get { return this._valueLast; }
            set { this._valueLast = value; }
        }

        public PHY8002U01LoadFnInpResult() { }

    }
}