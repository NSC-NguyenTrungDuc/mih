using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT1002U00LayOrderDateArgs : IContractArgs
    {
    protected bool Equals(XRT1002U00LayOrderDateArgs other)
    {
        return string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT1002U00LayOrderDateArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_bunho != null ? _bunho.GetHashCode() : 0);
    }

    private String _bunho;

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public XRT1002U00LayOrderDateArgs() { }

        public XRT1002U00LayOrderDateArgs(String bunho)
        {
            this._bunho = bunho;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT1002U00LayOrderDateRequest();
        }
    }
}