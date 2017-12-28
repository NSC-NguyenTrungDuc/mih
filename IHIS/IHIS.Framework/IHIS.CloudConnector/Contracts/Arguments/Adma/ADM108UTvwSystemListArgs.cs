using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM108UTvwSystemListArgs : IContractArgs
	{
        protected bool Equals(ADM108UTvwSystemListArgs other)
        {
            return string.Equals(_pgmId, other._pgmId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM108UTvwSystemListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_pgmId != null ? _pgmId.GetHashCode() : 0);
        }

        private String _pgmId;

		public String PgmId
		{
			get { return this._pgmId; }
			set { this._pgmId = value; }
		}

		public ADM108UTvwSystemListArgs() { }

		public ADM108UTvwSystemListArgs(String pgmId)
		{
			this._pgmId = pgmId;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM108UTvwSystemListRequest();
		}
	}
}