using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Xrts
{[Serializable]
    public class XRT0001U00SaveLayoutArgs : IContractArgs
    {
    protected bool Equals(XRT0001U00SaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && Equals(_saveLayoutItem, other._saveLayoutItem);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((XRT0001U00SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_saveLayoutItem != null ? _saveLayoutItem.GetHashCode() : 0);
        }
    }

    private String _userId;
        private List<XRT0001U00SaveLayoutInfo> _saveLayoutItem = new List<XRT0001U00SaveLayoutInfo>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<XRT0001U00SaveLayoutInfo> SaveLayoutItem
        {
            get { return this._saveLayoutItem; }
            set { this._saveLayoutItem = value; }
        }

        public XRT0001U00SaveLayoutArgs() { }

        public XRT0001U00SaveLayoutArgs(String userId, List<XRT0001U00SaveLayoutInfo> saveLayoutItem)
        {
            this._userId = userId;
            this._saveLayoutItem = saveLayoutItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.XRT0001U00SaveLayoutRequest();
        }
    }
}