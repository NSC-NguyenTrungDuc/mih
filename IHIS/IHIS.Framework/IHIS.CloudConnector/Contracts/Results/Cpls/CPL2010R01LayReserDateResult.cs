using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010R01LayReserDateResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _layList = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> LayList
        {
            get { return this._layList; }
            set { this._layList = value; }
        }

        public CPL2010R01LayReserDateResult() { }

    }
}