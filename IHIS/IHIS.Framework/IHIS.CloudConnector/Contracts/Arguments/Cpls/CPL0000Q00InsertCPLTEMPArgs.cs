using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00InsertCPLTEMPArgs : IContractArgs
	{
        protected bool Equals(CPL0000Q00InsertCPLTEMPArgs other)
        {
            return string.Equals(_userId, other._userId) && string.Equals(_i, other._i) && string.Equals(_hangmogCode, other._hangmogCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00InsertCPLTEMPArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_i != null ? _i.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _userId;
		private String _i;
		private String _hangmogCode;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String I
		{
			get { return this._i; }
			set { this._i = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public CPL0000Q00InsertCPLTEMPArgs() { }

		public CPL0000Q00InsertCPLTEMPArgs(String userId, String i, String hangmogCode)
		{
			this._userId = userId;
			this._i = i;
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00InsertCPLTEMPRequest();
		}
	}
}