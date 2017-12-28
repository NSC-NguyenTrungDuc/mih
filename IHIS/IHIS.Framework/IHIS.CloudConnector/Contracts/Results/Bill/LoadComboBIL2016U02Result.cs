using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class LoadComboBIL2016U02Result : AbstractContractResult
    {
        private List<LoadComboBIL2016U02Info> _listInfo = new List<LoadComboBIL2016U02Info>();

        public List<LoadComboBIL2016U02Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public LoadComboBIL2016U02Result() { }

    }
}