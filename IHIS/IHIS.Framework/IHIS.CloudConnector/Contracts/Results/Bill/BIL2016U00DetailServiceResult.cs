using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class BIL2016U00DetailServiceResult : AbstractContractResult
    {
        private BIL2016U00DetailServiceInfo _info;

        public BIL2016U00DetailServiceInfo Info
        {
            get { return this._info; }
            set { this._info = value; }
        }

        public BIL2016U00DetailServiceResult() { }

    }
}