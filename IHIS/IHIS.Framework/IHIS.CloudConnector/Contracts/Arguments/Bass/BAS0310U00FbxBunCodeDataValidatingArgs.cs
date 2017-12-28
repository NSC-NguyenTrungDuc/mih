using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0310U00FbxBunCodeDataValidatingArgs : IContractArgs
	{
        protected bool Equals(BAS0310U00FbxBunCodeDataValidatingArgs other)
        {
            return string.Equals(_bunCode, other._bunCode) && string.Equals(_code, other._code) && string.Equals(_colName, other._colName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0310U00FbxBunCodeDataValidatingArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_bunCode != null ? _bunCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_code != null ? _code.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_colName != null ? _colName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _bunCode;
		private String _code;
		private String _colName;

		public String BunCode
		{
			get { return this._bunCode; }
			set { this._bunCode = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String ColName
		{
			get { return this._colName; }
			set { this._colName = value; }
		}

		public BAS0310U00FbxBunCodeDataValidatingArgs() { }

		public BAS0310U00FbxBunCodeDataValidatingArgs(String bunCode, String code, String colName)
		{
			this._bunCode = bunCode;
			this._code = code;
			this._colName = colName;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0310U00FbxBunCodeDataValidatingRequest();
		}
	}
}