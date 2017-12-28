using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class FwServiceConnectArgs : IContractArgs
    {
    protected bool Equals(FwServiceConnectArgs other)
    {
        return string.Equals(_dbKind, other._dbKind);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FwServiceConnectArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_dbKind != null ? _dbKind.GetHashCode() : 0);
    }

    private String _dbKind;

        public String DbKind
        {
            get { return this._dbKind; }
            set { this._dbKind = value; }
        }

        public FwServiceConnectArgs() { }

        public FwServiceConnectArgs(String dbKind)
        {
            this._dbKind = dbKind;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.FwServiceConnectRequest();
        }
    }
}