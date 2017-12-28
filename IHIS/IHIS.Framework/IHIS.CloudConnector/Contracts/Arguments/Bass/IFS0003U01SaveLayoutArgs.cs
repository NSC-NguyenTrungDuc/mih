using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0003U01SaveLayoutArgs : IContractArgs
    {
        protected bool Equals(IFS0003U01SaveLayoutArgs other)
        {
            return string.Equals(_userId, other._userId) && Equals(_grdIfsItem, other._grdIfsItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0003U01SaveLayoutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0)*397) ^ (_grdIfsItem != null ? _grdIfsItem.GetHashCode() : 0);
            }
        }

        private String _userId;
        private List<IFS0003U01GrdIFS0003Info> _grdIfsItem = new List<IFS0003U01GrdIFS0003Info>();

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public List<IFS0003U01GrdIFS0003Info> GrdIfsItem
        {
            get { return this._grdIfsItem; }
            set { this._grdIfsItem = value; }
        }

        public IFS0003U01SaveLayoutArgs() { }

        public IFS0003U01SaveLayoutArgs(String userId, List<IFS0003U01GrdIFS0003Info> grdIfsItem)
        {
            this._userId = userId;
            this._grdIfsItem = grdIfsItem;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0003U01SaveLayoutRequest();
        }
    }
}