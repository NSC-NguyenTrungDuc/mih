using System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Injs
{
    [Serializable]
    public class InjsINJ1001U01ReserDateListResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _reserDate = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> ReserDate
        {
            get { return this._reserDate; }
            set { this._reserDate = value; }
        }

        public InjsINJ1001U01ReserDateListResult() { }

    }
}