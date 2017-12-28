using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    public class OCS0103U00GetCommonYnResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _commonYnList = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> CommonYnList
        {
            get { return this._commonYnList; }
            set { this._commonYnList = value; }
        }

        public OCS0103U00GetCommonYnResult() { }

    }
}