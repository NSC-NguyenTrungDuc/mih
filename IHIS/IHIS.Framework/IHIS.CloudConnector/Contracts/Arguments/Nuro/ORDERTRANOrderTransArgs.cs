using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class ORDERTRANOrderTransArgs : IContractArgs
    {
        protected bool Equals(ORDERTRANOrderTransArgs other)
        {
            return string.Equals(_hospCode, other._hospCode) && string.Equals(_fkout1003, other._fkout1003) && string.Equals(_transGubun, other._transGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ORDERTRANOrderTransArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_hospCode != null ? _hospCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_fkout1003 != null ? _fkout1003.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_transGubun != null ? _transGubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _hospCode;
        private String _fkout1003;
        private String _transGubun;

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

        public String TransGubun
        {
            get { return this._transGubun; }
            set { this._transGubun = value; }
        }

        public ORDERTRANOrderTransArgs() { }

        public ORDERTRANOrderTransArgs(String hospCode, String fkout1003, String transGubun)
        {
            this._hospCode = hospCode;
            this._fkout1003 = fkout1003;
            this._transGubun = transGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ORDERTRANOrderTransRequest();
        }
    }
}