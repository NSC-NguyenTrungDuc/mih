using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Chts
{
    [Serializable]
	public class CHT0115Q00LayoutCommonArgs : IContractArgs
	{
        protected bool Equals(CHT0115Q00LayoutCommonArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CHT0115Q00LayoutCommonArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public CHT0115Q00LayoutCommonArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new CHT0115Q00LayoutCommonRequest();
		}
	}
}