using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class PrintDataComboInvoiceArgs : IContractArgs
    {
        private String _invoiceNo;
        private String _parentInvoiceNo;

        public String InvoiceNo
        {
            get { return this._invoiceNo; }
            set { this._invoiceNo = value; }
        }

        public String ParentInvoiceNo
        {
            get { return this._parentInvoiceNo; }
            set { this._parentInvoiceNo = value; }
        }

        public PrintDataComboInvoiceArgs() { }

        public PrintDataComboInvoiceArgs(String invoiceNo, String parentInvoiceNo)
        {
            this._invoiceNo = invoiceNo;
            this._parentInvoiceNo = parentInvoiceNo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PrintDataComboInvoiceRequest();
        }
    }
}