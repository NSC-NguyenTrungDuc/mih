using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class BIL2016R01FbxPersonValidatingResult : AbstractContractResult
    {
        private String _codeName;

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public BIL2016R01FbxPersonValidatingResult() { }

    }
}