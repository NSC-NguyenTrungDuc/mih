using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class BIL2016U00GrdMasterResult : AbstractContractResult
    {
        private List<BIL2016U00ServiceInfo> _listInfo = new List<BIL2016U00ServiceInfo>();

        public List<BIL2016U00ServiceInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public BIL2016U00GrdMasterResult() { }

    }
}