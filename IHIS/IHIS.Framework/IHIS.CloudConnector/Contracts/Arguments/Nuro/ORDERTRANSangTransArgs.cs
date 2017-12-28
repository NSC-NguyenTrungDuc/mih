using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANSangTransArgs : IContractArgs
    {

        protected bool Equals(ORDERTRANSangTransArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_fkout1003, other._fkout1003);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANSangTransArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_fkout1003 != null ? _fkout1003.GetHashCode() : 0);
            }
        }

        private String _hospCode;
        private String _fkout1003;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Fkout1003
        {
            get { return this._fkout1003; }
            set { this._fkout1003 = value; }
        }

        public ORDERTRANSangTransArgs() { }

        public ORDERTRANSangTransArgs(String hospCode, String fkout1003)
        {
            this._hospCode = hospCode;
            this._fkout1003 = fkout1003;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANSangTransRequest();
        }
    }
}