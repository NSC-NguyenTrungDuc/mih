using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U13TrialItemListArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U13TrialItemListArgs other)
        {
            return string.Equals(_clisProtocolId, other._clisProtocolId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U13TrialItemListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_clisProtocolId != null ? _clisProtocolId.GetHashCode() : 0);
        }

        private String _clisProtocolId;

        public String ClisProtocolId
        {
            get { return this._clisProtocolId; }
            set { this._clisProtocolId = value; }
        }

        public CLIS2015U13TrialItemListArgs() { }

        public CLIS2015U13TrialItemListArgs(String clisProtocolId)
        {
            this._clisProtocolId = clisProtocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U13TrialItemListRequest();
        }
    }
}