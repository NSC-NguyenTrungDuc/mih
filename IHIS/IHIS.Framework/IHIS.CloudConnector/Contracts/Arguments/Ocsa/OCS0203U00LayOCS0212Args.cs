using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0203U00LayOCS0212Args : IContractArgs
    {
    protected bool Equals(OCS0203U00LayOCS0212Args other)
    {
        return string.Equals(_slipCode, other._slipCode) && string.Equals(_memb, other._memb) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0203U00LayOCS0212Args) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_slipCode != null ? _slipCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_memb != null ? _memb.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _slipCode;
        private String _memb;
        private String _hospCode;

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String Memb
        {
            get { return this._memb; }
            set { this._memb = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0203U00LayOCS0212Args() { }

        public OCS0203U00LayOCS0212Args(String slipCode, String memb, String hospCode)
        {
            this._slipCode = slipCode;
            this._memb = memb;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0203U00LayOCS0212Request();
        }
    }
}