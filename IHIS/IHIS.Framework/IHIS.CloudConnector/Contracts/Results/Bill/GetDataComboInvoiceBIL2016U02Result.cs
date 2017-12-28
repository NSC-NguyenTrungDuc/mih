using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class GetDataComboInvoiceBIL2016U02Result : AbstractContractResult
    {
        private List<GetDataComboInvoiceBIL2016U02Info> _comboInvoice = new List<GetDataComboInvoiceBIL2016U02Info>();

        public List<GetDataComboInvoiceBIL2016U02Info> ComboInvoice
        {
            get { return this._comboInvoice; }
            set { this._comboInvoice = value; }
        }

        public GetDataComboInvoiceBIL2016U02Result() { }

    }
}