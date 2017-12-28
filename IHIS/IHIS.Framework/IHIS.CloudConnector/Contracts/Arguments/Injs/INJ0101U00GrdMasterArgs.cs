using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ0101U00GrdMasterArgs : IContractArgs
	{
        protected bool Equals(INJ0101U00GrdMasterArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ0101U00GrdMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public INJ0101U00GrdMasterArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new INJ0101U00GrdMasterRequest();
		}
	}
}