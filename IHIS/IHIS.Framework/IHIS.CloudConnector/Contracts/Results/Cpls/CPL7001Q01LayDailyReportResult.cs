using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL7001Q01LayDailyReportResult : AbstractContractResult
    {
        private List<CPL7001Q01LayDailyReportInfo> _listIem = new List<CPL7001Q01LayDailyReportInfo>();

        public List<CPL7001Q01LayDailyReportInfo> ListIem
        {
            get { return this._listIem; }
            set { this._listIem = value; }
        }

        public CPL7001Q01LayDailyReportResult() { }

    }
}