using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class ComboADM3200CbxActorArgs : IContractArgs
    {
        protected bool Equals(ComboADM3200CbxActorArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComboADM3200CbxActorArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public ComboADM3200CbxActorArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComboADM3200CbxActorRequest();
        }
    }
}