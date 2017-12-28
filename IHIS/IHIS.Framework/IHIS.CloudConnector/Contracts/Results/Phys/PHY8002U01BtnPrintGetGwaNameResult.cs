using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY8002U01BtnPrintGetGwaNameResult : AbstractContractResult
    {
        private String _gwaName;

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public PHY8002U01BtnPrintGetGwaNameResult() { }

    }
}