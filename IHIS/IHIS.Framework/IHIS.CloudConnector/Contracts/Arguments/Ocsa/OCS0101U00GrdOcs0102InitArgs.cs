using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0101U00GrdOcs0102InitArgs : IContractArgs
    {
    protected bool Equals(OCS0101U00GrdOcs0102InitArgs other)
    {
        return string.Equals(_slipGubun, other._slipGubun) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0101U00GrdOcs0102InitArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_slipGubun != null ? _slipGubun.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _slipGubun;
        private String _hospCode;

        public String SlipGubun
        {
            get { return this._slipGubun; }
            set { this._slipGubun = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0101U00GrdOcs0102InitArgs() { }

        public OCS0101U00GrdOcs0102InitArgs(String slipGubun, String hospCode)
        {
            this._slipGubun = slipGubun;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0101U00GrdOcs0102InitRequest();
        }
    }
}