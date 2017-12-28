using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bass
{
    [Serializable]
	public class BAS0210U00grdBAS0210Args : IContractArgs
	{
        protected bool Equals(BAS0210U00grdBAS0210Args other)
        {
            return string.Equals(_gubunCode, other._gubunCode) && string.Equals(_startDate, other._startDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BAS0210U00grdBAS0210Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_gubunCode != null ? _gubunCode.GetHashCode() : 0)*397) ^ (_startDate != null ? _startDate.GetHashCode() : 0);
            }
        }

        private String _gubunCode;
		private String _startDate;

		public String GubunCode
		{
			get { return this._gubunCode; }
			set { this._gubunCode = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public BAS0210U00grdBAS0210Args() { }

		public BAS0210U00grdBAS0210Args(String gubunCode, String startDate)
		{
			this._gubunCode = gubunCode;
			this._startDate = startDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new BAS0210U00grdBAS0210Request();
		}
	}
}