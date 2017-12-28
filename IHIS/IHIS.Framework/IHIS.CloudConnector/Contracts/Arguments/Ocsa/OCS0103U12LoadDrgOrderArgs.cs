using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U12LoadDrgOrderArgs : IContractArgs
    {
    protected bool Equals(OCS0103U12LoadDrgOrderArgs other)
    {
        return string.Equals(_aMode, other._aMode) && string.Equals(_aCode1, other._aCode1) && string.Equals(_aWonnaeDrgYn, other._aWonnaeDrgYn) && string.Equals(_aSearchWord, other._aSearchWord) && string.Equals(_orderDate, other._orderDate) && string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset) && string.Equals(_bunho, other._bunho) && string.Equals(_protocolId, other._protocolId) && string.Equals(_searchCondition, other._searchCondition);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12LoadDrgOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_aMode != null ? _aMode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_aCode1 != null ? _aCode1.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_aWonnaeDrgYn != null ? _aWonnaeDrgYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_aSearchWord != null ? _aSearchWord.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pageNumber != null ? _pageNumber.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_protocolId != null ? _protocolId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_searchCondition != null ? _searchCondition.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _aMode;
        private String _aCode1;
        private String _aWonnaeDrgYn;
        private String _aSearchWord;
        private String _orderDate;
        private String _searchCondition;
        private String _pageNumber;
        private String _offset;
        private String _bunho;
        private String _protocolId;

        public String AMode
        {
            get { return this._aMode; }
            set { this._aMode = value; }
        }

        public String ACode1
        {
            get { return this._aCode1; }
            set { this._aCode1 = value; }
        }

        public String AWonnaeDrgYn
        {
            get { return this._aWonnaeDrgYn; }
            set { this._aWonnaeDrgYn = value; }
        }

        public String ASearchWord
        {
            get { return this._aSearchWord; }
            set { this._aSearchWord = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
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

        public OCS0103U12LoadDrgOrderArgs() { }

        public OCS0103U12LoadDrgOrderArgs(String aMode, String aCode1, String aWonnaeDrgYn, String aSearchWord, String orderDate, String searchCondition, String pageNumber, String offset, String bunho, String protocolId)
        {
            this._aMode = aMode;
            this._aCode1 = aCode1;
            this._aWonnaeDrgYn = aWonnaeDrgYn;
            this._aSearchWord = aSearchWord;
            this._orderDate = orderDate;
            this._searchCondition = searchCondition;
            this._pageNumber = pageNumber;
            this._offset = offset;
            this._bunho = bunho;
            this._protocolId = protocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U12LoadDrgOrderRequest();
        }
    }
}