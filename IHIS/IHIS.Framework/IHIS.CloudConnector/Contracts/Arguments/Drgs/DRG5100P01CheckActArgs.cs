using System;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
    public class DRG5100P01CheckActArgs : IContractArgs
    {
        protected bool Equals(DRG5100P01CheckActArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG5100P01CheckActArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public DRG5100P01CheckActArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.DRG5100P01CheckActRequest();
        }
    }
}