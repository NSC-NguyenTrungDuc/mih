using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.System
{
    [Serializable]
	public class CboSearchConditionArgs : IContractArgs
	{
        protected bool Equals(CboSearchConditionArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CboSearchConditionArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public CboSearchConditionArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new CboSearchConditionRequest();
		}
	}
}