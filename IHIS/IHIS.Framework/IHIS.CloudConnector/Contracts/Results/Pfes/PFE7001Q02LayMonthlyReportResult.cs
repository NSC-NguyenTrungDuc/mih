using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Pfes
{
    [Serializable]
    public class PFE7001Q02LayMonthlyReportResult : AbstractContractResult
    {
        private List<PFE7001Q02LayMonthlyReportInfo> _monthlyReportItem = new List<PFE7001Q02LayMonthlyReportInfo>();

        public List<PFE7001Q02LayMonthlyReportInfo> MonthlyReportItem
        {
            get { return this._monthlyReportItem; }
            set { this._monthlyReportItem = value; }
        }

        public PFE7001Q02LayMonthlyReportResult() { }

    }
}