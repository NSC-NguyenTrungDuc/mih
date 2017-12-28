using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroORDERTRANSUpdateOCS1003Args : IContractArgs
    {
        protected bool Equals(NuroORDERTRANSUpdateOCS1003Args other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_pkout1001, other._pkout1001) && Equals(_ocsUpdItem, other._ocsUpdItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroORDERTRANSUpdateOCS1003Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_pkout1001 != null ? _pkout1001.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ocsUpdItem != null ? _ocsUpdItem.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
        private String _pkout1001;
        private List<NuroORDERTRANSUpdateOCS1003Info> _ocsUpdItem = new List<NuroORDERTRANSUpdateOCS1003Info>();

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

        public List<NuroORDERTRANSUpdateOCS1003Info> OcsUpdItem
        {
            get { return this._ocsUpdItem; }
            set { this._ocsUpdItem = value; }
        }

        public NuroORDERTRANSUpdateOCS1003Args() { }

        public NuroORDERTRANSUpdateOCS1003Args(String bunho, String pkout1001, List<NuroORDERTRANSUpdateOCS1003Info> ocsUpdItem)
        {
            this._bunho = bunho;
            this._pkout1001 = pkout1001;
            this._ocsUpdItem = ocsUpdItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.NuroORDERTRANSUpdateOCS1003Request();
        }
    }
}