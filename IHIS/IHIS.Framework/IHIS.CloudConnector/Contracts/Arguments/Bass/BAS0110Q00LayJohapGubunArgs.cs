using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0110Q00LayJohapGubunArgs : IContractArgs
	{
        protected bool Equals(BAS0110Q00LayJohapGubunArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0110Q00LayJohapGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public BAS0110Q00LayJohapGubunArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new BAS0110Q00LayJohapGubunRequest();
		}
	}
}