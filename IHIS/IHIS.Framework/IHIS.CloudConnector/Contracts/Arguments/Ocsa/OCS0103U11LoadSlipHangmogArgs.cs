using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U11LoadSlipHangmogArgs : IContractArgs
    {
    protected bool Equals(OCS0103U11LoadSlipHangmogArgs other)
    {
        return string.Equals(_searchWord, other._searchWord) && string.Equals(_searchCondition, other._searchCondition) && string.Equals(_slipCode, other._slipCode) && string.Equals(_orderDate, other._orderDate) && string.Equals(_protocolId, other._protocolId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U11LoadSlipHangmogArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_searchWord != null ? _searchWord.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_searchCondition != null ? _searchCondition.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_slipCode != null ? _slipCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_protocolId != null ? _protocolId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _searchWord;
        private String _searchCondition;
        private String _slipCode;
        private String _orderDate;
        private String _protocolId;

        public String SearchWord
        {
            get { return this._searchWord; }
            set { this._searchWord = value; }
        }

        public String SearchCondition
        {
            get { return this._searchCondition; }
            set { this._searchCondition = value; }
        }

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
        }

        public OCS0103U11LoadSlipHangmogArgs() { }

        public OCS0103U11LoadSlipHangmogArgs(String searchWord, String searchCondition, String slipCode, String orderDate, String protocolId)
        {
            this._searchWord = searchWord;
            this._searchCondition = searchCondition;
            this._slipCode = slipCode;
            this._orderDate = orderDate;
            this._protocolId = protocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U11LoadSlipHangmogRequest();
        }
    }
}