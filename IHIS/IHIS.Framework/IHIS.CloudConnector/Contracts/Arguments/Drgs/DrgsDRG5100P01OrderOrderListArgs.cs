using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01OrderOrderListArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01OrderOrderListArgs other)
        {
            return string.Equals(_orderDate, other._orderDate) && string.Equals(_drgBunho, other._drgBunho) && string.Equals(_gubun, other._gubun);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01OrderOrderListArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_gubun != null ? _gubun.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _orderDate;
		private String _drgBunho;
		private String _gubun;

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String DrgBunho
		{
			get { return this._drgBunho; }
			set { this._drgBunho = value; }
		}

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public DrgsDRG5100P01OrderOrderListArgs() { }

		public DrgsDRG5100P01OrderOrderListArgs(String orderDate, String drgBunho, String gubun)
		{
			this._orderDate = orderDate;
			this._drgBunho = drgBunho;
			this._gubun = gubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01OrderOrderListRequest();
		}
	}
}