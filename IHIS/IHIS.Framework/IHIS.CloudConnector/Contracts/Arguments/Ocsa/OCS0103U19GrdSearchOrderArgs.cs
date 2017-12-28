using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U19GrdSearchOrderArgs : IContractArgs
    {
    protected bool Equals(OCS0103U19GrdSearchOrderArgs other)
    {
        return string.Equals(_searchWord, other._searchWord) && string.Equals(_searchCondition, other._searchCondition) && string.Equals(_inputTab, other._inputTab) && string.Equals(_mode, other._mode) && string.Equals(_slipCode, other._slipCode) && string.Equals(_orderDate, other._orderDate) && string.Equals(_wonnaeDrgYn, other._wonnaeDrgYn) && string.Equals(_protocolId, other._protocolId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U19GrdSearchOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_searchWord != null ? _searchWord.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_searchCondition != null ? _searchCondition.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_mode != null ? _mode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_slipCode != null ? _slipCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_wonnaeDrgYn != null ? _wonnaeDrgYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_protocolId != null ? _protocolId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _searchWord;
        private String _searchCondition;
        private String _inputTab;
        private String _mode;
        private String _slipCode;
        private String _orderDate;
        private String _wonnaeDrgYn;
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

        public String InputTab
        {
            get { return this._inputTab; }
            set { this._inputTab = value; }
        }

        public String Mode
        {
            get { return this._mode; }
            set { this._mode = value; }
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

        public String WonnaeDrgYn
        {
            get { return this._wonnaeDrgYn; }
            set { this._wonnaeDrgYn = value; }
        }

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
        }

        public OCS0103U19GrdSearchOrderArgs() { }

        public OCS0103U19GrdSearchOrderArgs(String searchWord, String searchCondition, String inputTab, String mode, String slipCode, String orderDate, String wonnaeDrgYn, String protocolId)
        {
            this._searchWord = searchWord;
            this._searchCondition = searchCondition;
            this._inputTab = inputTab;
            this._mode = mode;
            this._slipCode = slipCode;
            this._orderDate = orderDate;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._protocolId = protocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U19GrdSearchOrderRequest();
        }
    }
}