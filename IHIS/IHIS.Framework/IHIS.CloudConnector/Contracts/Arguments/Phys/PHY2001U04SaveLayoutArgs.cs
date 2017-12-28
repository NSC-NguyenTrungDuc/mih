using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Phys
{[Serializable]
    public class PHY2001U04SaveLayoutArgs : IContractArgs
    {
    protected bool Equals(PHY2001U04SaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && Equals(_saveLayoutItem, other._saveLayoutItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PHY2001U04SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_saveLayoutItem != null ? _saveLayoutItem.GetHashCode() : 0);
        }
    }

    private String _userId;
        private List<PHY2001U04SaveLayoutInfo> _saveLayoutItem = new List<PHY2001U04SaveLayoutInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<PHY2001U04SaveLayoutInfo> SaveLayoutItem
        {
            get { return this._saveLayoutItem; }
            set { this._saveLayoutItem = value; }
        }

        public PHY2001U04SaveLayoutArgs() { }

        public PHY2001U04SaveLayoutArgs(String userId, List<PHY2001U04SaveLayoutInfo> saveLayoutItem)
        {
            this._userId = userId;
            this._saveLayoutItem = saveLayoutItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.PHY2001U04SaveLayoutRequest();
        }
    }
}