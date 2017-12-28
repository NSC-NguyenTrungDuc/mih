using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    [Serializable]
	public class OcsOrderBizLoadComboDataSourceArgs : IContractArgs
	{
        protected bool Equals(OcsOrderBizLoadComboDataSourceArgs other)
        {
            return string.Equals(_aColName, other._aColName) && string.Equals(_aArgu1, other._aArgu1) && string.Equals(_aArgu2, other._aArgu2) && string.Equals(_aArgu3, other._aArgu3);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OcsOrderBizLoadComboDataSourceArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_aColName != null ? _aColName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_aArgu1 != null ? _aArgu1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_aArgu2 != null ? _aArgu2.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_aArgu3 != null ? _aArgu3.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _aColName;
		private String _aArgu1;
		private String _aArgu2;
		private String _aArgu3;

		public String AColName
		{
			get { return this._aColName; }
			set { this._aColName = value; }
		}

		public String AArgu1
		{
			get { return this._aArgu1; }
			set { this._aArgu1 = value; }
		}

		public String AArgu2
		{
			get { return this._aArgu2; }
			set { this._aArgu2 = value; }
		}

		public String AArgu3
		{
			get { return this._aArgu3; }
			set { this._aArgu3 = value; }
		}

		public OcsOrderBizLoadComboDataSourceArgs() { }

		public OcsOrderBizLoadComboDataSourceArgs(String aColName, String aArgu1, String aArgu2, String aArgu3)
		{
			this._aColName = aColName;
			this._aArgu1 = aArgu1;
			this._aArgu2 = aArgu2;
			this._aArgu3 = aArgu3;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsOrderBizLoadComboDataSourceRequest();
		}
	}
}