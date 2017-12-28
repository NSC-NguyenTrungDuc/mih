using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuri
{
    [Serializable]
	public class NUR1016U00GetComboListArgs : IContractArgs
	{
        protected bool Equals(NUR1016U00GetComboListArgs other)
        {
            return string.Equals(_codeTypeLayComboSet, other._codeTypeLayComboSet);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NUR1016U00GetComboListArgs) obj);
        }

        public override int GetHashCode()
        {
            return (_codeTypeLayComboSet != null ? _codeTypeLayComboSet.GetHashCode() : 0);
        }

        private String _codeTypeLayComboSet;

		public String CodeTypeLayComboSet
		{
			get { return this._codeTypeLayComboSet; }
			set { this._codeTypeLayComboSet = value; }
		}

		public NUR1016U00GetComboListArgs() { }

		public NUR1016U00GetComboListArgs(String codeTypeLayComboSet)
		{
			this._codeTypeLayComboSet = codeTypeLayComboSet;
		}

		public IExtensible GetRequestInstance()
		{
			return new NUR1016U00GetComboListRequest();
		}
	}
}