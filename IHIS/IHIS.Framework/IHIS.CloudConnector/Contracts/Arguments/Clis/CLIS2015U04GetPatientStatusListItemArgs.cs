using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U04GetPatientStatusListItemArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U04GetPatientStatusListItemArgs other)
        {
            return string.Equals(_protocolPatientId, other._protocolPatientId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U04GetPatientStatusListItemArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_protocolPatientId != null ? _protocolPatientId.GetHashCode() : 0);
        }

        private String _protocolPatientId;

        public String ProtocolPatientId
        {
            get { return this._protocolPatientId; }
            set { this._protocolPatientId = value; }
        }

        public CLIS2015U04GetPatientStatusListItemArgs() { }

        public CLIS2015U04GetPatientStatusListItemArgs(String protocolPatientId)
        {
            this._protocolPatientId = protocolPatientId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U04GetPatientStatusListItemRequest();
        }
    }
}