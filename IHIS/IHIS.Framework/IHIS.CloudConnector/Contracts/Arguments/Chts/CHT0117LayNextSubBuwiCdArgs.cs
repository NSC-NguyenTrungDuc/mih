using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0117LayNextSubBuwiCdArgs : IContractArgs
	{
        protected bool Equals(CHT0117LayNextSubBuwiCdArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0117LayNextSubBuwiCdArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public CHT0117LayNextSubBuwiCdArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new CHT0117LayNextSubBuwiCdRequest();
		}
	}
}