using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV6000U00LaySummaryDetailResult : AbstractContractResult
    {
        private List<INV6000U00LaySummaryDetailInfo> _laySummaryD = new List<INV6000U00LaySummaryDetailInfo>();

        public List<INV6000U00LaySummaryDetailInfo> LaySummaryD
        {
            get { return this._laySummaryD; }
            set { this._laySummaryD = value; }
        }

        public INV6000U00LaySummaryDetailResult() { }

    }
}