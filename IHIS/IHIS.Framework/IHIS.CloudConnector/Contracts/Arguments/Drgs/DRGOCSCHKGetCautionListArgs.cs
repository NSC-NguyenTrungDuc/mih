using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRGOCSCHKGetCautionListArgs : IContractArgs
	{
        protected bool Equals(DRGOCSCHKGetCautionListArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRGOCSCHKGetCautionListArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public DRGOCSCHKGetCautionListArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new DRGOCSCHKGetCautionListRequest();
		}
	}
}