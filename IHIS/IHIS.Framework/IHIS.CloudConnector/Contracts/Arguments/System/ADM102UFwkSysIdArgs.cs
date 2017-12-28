using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
    public class ADM102UFwkSysIdArgs : IContractArgs
    {
        protected bool Equals(ADM102UFwkSysIdArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM102UFwkSysIdArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public ADM102UFwkSysIdArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM102UFwkSysIdRequest();
        }
    }
}