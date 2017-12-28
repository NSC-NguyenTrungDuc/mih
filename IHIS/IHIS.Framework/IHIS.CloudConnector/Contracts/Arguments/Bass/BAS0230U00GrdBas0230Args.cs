using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0230U00GrdBas0230Args : IContractArgs
	{
        protected bool Equals(BAS0230U00GrdBas0230Args other)
        {
            return string.Equals(_startYmd, other._startYmd);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0230U00GrdBas0230Args) obj);
        }

        public override int GetHashCode()
        {
            return (_startYmd != null ? _startYmd.GetHashCode() : 0);
        }

        private String _startYmd;

		public String StartYmd
		{
			get { return this._startYmd; }
			set { this._startYmd = value; }
		}

		public BAS0230U00GrdBas0230Args() { }

		public BAS0230U00GrdBas0230Args(String startYmd)
		{
			this._startYmd = startYmd;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0230U00GrdBas0230Request();
		}
	}
}