using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRGOCSCHKCautionCodeDataValidatingArgs : IContractArgs
	{
        protected bool Equals(DRGOCSCHKCautionCodeDataValidatingArgs other)
        {
            return string.Equals(_cautionCode, other._cautionCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRGOCSCHKCautionCodeDataValidatingArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_cautionCode != null ? _cautionCode.GetHashCode() : 0);
        }

        private String _cautionCode;

		public String CautionCode
		{
			get { return this._cautionCode; }
			set { this._cautionCode = value; }
		}

		public DRGOCSCHKCautionCodeDataValidatingArgs() { }

		public DRGOCSCHKCautionCodeDataValidatingArgs(String cautionCode)
		{
			this._cautionCode = cautionCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRGOCSCHKCautionCodeDataValidatingRequest();
		}
	}
}