using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3010U01SearchMaxResult : AbstractContractResult
    {
        private List<CPL3010U01SearchMaxInfo> _searchMaxLst = new List<CPL3010U01SearchMaxInfo>();

        public List<CPL3010U01SearchMaxInfo> SearchMaxLst
        {
            get { return this._searchMaxLst; }
            set { this._searchMaxLst = value; }
        }

        public CPL3010U01SearchMaxResult() { }

    }
}