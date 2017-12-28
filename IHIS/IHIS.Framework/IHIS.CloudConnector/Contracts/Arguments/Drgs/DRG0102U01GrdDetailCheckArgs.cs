using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0102U01GrdDetailCheckArgs : IContractArgs
	{
        protected bool Equals(DRG0102U01GrdDetailCheckArgs other)
        {
            return string.Equals(_code, other._code) && string.Equals(_codeType, other._codeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0102U01GrdDetailCheckArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_code != null ? _code.GetHashCode() : 0)*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
            }
        }

        private String _code;
		private String _codeType;

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public DRG0102U01GrdDetailCheckArgs() { }

		public DRG0102U01GrdDetailCheckArgs(String code, String codeType)
		{
			this._code = code;
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0102U01GrdDetailCheckRequest();
		}
	}
}