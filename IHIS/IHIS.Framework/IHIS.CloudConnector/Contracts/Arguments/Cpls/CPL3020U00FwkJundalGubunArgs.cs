using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL3020U00FwkJundalGubunArgs : IContractArgs
	{
        protected bool Equals(CPL3020U00FwkJundalGubunArgs other)
        {
            return string.Equals(_codeType, other._codeType) && string.Equals(_find1, other._find1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL3020U00FwkJundalGubunArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_codeType != null ? _codeType.GetHashCode() : 0)*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
            }
        }

        private String _codeType;
		private String _find1;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String Find1
		{
			get { return this._find1; }
			set { this._find1 = value; }
		}

		public CPL3020U00FwkJundalGubunArgs() { }

		public CPL3020U00FwkJundalGubunArgs(String codeType, String find1)
		{
			this._codeType = codeType;
			this._find1 = find1;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL3020U00FwkJundalGubunRequest();
		}
	}
}