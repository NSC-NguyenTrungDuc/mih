using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00DeleteAndSelectArgs : IContractArgs
	{
        protected bool Equals(CPL0000Q00DeleteAndSelectArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00DeleteAndSelectArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            }
        }

        private String _bunho;
		private String _userId;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public CPL0000Q00DeleteAndSelectArgs() { }

		public CPL0000Q00DeleteAndSelectArgs(String bunho, String userId)
		{
			this._bunho = bunho;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00DeleteAndSelectRequest();
		}
	}
}