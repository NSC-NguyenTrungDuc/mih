using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
    public class OCS0311U00grdHangmogCodeArgs : IContractArgs
    {
    protected bool Equals(OCS0311U00grdHangmogCodeArgs other)
    {
        return string.Equals(_setPart, other._setPart);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0311U00grdHangmogCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_setPart != null ? _setPart.GetHashCode() : 0);
    }

    private String _setPart;

        public String SetPart
        {
            get { return this._setPart; }
            set { this._setPart = value; }
        }

        public OCS0311U00grdHangmogCodeArgs() { }

        public OCS0311U00grdHangmogCodeArgs(String setPart)
        {
            this._setPart = setPart;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OCS0311U00grdHangmogCodeRequest();
        }
    }
}