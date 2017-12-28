using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class CheckLasteInvoiceBIL2016U02Result : AbstractContractResult
    {
        private List<CheckLasteInvoiceBIL2016U02Info> _checkLasteInvoice = new List<CheckLasteInvoiceBIL2016U02Info>();

        public List<CheckLasteInvoiceBIL2016U02Info> CheckLasteInvoice
        {
            get { return this._checkLasteInvoice; }
            set { this._checkLasteInvoice = value; }
        }

        public CheckLasteInvoiceBIL2016U02Result() { }

    }
}