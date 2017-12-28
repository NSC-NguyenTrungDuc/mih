using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class SyncKinkiCacheArgs : IContractArgs
    {
    protected bool Equals(SyncKinkiCacheArgs other)
    {
        return _kinkiType == other._kinkiType;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SyncKinkiCacheArgs) obj);
    }

    public override int GetHashCode()
    {
        return (int) _kinkiType;
    }

    private KinkiType _kinkiType;

        public KinkiType KinkiType
        {
            get { return this._kinkiType; }
            set { this._kinkiType = value; }
        }

        public SyncKinkiCacheArgs() { }

        public SyncKinkiCacheArgs(KinkiType kinkiType)
        {
            this._kinkiType = kinkiType;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SyncKinkiCacheRequest();
        }
    }
}