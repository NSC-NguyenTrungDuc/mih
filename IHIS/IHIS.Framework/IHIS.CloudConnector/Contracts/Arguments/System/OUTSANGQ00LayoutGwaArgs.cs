using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class OUTSANGQ00LayoutGwaArgs : IContractArgs
    {
        protected bool Equals(OUTSANGQ00LayoutGwaArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OUTSANGQ00LayoutGwaArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public OUTSANGQ00LayoutGwaArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.OUTSANGQ00LayoutGwaRequest();
        }
    }
}