using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    public class OCS0103U10GrdDrgOrderArgs : IContractArgs
    {
        private String _mode;
        private String _code1;
        private String _wonnaeDrgYn;
        private String _orderDate;
        private String _searchWord;
        private String _protocolId;
        private String _pageNumber;
        private String _offSet;

        public String Mode
        {
            get { return this._mode; }
            set { this._mode = value; }
        }

        public String Code1
        {
            get { return this._code1; }
            set { this._code1 = value; }
        }

        public String WonnaeDrgYn
        {
            get { return this._wonnaeDrgYn; }
            set { this._wonnaeDrgYn = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String SearchWord
        {
            get { return this._searchWord; }
            set { this._searchWord = value; }
        }

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String OffSet
        {
            get { return this._offSet; }
            set { this._offSet = value; }
        }

        public OCS0103U10GrdDrgOrderArgs() { }

        public OCS0103U10GrdDrgOrderArgs(String mode, String code1, String wonnaeDrgYn, String orderDate, String searchWord, String protocolId, String pageNumber, String offSet)
        {
            this._mode = mode;
            this._code1 = code1;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._orderDate = orderDate;
            this._searchWord = searchWord;
            this._protocolId = protocolId;
            this._pageNumber = pageNumber;
            this._offSet = offSet;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U10GrdDrgOrderRequest();
        }
    }
}