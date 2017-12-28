using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00GetSigeyulDataSelect1Args : IContractArgs
	{
        protected bool Equals(CPL0000Q00GetSigeyulDataSelect1Args other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00GetSigeyulDataSelect1Args) obj);
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

		public CPL0000Q00GetSigeyulDataSelect1Args() { }

		public CPL0000Q00GetSigeyulDataSelect1Args(String bunho, String userId)
		{
			this._bunho = bunho;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00GetSigeyulDataSelect1Request();
		}
	}
}