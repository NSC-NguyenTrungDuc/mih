using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class INJ1002R01LayQuery2Args : IContractArgs
	{
        protected bool Equals(INJ1002R01LayQuery2Args other)
        {
            return string.Equals(_fromDate, other._fromDate) && string.Equals(_toDate, other._toDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((INJ1002R01LayQuery2Args) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_fromDate != null ? _fromDate.GetHashCode() : 0)*397) ^ (_toDate != null ? _toDate.GetHashCode() : 0);
            }
        }

        private String _fromDate;
		private String _toDate;

		public String FromDate
		{
			get { return this._fromDate; }
			set { this._fromDate = value; }
		}

		public String ToDate
		{
			get { return this._toDate; }
			set { this._toDate = value; }
		}

		public INJ1002R01LayQuery2Args() { }

		public INJ1002R01LayQuery2Args(String fromDate, String toDate)
		{
			this._fromDate = fromDate;
			this._toDate = toDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new INJ1002R01LayQuery2Request();
		}
	}
}