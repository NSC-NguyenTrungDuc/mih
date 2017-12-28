using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3010U00BtnUrineClickArgs : IContractArgs
	{
        protected bool Equals(CPL3010U00BtnUrineClickArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3010U00BtnUrineClickArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public CPL3010U00BtnUrineClickArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new CPL3010U00BtnUrineClickRequest();
		}
	}
}