using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class OrderTransMisaArgs : IContractArgs
    {
        protected bool Equals(OrderTransMisaArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_hopsCode, other._hopsCode) && string.Equals(_pkout1001, other._pkout1001);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderTransMisaArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hopsCode != null ? _hopsCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _hopsCode;
        private String _pkout1001;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String HopsCode
        {
            get { return this._hopsCode; }
            set { this._hopsCode = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public OrderTransMisaArgs() { }

        public OrderTransMisaArgs(String bunho, String hopsCode, String pkout1001)
        {
            this._bunho = bunho;
            this._hopsCode = hopsCode;
            this._pkout1001 = pkout1001;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OrderTransMisaRequest();
        }
    }
}