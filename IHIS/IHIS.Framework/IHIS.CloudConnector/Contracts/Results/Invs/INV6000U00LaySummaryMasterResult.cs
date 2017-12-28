using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV6000U00LaySummaryMasterResult : AbstractContractResult
    {
        private List<INV6000U00LaySummaryMasterInfo> _laySummaryM = new List<INV6000U00LaySummaryMasterInfo>();

        public List<INV6000U00LaySummaryMasterInfo> LaySummaryM
        {
            get { return this._laySummaryM; }
            set { this._laySummaryM = value; }
        }

        public INV6000U00LaySummaryMasterResult() { }

    }
}