using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Cpls
{
    [Serializable]
	public class CPLFINDLIBGrdFindArgs : IContractArgs
	{
        protected bool Equals(CPLFINDLIBGrdFindArgs other)
        {
            return string.Equals(_isExist, other._isExist) && string.Equals(_resultForm, other._resultForm) && string.Equals(_find, other._find) && string.Equals(_codeType, other._codeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CPLFINDLIBGrdFindArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_isExist != null ? _isExist.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_resultForm != null ? _resultForm.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_find != null ? _find.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeType != null ? _codeType.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _isExist;
		private String _resultForm;
		private String _find;
		private String _codeType;

		public String IsExist
		{
			get { return this._isExist; }
			set { this._isExist = value; }
		}

		public String ResultForm
		{
			get { return this._resultForm; }
			set { this._resultForm = value; }
		}

		public String Find
		{
			get { return this._find; }
			set { this._find = value; }
		}

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public CPLFINDLIBGrdFindArgs() { }

		public CPLFINDLIBGrdFindArgs(String isExist, String resultForm, String find, String codeType)
		{
			this._isExist = isExist;
			this._resultForm = resultForm;
			this._find = find;
			this._codeType = codeType;
		}

		public IExtensible GetRequestInstance()
		{
			return new CPLFINDLIBGrdFindRequest();
		}
	}
}