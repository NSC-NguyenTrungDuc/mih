using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00FrmSigeyulDelCplTempArgs : IContractArgs
	{
        protected bool Equals(CPL0000Q00FrmSigeyulDelCplTempArgs other)
        {
            return string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00FrmSigeyulDelCplTempArgs) obj);
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

		public CPL0000Q00FrmSigeyulDelCplTempArgs() { }

		public CPL0000Q00FrmSigeyulDelCplTempArgs(String userId)
		{
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00FrmSigeyulDelCplTempRequest();
		}
	}
}