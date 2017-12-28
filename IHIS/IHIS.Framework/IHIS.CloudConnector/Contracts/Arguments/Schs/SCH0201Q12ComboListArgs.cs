using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{
    [Serializable]
	public class SCH0201Q12ComboListArgs : IContractArgs
	{
        protected bool Equals(SCH0201Q12ComboListArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SCH0201Q12ComboListArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public SCH0201Q12ComboListArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new SCH0201Q12ComboListRequest();
		}
	}
}