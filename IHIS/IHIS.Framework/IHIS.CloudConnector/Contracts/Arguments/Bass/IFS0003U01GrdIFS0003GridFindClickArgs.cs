using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
    public class IFS0003U01GrdIFS0003GridFindClickArgs : IContractArgs
    {
        protected bool Equals(IFS0003U01GrdIFS0003GridFindClickArgs other)
        {
            return string.Equals(_mapGubun, other._mapGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IFS0003U01GrdIFS0003GridFindClickArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_mapGubun != null ? _mapGubun.GetHashCode() : 0);
        }

        private String _mapGubun;

        public String MapGubun
        {
            get { return this._mapGubun; }
            set { this._mapGubun = value; }
        }

        public IFS0003U01GrdIFS0003GridFindClickArgs() { }

        public IFS0003U01GrdIFS0003GridFindClickArgs(String mapGubun)
        {
            this._mapGubun = mapGubun;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.IFS0003U01GrdIFS0003GridFindClickRequest();
        }
    }
}