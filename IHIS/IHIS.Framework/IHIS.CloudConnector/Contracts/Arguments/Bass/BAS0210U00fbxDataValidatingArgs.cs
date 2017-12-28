using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0210U00fbxDataValidatingArgs : IContractArgs
	{
        protected bool Equals(BAS0210U00fbxDataValidatingArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_code, other._code) && string.Equals(_controlName, other._controlName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0210U00fbxDataValidatingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_controlName != null ? _controlName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _codeType;
		private String _code;
		private String _controlName;

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

		public String ControlName
		{
			get { return this._controlName; }
			set { this._controlName = value; }
		}

		public BAS0210U00fbxDataValidatingArgs() { }

		public BAS0210U00fbxDataValidatingArgs(String codeType, String code, String controlName)
		{
			this._codeType = codeType;
			this._code = code;
			this._controlName = controlName;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0210U00fbxDataValidatingRequest();
		}
	}
}