using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0102U00GrdMasterArgs : IContractArgs
	{
        protected bool Equals(DRG0102U00GrdMasterArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_codeTypeName, other._codeTypeName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0102U00GrdMasterArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_codeTypeName != null ? _codeTypeName.GetHashCode() : 0);
            }
        }

        private String _codeType;
		private String _codeTypeName;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String CodeTypeName
		{
			get { return this._codeTypeName; }
			set { this._codeTypeName = value; }
		}

		public DRG0102U00GrdMasterArgs() { }

		public DRG0102U00GrdMasterArgs(String codeType, String codeTypeName)
		{
			this._codeType = codeType;
			this._codeTypeName = codeTypeName;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0102U00GrdMasterRequest();
		}
	}
}