using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM401UUpdateArgs : IContractArgs
	{
        protected bool Equals(ADM401UUpdateArgs other)
        {
            return _hasVersion.Equals(other._hasVersion) && string.Equals(_asmVer, other._asmVer) && string.Equals(_asmName, other._asmName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM401UUpdateArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _hasVersion.GetHashCode();
                hashCode = (hashCode*397) ^ (_asmVer != null ? _asmVer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_asmName != null ? _asmName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private Boolean _hasVersion;
		private String _asmVer;
		private String _asmName;

		public Boolean HasVersion
		{
			get { return this._hasVersion; }
			set { this._hasVersion = value; }
		}

		public String AsmVer
		{
			get { return this._asmVer; }
			set { this._asmVer = value; }
		}

		public String AsmName
		{
			get { return this._asmName; }
			set { this._asmName = value; }
		}

		public ADM401UUpdateArgs() { }

		public ADM401UUpdateArgs(Boolean hasVersion, String asmVer, String asmName)
		{
			this._hasVersion = hasVersion;
			this._asmVer = asmVer;
			this._asmName = asmName;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM401UUpdateRequest();
		}
	}
}