using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0122U00LayDupDArgs : IContractArgs
    {
    protected bool Equals(XRT0122U00LayDupDArgs other)
    {
        return string.Equals(_buwiBunryu, other._buwiBunryu) && string.Equals(_buwiCode, other._buwiCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0122U00LayDupDArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_buwiBunryu != null ? _buwiBunryu.GetHashCode() : 0)*397) ^ (_buwiCode != null ? _buwiCode.GetHashCode() : 0);
        }
    }

    private String _buwiBunryu;
        private String _buwiCode;

        public String BuwiBunryu
        {
            get { return this._buwiBunryu; }
            set { this._buwiBunryu = value; }
        }

        public String BuwiCode
        {
            get { return this._buwiCode; }
            set { this._buwiCode = value; }
        }

        public XRT0122U00LayDupDArgs() { }

        public XRT0122U00LayDupDArgs(String buwiBunryu, String buwiCode)
        {
            this._buwiBunryu = buwiBunryu;
            this._buwiCode = buwiCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0122U00LayDupDRequest();
        }
    }
}