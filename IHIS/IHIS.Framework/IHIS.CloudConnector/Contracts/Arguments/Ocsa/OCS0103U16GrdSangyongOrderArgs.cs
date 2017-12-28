using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U16GrdSangyongOrderArgs : IContractArgs
    {
    protected bool Equals(OCS0103U16GrdSangyongOrderArgs other)
    {
        return string.Equals(_user, other._user) && string.Equals(_codeYn, other._codeYn) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_orderDate, other._orderDate) && string.Equals(_searchWord, other._searchWord) && string.Equals(_wonnaeDrgYn, other._wonnaeDrgYn) && string.Equals(_orderGubun, other._orderGubun) && string.Equals(_protocolId, other._protocolId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U16GrdSangyongOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_user != null ? _user.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_codeYn != null ? _codeYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_searchWord != null ? _searchWord.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_wonnaeDrgYn != null ? _wonnaeDrgYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderGubun != null ? _orderGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_protocolId != null ? _protocolId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _user;
        private String _codeYn;
        private String _ioGubun;
        private String _orderDate;
        private String _searchWord;
        private String _wonnaeDrgYn;
        private String _orderGubun;
        private String _protocolId;

        public String User
        {
            get { return this._user; }
            set { this._user = value; }
        }

        public String CodeYn
        {
            get { return this._codeYn; }
            set { this._codeYn = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
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

        public String WonnaeDrgYn
        {
            get { return this._wonnaeDrgYn; }
            set { this._wonnaeDrgYn = value; }
        }

        public String OrderGubun
        {
            get { return this._orderGubun; }
            set { this._orderGubun = value; }
        }

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
        }

        public OCS0103U16GrdSangyongOrderArgs() { }

        public OCS0103U16GrdSangyongOrderArgs(String user, String codeYn, String ioGubun, String orderDate, String searchWord, String wonnaeDrgYn, String orderGubun, String protocolId)
        {
            this._user = user;
            this._codeYn = codeYn;
            this._ioGubun = ioGubun;
            this._orderDate = orderDate;
            this._searchWord = searchWord;
            this._wonnaeDrgYn = wonnaeDrgYn;
            this._orderGubun = orderGubun;
            this._protocolId = protocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U16GrdSangyongOrderRequest();
        }
    }
}