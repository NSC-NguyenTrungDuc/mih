using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRGOCSCHKPreSmallCodeDataValidatingArgs : IContractArgs
	{
        protected bool Equals(DRGOCSCHKPreSmallCodeDataValidatingArgs other)
        {
            return string.Equals(_code, other._code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRGOCSCHKPreSmallCodeDataValidatingArgs) obj);
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

		public DRGOCSCHKPreSmallCodeDataValidatingArgs() { }

		public DRGOCSCHKPreSmallCodeDataValidatingArgs(String code)
		{
			this._code = code;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRGOCSCHKPreSmallCodeDataValidatingRequest();
		}
	}
}