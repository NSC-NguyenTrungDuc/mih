using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0123U00grdMCodeArgs : IContractArgs
    {
    protected bool Equals(XRT0123U00grdMCodeArgs other)
    {
        return string.Equals(_xrayGubun, other._xrayGubun);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0123U00grdMCodeArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_xrayGubun != null ? _xrayGubun.GetHashCode() : 0);
    }

    private String _xrayGubun;

        public String XrayGubun
        {
            get { return this._xrayGubun; }
            set { this._xrayGubun = value; }
        }

        public XRT0123U00grdMCodeArgs() { }

        public XRT0123U00grdMCodeArgs(String xrayGubun)
        {
            this._xrayGubun = xrayGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0123U00grdMCodeRequest();
        }
    }
}