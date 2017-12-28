using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class CheckNewMstDataResult : AbstractContractResult
    {
        private List<NewMstDataListInfo> _listData = new List<NewMstDataListInfo>();

        public List<NewMstDataListInfo> ListData
        {
            get { return this._listData; }
            set { this._listData = value; }
        }

        public CheckNewMstDataResult() { }

    }
}