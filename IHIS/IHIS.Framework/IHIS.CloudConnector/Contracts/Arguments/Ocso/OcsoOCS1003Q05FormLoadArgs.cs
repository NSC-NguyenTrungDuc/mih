using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{
    [Serializable]
	public class OcsoOCS1003Q05FormLoadArgs : IContractArgs
	{
        protected bool Equals(OcsoOCS1003Q05FormLoadArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OcsoOCS1003Q05FormLoadArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public OcsoOCS1003Q05FormLoadArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003Q05FormLoadRequest();
		}
	}
}