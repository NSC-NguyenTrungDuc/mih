using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0000Q00FrmGraphGetSigeyulArgs : IContractArgs
	{
        protected bool Equals(CPL0000Q00FrmGraphGetSigeyulArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_userId, other._userId) && string.Equals(_baseDate, other._baseDate) && string.Equals(_conditionValue, other._conditionValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0000Q00FrmGraphGetSigeyulArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_baseDate != null ? _baseDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_conditionValue != null ? _conditionValue.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunho;
		private String _userId;
		private String _baseDate;
		private String _conditionValue;

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

		public String BaseDate
		{
			get { return this._baseDate; }
			set { this._baseDate = value; }
		}

		public String ConditionValue
		{
			get { return this._conditionValue; }
			set { this._conditionValue = value; }
		}

		public CPL0000Q00FrmGraphGetSigeyulArgs() { }

		public CPL0000Q00FrmGraphGetSigeyulArgs(String bunho, String userId, String baseDate, String conditionValue)
		{
			this._bunho = bunho;
			this._userId = userId;
			this._baseDate = baseDate;
			this._conditionValue = conditionValue;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0000Q00FrmGraphGetSigeyulRequest();
		}
	}
}