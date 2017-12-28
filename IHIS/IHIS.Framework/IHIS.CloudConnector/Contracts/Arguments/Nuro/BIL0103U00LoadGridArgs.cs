using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class BIL0103U00LoadGridArgs : IContractArgs
    {
        private String _invoiceNo;
        private String _refId;
        private String _bunho;
        private String _pkbil0103;

        public String InvoiceNo
        {
            get { return this._invoiceNo; }
            set { this._invoiceNo = value; }
        }

        public String RefId
        {
            get { return this._refId; }
            set { this._refId = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkbil0103
        {
            get { return this._pkbil0103; }
            set { this._pkbil0103 = value; }
        }

        public BIL0103U00LoadGridArgs() { }

        public BIL0103U00LoadGridArgs(String invoiceNo, String refId, String bunho, String pkbil0103)
        {
            this._invoiceNo = invoiceNo;
            this._refId = refId;
            this._bunho = bunho;
            this._pkbil0103 = pkbil0103;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL0103U00LoadGridRequest();
        }
    }
}