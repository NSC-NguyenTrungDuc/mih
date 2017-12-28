using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0123U00LayZipCodeArgs : IContractArgs
	{
        protected bool Equals(BAS0123U00LayZipCodeArgs other)
        {
            return string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0123U00LayZipCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_code != null ? _code.GetHashCode() : 0);
        }

        private String _code;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public BAS0123U00LayZipCodeArgs() { }

		public BAS0123U00LayZipCodeArgs(String code)
		{
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0123U00LayZipCodeRequest();
		}
	}
}