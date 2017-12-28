using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSMisaTranferArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANSMisaTranferArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_pkout1001, other._pkout1001) && Equals(_lst, other._lst);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSMisaTranferArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_lst != null ? _lst.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _pkout1001;
        private List<ORDERTRANSMisaTranferInfo> _lst = new List<ORDERTRANSMisaTranferInfo>();

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public List<ORDERTRANSMisaTranferInfo> Lst
        {
            get { return this._lst; }
            set { this._lst = value; }
        }

        public ORDERTRANSMisaTranferArgs() { }

        public ORDERTRANSMisaTranferArgs(String bunho, String pkout1001, List<ORDERTRANSMisaTranferInfo> lst)
        {
            this._bunho = bunho;
            this._pkout1001 = pkout1001;
            this._lst = lst;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSMisaTranferRequest();
        }
    }
}