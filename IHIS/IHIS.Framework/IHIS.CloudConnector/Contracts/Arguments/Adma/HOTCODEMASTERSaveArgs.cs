using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class HOTCODEMASTERSaveArgs : IContractArgs
    {
        protected bool Equals(HOTCODEMASTERSaveArgs other)
        {
            return Equals(_hotCodeInfo, other._hotCodeInfo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HOTCODEMASTERSaveArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_hotCodeInfo != null ? _hotCodeInfo.GetHashCode() : 0);
        }

        private List<ADM2016U00GrdLoadDrgInfo> _hotCodeInfo = new List<ADM2016U00GrdLoadDrgInfo>();

        public List<ADM2016U00GrdLoadDrgInfo> HotCodeInfo
        {
            get { return this._hotCodeInfo; }
            set { this._hotCodeInfo = value; }
        }

        public HOTCODEMASTERSaveArgs() { }

        public HOTCODEMASTERSaveArgs(List<ADM2016U00GrdLoadDrgInfo> hotCodeInfo)
        {
            this._hotCodeInfo = hotCodeInfo;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.HOTCODEMASTERSaveRequest();
        }
    }
}