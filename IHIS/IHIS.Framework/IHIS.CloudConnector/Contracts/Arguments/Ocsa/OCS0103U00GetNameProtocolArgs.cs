using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00GetNameProtocolArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00GetNameProtocolArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_protocolCode, other._protocolCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00GetNameProtocolArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_protocolCode != null ? _protocolCode.GetHashCode() : 0);
        }
    }

    private String _hospCode;
        private String _protocolCode;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String ProtocolCode
        {
            get { return this._protocolCode; }
            set { this._protocolCode = value; }
        }

        public OCS0103U00GetNameProtocolArgs() { }

        public OCS0103U00GetNameProtocolArgs(String hospCode, String protocolCode)
        {
            this._hospCode = hospCode;
            this._protocolCode = protocolCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00GetNameProtocolRequest();
        }
    }
}