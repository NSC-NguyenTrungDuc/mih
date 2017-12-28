using System;
using IHIS.CloudConnector.Contracts.Models.Pfes;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Pfes
{
    [Serializable]
    public class PFE7001Q01LayDailyReportResult : AbstractContractResult
    {
        private List<PFE7001Q01LayDailyReportInfo> _dailyReportItem = new List<PFE7001Q01LayDailyReportInfo>();

        public List<PFE7001Q01LayDailyReportInfo> DailyReportItem
        {
            get { return this._dailyReportItem; }
            set { this._dailyReportItem = value; }
        }

        public PFE7001Q01LayDailyReportResult() { }

    }
}