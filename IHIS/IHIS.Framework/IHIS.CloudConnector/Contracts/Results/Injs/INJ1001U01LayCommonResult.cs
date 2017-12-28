using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
    public class INJ1001U01LayCommonResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _userNm = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> UserNm
        {
            get { return this._userNm; }
            set { this._userNm = value; }
        }

        public INJ1001U01LayCommonResult() { }

    }
}