using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class ComboADM3200FwkActorArgs : IContractArgs
    {
        protected bool Equals(ComboADM3200FwkActorArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComboADM3200FwkActorArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public ComboADM3200FwkActorArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComboADM3200FwkActorRequest();
        }
    }
}