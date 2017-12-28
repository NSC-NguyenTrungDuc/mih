using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0118U00CheckHangmogCodeArgs : IContractArgs
    {
    protected bool Equals(OCS0118U00CheckHangmogCodeArgs other)
    {
        return string.Equals(_hangmogCode, other._hangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0118U00CheckHangmogCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
    }

    private String _hangmogCode;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public OCS0118U00CheckHangmogCodeArgs() { }

        public OCS0118U00CheckHangmogCodeArgs(String hangmogCode)
        {
            this._hangmogCode = hangmogCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0118U00CheckHangmogCodeRequest();
        }
    }
}