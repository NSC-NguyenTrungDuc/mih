using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL0001U00CboJundalArgs : IContractArgs
    {
        protected bool Equals(CPL0001U00CboJundalArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0001U00CboJundalArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public CPL0001U00CboJundalArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL0001U00CboJundalRequest();
        }
    }
}