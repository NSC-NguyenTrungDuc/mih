using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3010U01GrdResultArgs : IContractArgs
    {
        protected bool Equals(CPL3010U01GrdResultArgs other)
        {
            return string.Equals(_requestKey, other._requestKey);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U01GrdResultArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_requestKey != null ? _requestKey.GetHashCode() : 0);
        }

        private String _requestKey;

        public String RequestKey
        {
            get { return this._requestKey; }
            set { this._requestKey = value; }
        }

        public CPL3010U01GrdResultArgs() { }

        public CPL3010U01GrdResultArgs(String requestKey)
        {
            this._requestKey = requestKey;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3010U01GrdResultRequest();
        }
    }
}