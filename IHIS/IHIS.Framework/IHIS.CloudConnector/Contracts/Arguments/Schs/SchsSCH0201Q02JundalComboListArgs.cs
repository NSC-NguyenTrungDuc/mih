using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{
    [Serializable]
	public class SchsSCH0201Q02JundalComboListArgs : IContractArgs
	{
        protected bool Equals(SchsSCH0201Q02JundalComboListArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SchsSCH0201Q02JundalComboListArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public SchsSCH0201Q02JundalComboListArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new SchsSCH0201Q02JundalComboListRequest();
		}
	}
}