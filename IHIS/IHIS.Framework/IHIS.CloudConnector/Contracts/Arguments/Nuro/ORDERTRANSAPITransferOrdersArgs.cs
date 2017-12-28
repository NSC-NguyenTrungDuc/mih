using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class ORDERTRANSAPITransferOrdersArgs : IContractArgs
    {
        private String _bunho;
        private String _pkout1001;
        private String _performDate;
        private List<ORDERTRANSAPIHangmogInfo> _hangmogItem = new List<ORDERTRANSAPIHangmogInfo>();
        private IHIS.CloudConnector.Messaging.TransferType _action;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String PerformDate
        {
            get { return this._performDate; }
            set { this._performDate = value; }
        }

        public List<ORDERTRANSAPIHangmogInfo> HangmogItem
        {
            get { return this._hangmogItem; }
            set { this._hangmogItem = value; }
        }

        public IHIS.CloudConnector.Messaging.TransferType Action
        {
            get { return this._action; }
            set { this._action = value; }
        }

        public ORDERTRANSAPITransferOrdersArgs() { }

        public ORDERTRANSAPITransferOrdersArgs(String bunho, String pkout1001, String performDate, List<ORDERTRANSAPIHangmogInfo> hangmogItem, IHIS.CloudConnector.Messaging.TransferType action)
        {
            this._bunho = bunho;
            this._pkout1001 = pkout1001;
            this._performDate = performDate;
            this._hangmogItem = hangmogItem;
            this._action = action;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSAPITransferOrdersRequest();
        }
    }
}