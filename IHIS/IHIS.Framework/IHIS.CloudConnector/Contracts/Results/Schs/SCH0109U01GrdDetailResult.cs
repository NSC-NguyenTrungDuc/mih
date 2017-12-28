using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class SCH0109U01GrdDetailResult : AbstractContractResult
    {
        private List<SCH0109U01GrdDetailInfo> _grdDetailItem = new List<SCH0109U01GrdDetailInfo>();

        public List<SCH0109U01GrdDetailInfo> GrdDetailItem
        {
            get { return this._grdDetailItem; }
            set { this._grdDetailItem = value; }
        }

        public SCH0109U01GrdDetailResult() { }

    }
}