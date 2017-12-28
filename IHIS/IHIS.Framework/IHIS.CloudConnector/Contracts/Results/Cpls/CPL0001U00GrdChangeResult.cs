using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0001U00GrdChangeResult : AbstractContractResult
    {
        private String _y;

        public String Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        public CPL0001U00GrdChangeResult() { }

    }
}