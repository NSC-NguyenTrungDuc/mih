using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1001U01XEditGridCell88Args : IContractArgs
	{
        protected bool Equals(INJ1001U01XEditGridCell88Args other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1001U01XEditGridCell88Args) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public INJ1001U01XEditGridCell88Args() { }

		public IExtensible GetRequestInstance()
		{
			return new INJ1001U01XEditGridCell88Request();
		}
	}
}