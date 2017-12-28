using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
    public class INJ0102CodeNameListResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _codeNameList = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> CodeNameList
        {
            get { return this._codeNameList; }
            set { this._codeNameList = value; }
        }

        public INJ0102CodeNameListResult() { }

    }
}