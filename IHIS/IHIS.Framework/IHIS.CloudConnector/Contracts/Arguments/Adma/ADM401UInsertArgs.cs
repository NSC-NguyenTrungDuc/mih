using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Adma
{
    [Serializable]
	public class ADM401UInsertArgs : IContractArgs
	{
        protected bool Equals(ADM401UInsertArgs other)
        {
            return _hasVersion.Equals(other._hasVersion) && string.Equals(_asmName, other._asmName) && string.Equals(_asmType, other._asmType) && string.Equals(_grpId, other._grpId) && string.Equals(_sysId, other._sysId) && string.Equals(_asmVer, other._asmVer) && string.Equals(_asmPath, other._asmPath) && string.Equals(_userId, other._userId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ADM401UInsertArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _hasVersion.GetHashCode();
                hashCode = (hashCode*397) ^ (_asmName != null ? _asmName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_asmType != null ? _asmType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_grpId != null ? _grpId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_sysId != null ? _sysId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_asmVer != null ? _asmVer.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_asmPath != null ? _asmPath.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
                return hashCode;
            }
        }

        private Boolean _hasVersion;
		private String _asmName;
		private String _asmType;
		private String _grpId;
		private String _sysId;
		private String _asmVer;
		private String _asmPath;
		private String _userId;

		public Boolean HasVersion
		{
			get { return this._hasVersion; }
			set { this._hasVersion = value; }
		}

		public String AsmName
		{
			get { return this._asmName; }
			set { this._asmName = value; }
		}

		public String AsmType
		{
			get { return this._asmType; }
			set { this._asmType = value; }
		}

		public String GrpId
		{
			get { return this._grpId; }
			set { this._grpId = value; }
		}

		public String SysId
		{
			get { return this._sysId; }
			set { this._sysId = value; }
		}

		public String AsmVer
		{
			get { return this._asmVer; }
			set { this._asmVer = value; }
		}

		public String AsmPath
		{
			get { return this._asmPath; }
			set { this._asmPath = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public ADM401UInsertArgs() { }

		public ADM401UInsertArgs(Boolean hasVersion, String asmName, String asmType, String grpId, String sysId, String asmVer, String asmPath, String userId)
		{
			this._hasVersion = hasVersion;
			this._asmName = asmName;
			this._asmType = asmType;
			this._grpId = grpId;
			this._sysId = sysId;
			this._asmVer = asmVer;
			this._asmPath = asmPath;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new ADM401UInsertRequest();
		}
	}
}