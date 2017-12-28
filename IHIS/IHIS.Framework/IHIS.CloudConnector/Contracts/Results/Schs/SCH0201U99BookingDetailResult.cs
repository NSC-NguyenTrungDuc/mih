using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class SCH0201U99BookingDetailResult : AbstractContractResult
    {
        private List<SCH0201U99BookingDetailInfo> _detailInfo = new List<SCH0201U99BookingDetailInfo>();

        public List<SCH0201U99BookingDetailInfo> DetailInfo
        {
            get { return this._detailInfo; }
            set { this._detailInfo = value; }
        }

        public SCH0201U99BookingDetailResult() { }

    }
}