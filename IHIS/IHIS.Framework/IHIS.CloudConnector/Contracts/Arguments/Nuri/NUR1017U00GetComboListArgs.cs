using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NUR1017U00GetComboListArgs : IContractArgs
	{
        protected bool Equals(NUR1017U00GetComboListArgs other)
        {
            return string.Equals(_codeTypeXEditGridCell1, other._codeTypeXEditGridCell1) && string.Equals(_codeTypeXEditGridCell5, other._codeTypeXEditGridCell5) && string.Equals(_codeTypeXEditGridCell6, other._codeTypeXEditGridCell6) && string.Equals(_codeTypeLayComboSet, other._codeTypeLayComboSet);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR1017U00GetComboListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_codeTypeXEditGridCell1 != null ? _codeTypeXEditGridCell1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeTypeXEditGridCell5 != null ? _codeTypeXEditGridCell5.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeTypeXEditGridCell6 != null ? _codeTypeXEditGridCell6.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_codeTypeLayComboSet != null ? _codeTypeLayComboSet.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _codeTypeXEditGridCell1;
		private String _codeTypeXEditGridCell5;
		private String _codeTypeXEditGridCell6;
		private String _codeTypeLayComboSet;

		public String CodeTypeXEditGridCell1
		{
			get { return this._codeTypeXEditGridCell1; }
			set { this._codeTypeXEditGridCell1 = value; }
		}

		public String CodeTypeXEditGridCell5
		{
			get { return this._codeTypeXEditGridCell5; }
			set { this._codeTypeXEditGridCell5 = value; }
		}

		public String CodeTypeXEditGridCell6
		{
			get { return this._codeTypeXEditGridCell6; }
			set { this._codeTypeXEditGridCell6 = value; }
		}

		public String CodeTypeLayComboSet
		{
			get { return this._codeTypeLayComboSet; }
			set { this._codeTypeLayComboSet = value; }
		}

		public NUR1017U00GetComboListArgs() { }

		public NUR1017U00GetComboListArgs(String codeTypeXEditGridCell1, String codeTypeXEditGridCell5, String codeTypeXEditGridCell6, String codeTypeLayComboSet)
		{
			this._codeTypeXEditGridCell1 = codeTypeXEditGridCell1;
			this._codeTypeXEditGridCell5 = codeTypeXEditGridCell5;
			this._codeTypeXEditGridCell6 = codeTypeXEditGridCell6;
			this._codeTypeLayComboSet = codeTypeLayComboSet;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUR1017U00GetComboListRequest();
		}
	}
}