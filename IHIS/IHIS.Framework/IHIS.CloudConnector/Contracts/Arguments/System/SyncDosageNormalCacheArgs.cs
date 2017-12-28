using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{[Serializable]
    public class SyncDosageNormalCacheArgs : IContractArgs
    {
    protected bool Equals(SyncDosageNormalCacheArgs other)
    {
        return string.Equals(_pageNumber, other._pageNumber) && string.Equals(_offset, other._offset);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SyncDosageNormalCacheArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_pageNumber != null ? _pageNumber.GetHashCode() : 0)*397) ^ (_offset != null ? _offset.GetHashCode() : 0);
        }
    }

    private String _pageNumber;
        private String _offset;

        public String PageNumber
        {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public String Offset
        {
            get { return this._offset; }
            set { this._offset = value; }
        }

        public SyncDosageNormalCacheArgs() { }

        public SyncDosageNormalCacheArgs(String pageNumber, String offset)
        {
            this._pageNumber = pageNumber;
            this._offset = offset;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SyncDosageNormalCacheRequest();
        }
    }
}