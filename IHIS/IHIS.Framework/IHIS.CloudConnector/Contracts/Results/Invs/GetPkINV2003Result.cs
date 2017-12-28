using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class GetPkINV2003Result : AbstractContractResult
    {
        private String _pkinv2003;

        public String Pkinv2003
        {
            get { return this._pkinv2003; }
            set { this._pkinv2003 = value; }
        }

        public GetPkINV2003Result() { }

    }
}