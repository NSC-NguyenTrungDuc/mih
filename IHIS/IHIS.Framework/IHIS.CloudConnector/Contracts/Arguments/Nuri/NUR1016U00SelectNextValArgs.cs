using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NUR1016U00SelectNextValArgs : IContractArgs
	{
        protected bool Equals(NUR1016U00SelectNextValArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR1016U00SelectNextValArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public NUR1016U00SelectNextValArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new NUR1016U00SelectNextValRequest();
		}
	}
}