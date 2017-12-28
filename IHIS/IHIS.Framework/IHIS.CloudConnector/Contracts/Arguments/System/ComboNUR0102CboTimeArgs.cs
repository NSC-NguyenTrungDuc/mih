using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class ComboNUR0102CboTimeArgs : IContractArgs
    {
        protected bool Equals(ComboNUR0102CboTimeArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComboNUR0102CboTimeArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public ComboNUR0102CboTimeArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ComboNUR0102CboTimeRequest();
        }
    }
}