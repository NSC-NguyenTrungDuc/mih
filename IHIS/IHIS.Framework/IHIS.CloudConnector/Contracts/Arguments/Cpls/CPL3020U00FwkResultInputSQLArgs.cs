using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00FwkResultInputSQLArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00FwkResultInputSQLArgs other)
        {
            return string.Equals(_dummy, other._dummy) && string.Equals(_find1, other._find1) && string.Equals(_resultForm, other._resultForm) && string.Equals(_codeType, other._codeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00FwkResultInputSQLArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_dummy != null ? _dummy.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resultForm != null ? _resultForm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _dummy;
		private String _find1;
		private String _resultForm;
		private String _codeType;

		public String Dummy
		{
			get { return this._dummy; }
			set { this._dummy = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public String ResultForm
		{
			get { return this._resultForm; }
			set { this._resultForm = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public CPL3020U00FwkResultInputSQLArgs() { }

		public CPL3020U00FwkResultInputSQLArgs(String dummy, String find1, String resultForm, String codeType)
		{
			this._dummy = dummy;
			this._find1 = find1;
			this._resultForm = resultForm;
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00FwkResultInputSQLRequest();
		}
	}
}