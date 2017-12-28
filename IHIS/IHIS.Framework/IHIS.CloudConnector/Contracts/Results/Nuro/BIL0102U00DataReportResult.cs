using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class BIL0102U00DataReportResult : AbstractContractResult
    {
        private List<BIL0102U00DataReportInfo> _invoiceDetail = new List<BIL0102U00DataReportInfo>();
        private String _sumAmountInvoice;
        private String _paidInvoice;
        private String _totalPaid;
        private String _totalDebt;

        public List<BIL0102U00DataReportInfo> InvoiceDetail
        {
            get { return this._invoiceDetail; }
            set { this._invoiceDetail = value; }
        }

        public String SumAmountInvoice
        {
            get { return this._sumAmountInvoice; }
            set { this._sumAmountInvoice = value; }
        }

        public String PaidInvoice
        {
            get { return this._paidInvoice; }
            set { this._paidInvoice = value; }
        }

        public String TotalPaid
        {
            get { return this._totalPaid; }
            set { this._totalPaid = value; }
        }

        public String TotalDebt
        {
            get { return this._totalDebt; }
            set { this._totalDebt = value; }
        }

        public BIL0102U00DataReportResult() { }

    }
}