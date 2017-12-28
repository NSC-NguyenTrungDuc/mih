using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0123U00GrdBAS0123Args : IContractArgs
	{
        protected bool Equals(BAS0123U00GrdBAS0123Args other)
        {
            return string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0123U00GrdBAS0123Args) obj);
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

		public BAS0123U00GrdBAS0123Args() { }

		public BAS0123U00GrdBAS0123Args(String code)
		{
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0123U00GrdBAS0123Request();
		}
	}
}