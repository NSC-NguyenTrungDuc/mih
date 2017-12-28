using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM102UGrdListArgs : IContractArgs
    {
        protected bool Equals(ADM102UGrdListArgs other)
        {
            return string.Equals(_sysId, other._sysId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM102UGrdListArgs) obj);
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

        public ADM102UGrdListArgs() { }

        public ADM102UGrdListArgs(String sysId)
        {
            this._sysId = sysId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM102UGrdListRequest();
        }
    }
}