using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0001U00LayDupArgs : IContractArgs
    {
    protected bool Equals(XRT0001U00LayDupArgs other)
    {
        return string.Equals(_xrayCode, other._xrayCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0001U00LayDupArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_xrayCode != null ? _xrayCode.GetHashCode() : 0);
    }

    private String _xrayCode;

        public String XrayCode
        {
            get { return this._xrayCode; }
            set { this._xrayCode = value; }
        }

        public XRT0001U00LayDupArgs() { }

        public XRT0001U00LayDupArgs(String xrayCode)
        {
            this._xrayCode = xrayCode;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0001U00LayDupRequest();
        }
    }
}