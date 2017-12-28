using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0101U04GrdDetailArgs : IContractArgs
	{
        protected bool Equals(BAS0101U04GrdDetailArgs other)
        {
            return string.Equals(_codeType, other._codeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0101U04GrdDetailArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_codeType != null ? _codeType.GetHashCode() : 0);
        }

        private String _codeType;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public BAS0101U04GrdDetailArgs() { }

		public BAS0101U04GrdDetailArgs(String codeType)
		{
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0101U04GrdDetailRequest();
		}
	}
}