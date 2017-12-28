using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00GetProtocolArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00GetProtocolArgs other)
    {
        return string.Equals(_hospCode, other._hospCode) && string.Equals(_find1, other._find1);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00GetProtocolArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_hospCode != null ? _hospCode.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
        }
    }

    private String _hospCode;
        private String _find1;

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public String Find1
        {
            get { return this._find1; }
            set { this._find1 = value; }
        }

        public OCS0103U00GetProtocolArgs() { }

        public OCS0103U00GetProtocolArgs(String hospCode, String find1)
        {
            this._hospCode = hospCode;
            this._find1 = find1;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00GetProtocolRequest();
        }
    }
}