using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0201U00CbxActorArgs : IContractArgs
	{
        protected bool Equals(DRG0201U00CbxActorArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0201U00CbxActorArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public DRG0201U00CbxActorArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new DRG0201U00CbxActorRequest();
		}
	}
}