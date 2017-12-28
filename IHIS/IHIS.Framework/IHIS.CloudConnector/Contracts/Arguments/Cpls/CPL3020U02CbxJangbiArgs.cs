using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
    public class CPL3020U02CbxJangbiArgs : IContractArgs
    {
        protected bool Equals(CPL3020U02CbxJangbiArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U02CbxJangbiArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public CPL3020U02CbxJangbiArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.CPL3020U02CbxJangbiRequest();
        }
    }
}