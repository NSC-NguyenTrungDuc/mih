using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ0102CodeNameListArgs : IContractArgs
	{
        protected bool Equals(INJ0102CodeNameListArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ0102CodeNameListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_code != null ? _code.GetHashCode() : 0);
            }
        }

        private String _codeType;
		private String _code;

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

		public INJ0102CodeNameListArgs() { }

		public INJ0102CodeNameListArgs(String codeType, String code)
		{
			this._codeType = codeType;
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ0102CodeNameListRequest();
		}
	}
}