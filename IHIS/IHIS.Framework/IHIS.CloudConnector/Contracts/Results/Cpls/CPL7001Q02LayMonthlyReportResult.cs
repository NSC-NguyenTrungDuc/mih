using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL7001Q02LayMonthlyReportResult : AbstractContractResult
    {
        private List<CPL7001Q02LayMonthlyReportInfo> _listItem = new List<CPL7001Q02LayMonthlyReportInfo>();

        public List<CPL7001Q02LayMonthlyReportInfo> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public CPL7001Q02LayMonthlyReportResult() { }

    }
}