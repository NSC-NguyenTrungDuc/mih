using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class CheckLasteInvoiceBIL2016U02Info
    {
        private String _latestInvoice;

        public String LatestInvoice
        {
            get { return this._latestInvoice; }
            set { this._latestInvoice = value; }
        }

        public CheckLasteInvoiceBIL2016U02Info() { }

        public CheckLasteInvoiceBIL2016U02Info(String latestInvoice)
        {
            this._latestInvoice = latestInvoice;
        }

    }
}