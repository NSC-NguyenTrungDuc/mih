using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class LoadGridPayHistoryBIL2016U02Result : AbstractContractResult
    {
        private List<LoadGridPayHistoryBIL2016U02Info> _grdPayHistory = new List<LoadGridPayHistoryBIL2016U02Info>();

        public List<LoadGridPayHistoryBIL2016U02Info> GrdPayHistory
        {
            get { return this._grdPayHistory; }
            set { this._grdPayHistory = value; }
        }

        public LoadGridPayHistoryBIL2016U02Result() { }

    }
}