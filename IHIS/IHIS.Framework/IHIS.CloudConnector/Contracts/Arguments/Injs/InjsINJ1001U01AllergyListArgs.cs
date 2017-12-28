using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Injs
{
    [Serializable]
	public class InjsINJ1001U01AllergyListArgs : IContractArgs
	{
        protected bool Equals(InjsINJ1001U01AllergyListArgs other)
        {
            return string.Equals(_bunho, other._bunho) && string.Equals(_queryDate, other._queryDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InjsINJ1001U01AllergyListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_queryDate != null ? _queryDate.GetHashCode() : 0);
            }
        }

        private String _bunho;
		private String _queryDate;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String QueryDate
		{
			get { return this._queryDate; }
			set { this._queryDate = value; }
		}

		public InjsINJ1001U01AllergyListArgs() { }

		public InjsINJ1001U01AllergyListArgs(String bunho, String queryDate)
		{
			this._bunho = bunho;
			this._queryDate = queryDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new InjsINJ1001U01AllergyListRequest();
		}
	}
}