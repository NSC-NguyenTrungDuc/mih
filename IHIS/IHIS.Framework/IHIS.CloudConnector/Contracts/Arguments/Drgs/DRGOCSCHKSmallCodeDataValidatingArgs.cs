using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRGOCSCHKSmallCodeDataValidatingArgs : IContractArgs
	{
        protected bool Equals(DRGOCSCHKSmallCodeDataValidatingArgs other)
        {
            return string.Equals(_code1, other._code1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRGOCSCHKSmallCodeDataValidatingArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_code1 != null ? _code1.GetHashCode() : 0);
        }

        private String _code1;

		public String Code1
		{
			get { return this._code1; }
			set { this._code1 = value; }
		}

		public DRGOCSCHKSmallCodeDataValidatingArgs() { }

		public DRGOCSCHKSmallCodeDataValidatingArgs(String code1)
		{
			this._code1 = code1;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRGOCSCHKSmallCodeDataValidatingRequest();
		}
	}
}