using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0201U00GrdPaidArgs : IContractArgs
	{
        protected bool Equals(DRG0201U00GrdPaidArgs other)
        {
            return string.Equals(_orderDate, other._orderDate) && string.Equals(_gubun, other._gubun) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0201U00GrdPaidArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _orderDate;
		private String _gubun;
		private String _bunho;

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public DRG0201U00GrdPaidArgs() { }

		public DRG0201U00GrdPaidArgs(String orderDate, String gubun, String bunho)
		{
			this._orderDate = orderDate;
			this._gubun = gubun;
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0201U00GrdPaidRequest();
		}
	}
}