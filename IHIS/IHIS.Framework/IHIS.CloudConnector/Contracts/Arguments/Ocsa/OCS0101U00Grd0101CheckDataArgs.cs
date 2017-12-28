using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0101U00Grd0101CheckDataArgs : IContractArgs
    {
    protected bool Equals(OCS0101U00Grd0101CheckDataArgs other)
    {
        return string.Equals(_value, other._value) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0101U00Grd0101CheckDataArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_value != null ? _value.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _value;
        private String _hospCode;

        public String Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0101U00Grd0101CheckDataArgs() { }

        public OCS0101U00Grd0101CheckDataArgs(String value, String hospCode)
        {
            this._value = value;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0101U00Grd0101CheckDataRequest();
        }
    }
}