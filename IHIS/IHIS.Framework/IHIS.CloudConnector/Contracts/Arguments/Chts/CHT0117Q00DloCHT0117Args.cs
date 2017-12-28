using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0117Q00DloCHT0117Args : IContractArgs
	{
        protected bool Equals(CHT0117Q00DloCHT0117Args other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0117Q00DloCHT0117Args) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public CHT0117Q00DloCHT0117Args() { }

		public IExtensible GetRequestInstance()
		{
			return new CHT0117Q00DloCHT0117Request();
		}
	}
}