using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U13GrdSpecimenListArgs : IContractArgs
    {
    protected bool Equals(OCS0103U13GrdSpecimenListArgs other)
    {
        return string.Equals(_cplCodeYn, other._cplCodeYn) && string.Equals(_mode, other._mode) && string.Equals(_slipCode, other._slipCode) && string.Equals(_searchWord, other._searchWord) && string.Equals(_wonnaeDrgYn, other._wonnaeDrgYn) && string.Equals(_orderDate, other._orderDate) && string.Equals(_inputTab, other._inputTab) && string.Equals(_user, other._user) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset) && string.Equals(_protocolId, other._protocolId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U13GrdSpecimenListArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_cplCodeYn != null ? _cplCodeYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_mode != null ? _mode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_slipCode != null ? _slipCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_searchWord != null ? _searchWord.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_wonnaeDrgYn != null ? _wonnaeDrgYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_user != null ? _user.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_protocolId != null ? _protocolId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _cplCodeYn;
        private String _mode;
        private String _slipCode;
        private String _searchWord;
        private String _wonnaeDrgYn;
        private String _orderDate;
        private String _inputTab;
        private String _user;
        private String _pageNumber;
        private String _offset;
        private String _protocolId;

        public String CplCodeYn
        {
            get { return this._cplCodeYn; }
            set { this._cplCodeYn = value; }
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

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
        }

        public OCS0103U13GrdSpecimenListArgs() { }

        public OCS0103U13GrdSpecimenListArgs(String cplCodeYn, String mode, String slipCode, String searchWord, String wonnaeDrgYn, String orderDate, String inputTab, String user, String pageNumber, String offset, String protocolId)
        {
            this._cplCodeYn = cplCodeYn;
            this._mode = mode;
            this._slipCode = slipCode;
            this._searchWord = searchWord;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._orderDate = orderDate;
            this._inputTab = inputTab;
            this._user = user;
            this._pageNumber = pageNumber;
            this._offset = offset;
            this._protocolId = protocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U13GrdSpecimenListRequest();
        }
    }
}