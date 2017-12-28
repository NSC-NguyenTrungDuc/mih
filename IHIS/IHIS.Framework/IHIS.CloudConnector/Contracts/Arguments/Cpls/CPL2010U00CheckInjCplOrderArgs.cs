using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL2010U00CheckInjCplOrderArgs : IContractArgs
    {
        protected bool Equals(CPL2010U00CheckInjCplOrderArgs other)
        {
            return string.Equals(_ioGubun, other._ioGubun) && string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL2010U00CheckInjCplOrderArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_ioGubun != null ? _ioGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _ioGubun;
        private String _bunho;
        private String _orderDate;

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public CPL2010U00CheckInjCplOrderArgs() { }

        public CPL2010U00CheckInjCplOrderArgs(String ioGubun, String bunho, String orderDate)
        {
            this._ioGubun = ioGubun;
            this._bunho = bunho;
            this._orderDate = orderDate;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL2010U00CheckInjCplOrderRequest();
        }
    }
}