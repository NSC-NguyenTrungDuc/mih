using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0101PreDeleteOcs0102CheckArgs : IContractArgs
    {
    protected bool Equals(OCS0101PreDeleteOcs0102CheckArgs other)
    {
        return string.Equals(_slipCode, other._slipCode) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0101PreDeleteOcs0102CheckArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_slipCode != null ? _slipCode.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _slipCode;
        private String _hospCode;

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0101PreDeleteOcs0102CheckArgs() { }

        public OCS0101PreDeleteOcs0102CheckArgs(String slipCode, String hospCode)
        {
            this._slipCode = slipCode;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0101PreDeleteOcs0102CheckRequest();
        }
    }
}