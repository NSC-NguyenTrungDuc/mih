using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00LayCommonArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00LayCommonArgs other)
        {
            return string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00LayCommonArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_userId != null ? _userId.GetHashCode() : 0);
        }

        private String _userId;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public CPL3020U00LayCommonArgs() { }

		public CPL3020U00LayCommonArgs(String userId)
		{
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00LayCommonRequest();
		}
	}
}