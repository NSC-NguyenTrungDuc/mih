using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U14GrdSlipHangmogArgs : IContractArgs
    {
    protected bool Equals(OCS0103U14GrdSlipHangmogArgs other)
    {
        return string.Equals(_pfeCodeYn, other._pfeCodeYn) && string.Equals(_mode, other._mode) && string.Equals(_slipCode, other._slipCode) && string.Equals(_searchWord, other._searchWord) && string.Equals(_wonnaeDrgYn, other._wonnaeDrgYn) && string.Equals(_orderDate, other._orderDate) && string.Equals(_inputTab, other._inputTab) && string.Equals(_user, other._user) && string.Equals(_searchCondition, other._searchCondition) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset) && string.Equals(_bunho, other._bunho) && string.Equals(_protocolId, other._protocolId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U14GrdSlipHangmogArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_pfeCodeYn != null ? _pfeCodeYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_mode != null ? _mode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_slipCode != null ? _slipCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_searchWord != null ? _searchWord.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_wonnaeDrgYn != null ? _wonnaeDrgYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_user != null ? _user.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_searchCondition != null ? _searchCondition.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_protocolId != null ? _protocolId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _pfeCodeYn;
        private String _mode;
        private String _slipCode;
        private String _searchWord;
        private String _wonnaeDrgYn;
        private String _orderDate;
        private String _inputTab;
        private String _user;
        private String _searchCondition;
        private String _pageNumber;
        private String _offset;
        private String _bunho;
        private String _protocolId;

        public String PfeCodeYn
        {
            get { return this._pfeCodeYn; }
            set { this._pfeCodeYn = value; }
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

        public String SearchWord
        {
            get { return this._searchWord; }
            set { this._searchWord = value; }
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

        public String InputTab
        {
            get { return this._inputTab; }
            set { this._inputTab = value; }
        }

        public String User
        {
            get { return this._user; }
            set { this._user = value; }
        }

        public String SearchCondition
        {
            get { return this._searchCondition; }
            set { this._searchCondition = value; }
        }

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
        }

        public OCS0103U14GrdSlipHangmogArgs() { }

        public OCS0103U14GrdSlipHangmogArgs(String pfeCodeYn, String mode, String slipCode, String searchWord, String wonnaeDrgYn, String orderDate, String inputTab, String user, String searchCondition, String pageNumber, String offset, String bunho, String protocolId)
        {
            this._pfeCodeYn = pfeCodeYn;
            this._mode = mode;
            this._slipCode = slipCode;
            this._searchWord = searchWord;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._orderDate = orderDate;
            this._inputTab = inputTab;
            this._user = user;
            this._searchCondition = searchCondition;
            this._pageNumber = pageNumber;
            this._offset = offset;
            this._bunho = bunho;
            this._protocolId = protocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U14GrdSlipHangmogRequest();
        }
    }
}