using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM401UGrdGrpArgs : IContractArgs
	{
        protected bool Equals(ADM401UGrdGrpArgs other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM401UGrdGrpArgs) obj);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public ADM401UGrdGrpArgs() { }

		public IExtensible GetRequestInstance()
		{
			return new ADM401UGrdGrpRequest();
		}
	}
}