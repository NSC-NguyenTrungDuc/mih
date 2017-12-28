using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0123U00FwkZipCodeArgs : IContractArgs
	{
        protected bool Equals(BAS0123U00FwkZipCodeArgs other)
        {
            return string.Equals(_code, other._code) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0123U00FwkZipCodeArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_code != null ? _code.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            }
        }

        private String _code;
		private String _find1;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public BAS0123U00FwkZipCodeArgs() { }

		public BAS0123U00FwkZipCodeArgs(String code, String find1)
		{
			this._code = code;
			this._find1 = find1;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0123U00FwkZipCodeRequest();
		}
	}
}