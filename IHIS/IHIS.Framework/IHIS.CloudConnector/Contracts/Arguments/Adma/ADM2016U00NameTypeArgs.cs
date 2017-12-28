using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
    public class ADM2016U00NameTypeArgs : IContractArgs
    {
        protected bool Equals(ADM2016U00NameTypeArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM2016U00NameTypeArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public ADM2016U00NameTypeArgs() { }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.ADM2016U00NameTypeRequest();
        }
    }
}