using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0110Q00GrdBAS0110Args : IContractArgs
	{
        protected bool Equals(BAS0110Q00GrdBAS0110Args other)
        {
            return string.Equals(_johapGubun, other._johapGubun) && string.Equals(_searchGubun, other._searchGubun) && string.Equals(_searchWord, other._searchWord);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0110Q00GrdBAS0110Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_johapGubun != null ? _johapGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_searchGubun != null ? _searchGubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_searchWord != null ? _searchWord.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _johapGubun;
		private String _searchGubun;
		private String _searchWord;

		public String JohapGubun
		{
			get { return this._johapGubun; }
			set { this._johapGubun = value; }
		}

		public String SearchGubun
		{
			get { return this._searchGubun; }
			set { this._searchGubun = value; }
		}

		public String SearchWord
		{
			get { return this._searchWord; }
			set { this._searchWord = value; }
		}

		public BAS0110Q00GrdBAS0110Args() { }

		public BAS0110Q00GrdBAS0110Args(String johapGubun, String searchGubun, String searchWord)
		{
			this._johapGubun = johapGubun;
			this._searchGubun = searchGubun;
			this._searchWord = searchWord;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0110Q00GrdBAS0110Request();
		}
	}
}