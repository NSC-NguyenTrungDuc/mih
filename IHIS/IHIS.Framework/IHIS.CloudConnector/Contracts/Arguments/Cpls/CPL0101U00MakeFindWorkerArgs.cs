using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPL0101U00MakeFindWorkerArgs : IContractArgs
	{
        protected bool Equals(CPL0101U00MakeFindWorkerArgs other)
        {
            return string.Equals(_aCtrName, other._aCtrName) && string.Equals(_codeType, other._codeType) && string.Equals(_find1, other._find1) && string.Equals(_find2, other._find2) && string.Equals(_systemGubun, other._systemGubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPL0101U00MakeFindWorkerArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_aCtrName != null ? _aCtrName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find1 != null ? _find1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find2 != null ? _find2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_systemGubun != null ? _systemGubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _aCtrName;
		private String _codeType;
		private String _find1;
		private String _find2;
		private String _systemGubun;

		public String ACtrName
		{
			get { return this._aCtrName; }
			set { this._aCtrName = value; }
		}

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

		public String Find2
		{
			get { return this._find2; }
			set { this._find2 = value; }
		}

		public String SystemGubun
		{
			get { return this._systemGubun; }
			set { this._systemGubun = value; }
		}

		public CPL0101U00MakeFindWorkerArgs() { }

		public CPL0101U00MakeFindWorkerArgs(String aCtrName, String codeType, String find1, String find2, String systemGubun)
		{
			this._aCtrName = aCtrName;
			this._codeType = codeType;
			this._find1 = find1;
			this._find2 = find2;
			this._systemGubun = systemGubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPL0101U00MakeFindWorkerRequest();
		}
	}
}