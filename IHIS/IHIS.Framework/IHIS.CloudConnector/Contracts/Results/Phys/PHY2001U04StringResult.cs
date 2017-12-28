using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04StringResult : AbstractContractResult
    {
        private String _resStr;

        public String ResStr
        {
            get { return this._resStr; }
            set { this._resStr = value; }
        }

        public PHY2001U04StringResult() { }

    }
}