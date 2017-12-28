using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01ActorListArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01ActorListArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01ActorListArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public InjsINJ1001U01ActorListArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01ActorListRequest();
		}
	}
}