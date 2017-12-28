using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Clis
{
    [Serializable]
    public class CLIS2015U04GetPatientListItemArgs : IContractArgs
    {
        protected bool Equals(CLIS2015U04GetPatientListItemArgs other)
        {
            return string.Equals(_clisProtocolId, other._clisProtocolId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLIS2015U04GetPatientListItemArgs) obj);
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

        public CLIS2015U04GetPatientListItemArgs() { }

        public CLIS2015U04GetPatientListItemArgs(String clisProtocolId)
        {
            this._clisProtocolId = clisProtocolId;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CLIS2015U04GetPatientListItemRequest();
        }
    }
}