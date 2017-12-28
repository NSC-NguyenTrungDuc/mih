using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class BIL0102U00DataReportArgs : IContractArgs
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

        public BIL0102U00DataReportArgs() { }

        public BIL0102U00DataReportArgs(String invoiceNo, String parentInvoiceNo)
        {
            this._invoiceNo = invoiceNo;
            this._parentInvoiceNo = parentInvoiceNo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL0102U00DataReportRequest();
        }
    }
}