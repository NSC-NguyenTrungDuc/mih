using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class MdiFormOpenMainScreenArgs : IContractArgs
    {
    protected bool Equals(MdiFormOpenMainScreenArgs other)
    {
        return string.Equals(_systemId, other._systemId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MdiFormOpenMainScreenArgs) obj);
    }

    public override int GetHashCode()
    {
        return (_systemId != null ? _systemId.GetHashCode() : 0);
    }

    private String _systemId;

        public String SystemId
        {
            get { return this._systemId; }
            set { this._systemId = value; }
        }

        public MdiFormOpenMainScreenArgs() { }

        public MdiFormOpenMainScreenArgs(String systemId)
        {
            this._systemId = systemId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.MdiFormOpenMainScreenRequest();
        }
    }
}