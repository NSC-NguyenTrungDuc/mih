using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0103U00LoadKanaFullArgs : IContractArgs
    {
    protected bool Equals(OCS0103U00LoadKanaFullArgs other)
    {
        return string.Equals(_text, other._text) && string.Equals(_hospCode, other._hospCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U00LoadKanaFullArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_text != null ? _text.GetHashCode() : 0)*397) ^ (_hospCode != null ? _hospCode.GetHashCode() : 0);
        }
    }

    private String _text;
        private String _hospCode;

        public String Text
        {
            get { return this._text; }
            set { this._text = value; }
        }

        public String HospCode
        {
            get { return this._hospCode; }
            set { this._hospCode = value; }
        }

        public OCS0103U00LoadKanaFullArgs() { }

        public OCS0103U00LoadKanaFullArgs(String text, String hospCode)
        {
            this._text = text;
            this._hospCode = hospCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0103U00LoadKanaFullRequest();
        }
    }
}