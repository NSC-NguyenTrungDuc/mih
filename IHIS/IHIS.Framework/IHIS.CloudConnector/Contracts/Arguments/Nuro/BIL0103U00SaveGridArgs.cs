using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class BIL0103U00SaveGridArgs : IContractArgs
    {
        private String _comment;
        private String _transStatus;
        private String _refId;
        private String _pkbil0103;
        private String _bunho;
        private String _invoiceNo;

        public String Comment
        {
            get { return this._comment; }
            set { this._comment = value; }
        }

        public String TransStatus
        {
            get { return this._transStatus; }
            set { this._transStatus = value; }
        }

        public String RefId
        {
            get { return this._refId; }
            set { this._refId = value; }
        }

        public String Pkbil0103
        {
            get { return this._pkbil0103; }
            set { this._pkbil0103 = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String InvoiceNo
        {
            get { return this._invoiceNo; }
            set { this._invoiceNo = value; }
        }

        public BIL0103U00SaveGridArgs() { }

        public BIL0103U00SaveGridArgs(String comment, String transStatus, String refId, String pkbil0103, String bunho, String invoiceNo)
        {
            this._comment = comment;
            this._transStatus = transStatus;
            this._refId = refId;
            this._pkbil0103 = pkbil0103;
            this._bunho = bunho;
            this._invoiceNo = invoiceNo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL0103U00SaveGridRequest();
        }
    }
}