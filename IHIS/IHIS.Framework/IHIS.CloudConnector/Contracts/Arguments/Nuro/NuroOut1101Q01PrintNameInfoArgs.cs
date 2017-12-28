using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
    public class NuroOut1101Q01PrintNameInfoArgs : IContractArgs
    {
        protected bool Equals(NuroOut1101Q01PrintNameInfoArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NuroOut1101Q01PrintNameInfoArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public NuroOut1101Q01PrintNameInfoArgs()
        {
        }

        public IExtensible GetRequestInstance()
        {
            return new NuroOUT1101Q01PrintNameInfoRequest();
        }
    }
}