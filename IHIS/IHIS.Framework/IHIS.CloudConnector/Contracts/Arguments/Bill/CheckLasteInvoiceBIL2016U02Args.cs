using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class CheckLasteInvoiceBIL2016U02Args : IContractArgs
    {
        private String _parentInvoiceNo;

        public String ParentInvoiceNo
        {
            get { return this._parentInvoiceNo; }
            set { this._parentInvoiceNo = value; }
        }

        public CheckLasteInvoiceBIL2016U02Args() { }

        public CheckLasteInvoiceBIL2016U02Args(String parentInvoiceNo)
        {
            this._parentInvoiceNo = parentInvoiceNo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CheckLasteInvoiceBIL2016U02Request();
        }
    }
}