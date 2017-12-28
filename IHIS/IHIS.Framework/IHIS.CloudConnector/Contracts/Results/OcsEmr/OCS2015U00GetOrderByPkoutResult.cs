using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U00GetOrderByPkoutResult : AbstractContractResult
    {
        private List<OCS2015U00GetOrderReportInfo> _orderReportInfo = new List<OCS2015U00GetOrderReportInfo>();

        public List<OCS2015U00GetOrderReportInfo> OrderReportInfo
        {
            get { return this._orderReportInfo; }
            set { this._orderReportInfo = value; }
        }

        public OCS2015U00GetOrderByPkoutResult() { }

    }
}