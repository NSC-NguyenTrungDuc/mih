using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0101U00MakeValSerViceArgs : IContractArgs
	{
        protected bool Equals(CPL0101U00MakeValSerViceArgs other)
        {
            return string.Equals(_aCtlName, other._aCtlName) && string.Equals(_codeType, other._codeType) && string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0101U00MakeValSerViceArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_aCtlName != null ? _aCtlName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _aCtlName;
		private String _codeType;
		private String _code;

		public String ACtlName
		{
			get { return this._aCtlName; }
			set { this._aCtlName = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public CPL0101U00MakeValSerViceArgs() { }

		public CPL0101U00MakeValSerViceArgs(String aCtlName, String codeType, String code)
		{
			this._aCtlName = aCtlName;
			this._codeType = codeType;
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0101U00MakeValSerViceRequest();
		}
	}
}