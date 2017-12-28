using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM106UGetSysNameArgs : IContractArgs
    {
        protected bool Equals(ADM106UGetSysNameArgs other)
        {
            return string.Equals(_sysId, other._sysId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM106UGetSysNameArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_sysId != null ? _sysId.GetHashCode() : 0);
        }

        private String _sysId;

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public ADM106UGetSysNameArgs() { }

        public ADM106UGetSysNameArgs(String sysId)
        {
            this._sysId = sysId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM106UGetSysNameRequest();
        }
    }
}