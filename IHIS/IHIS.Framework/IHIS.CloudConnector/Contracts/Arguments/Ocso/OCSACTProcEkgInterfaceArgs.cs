using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
    public class OCSACTProcEkgInterfaceArgs : IContractArgs
    {
    protected bool Equals(OCSACTProcEkgInterfaceArgs other)
    {
        return string.Equals(_orderDate, other._orderDate) && string.Equals(_bunho, other._bunho) && string.Equals(_fkout1001, other._fkout1001) && string.Equals(_pkocs, other._pkocs) && string.Equals(_userId, other._userId) && string.Equals(_ioGubun, other._ioGubun) && string.Equals(_sendYn, other._sendYn);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSACTProcEkgInterfaceArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_fkout1001 != null ? _fkout1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkocs != null ? _pkocs.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sendYn != null ? _sendYn.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _orderDate;
        private String _bunho;
        private String _fkout1001;
        private String _pkocs;
        private String _userId;
        private String _ioGubun;
        private String _sendYn;

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String Pkocs
        {
            get { return this._pkocs; }
            set { this._pkocs = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String SendYn
        {
            get { return this._sendYn; }
            set { this._sendYn = value; }
        }

        public OCSACTProcEkgInterfaceArgs() { }

        public OCSACTProcEkgInterfaceArgs(String orderDate, String bunho, String fkout1001, String pkocs, String userId, String ioGubun, String sendYn)
        {
            this._orderDate = orderDate;
            this._bunho = bunho;
            this._fkout1001 = fkout1001;
            this._pkocs = pkocs;
            this._userId = userId;
            this._ioGubun = ioGubun;
            this._sendYn = sendYn;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCSACTProcEkgInterfaceRequest();
        }
    }
}