using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U02GrdStatusArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U02GrdStatusArgs other)
        {
            return string.Equals(_protocolId, other._protocolId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U02GrdStatusArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_protocolId != null ? _protocolId.GetHashCode() : 0);
        }

        private String _protocolId;

        public String ProtocolId
        {
            get { return this._protocolId; }
            set { this._protocolId = value; }
        }

        public CLIS2015U02GrdStatusArgs() { }

        public CLIS2015U02GrdStatusArgs(String protocolId)
        {
            this._protocolId = protocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U02GrdStatusRequest();
        }
    }
}