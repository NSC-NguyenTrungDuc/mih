using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00PrOcsoChkResultMsgArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00PrOcsoChkResultMsgArgs other)
        {
            return string.Equals(_ocskey, other._ocskey) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00PrOcsoChkResultMsgArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_ocskey != null ? _ocskey.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private String _ocskey;
		private String _userId;

		public String Ocskey
		{
			get { return this._ocskey; }
			set { this._ocskey = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public CPL3020U00PrOcsoChkResultMsgArgs() { }

		public CPL3020U00PrOcsoChkResultMsgArgs(String ocskey, String userId)
		{
			this._ocskey = ocskey;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00PrOcsoChkResultMsgRequest();
		}
	}
}