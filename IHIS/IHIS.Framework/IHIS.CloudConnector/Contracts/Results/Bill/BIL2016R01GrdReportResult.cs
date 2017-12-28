using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class BIL2016R01GrdReportResult : AbstractContractResult
    {
        private List<BIL2016R01GrdReportInfo> _grdList = new List<BIL2016R01GrdReportInfo>();
        private String _sumDiscount;
        private String _sumAmountPaid;

        public List<BIL2016R01GrdReportInfo> GrdList
        {
            get { return this._grdList; }
            set { this._grdList = value; }
        }

        public String SumDiscount
        {
            get { return this._sumDiscount; }
            set { this._sumDiscount = value; }
        }

        public String SumAmountPaid
        {
            get { return this._sumAmountPaid; }
            set { this._sumAmountPaid = value; }
        }

        public BIL2016R01GrdReportResult() { }

    }
}