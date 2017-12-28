using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG9040U01GrdOrderListOutArgs : IContractArgs
	{
        protected bool Equals(DRG9040U01GrdOrderListOutArgs other)
        {
            return string.Equals(_orderDate, other._orderDate) && string.Equals(_drgBunho, other._drgBunho) && string.Equals(_bunho, other._bunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG9040U01GrdOrderListOutArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_orderDate != null ? _orderDate.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
                return hashCode;
            }
        }

        private String _orderDate;
		private String _drgBunho;
		private String _bunho;

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

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public DRG9040U01GrdOrderListOutArgs() { }

		public DRG9040U01GrdOrderListOutArgs(String orderDate, String drgBunho, String bunho)
		{
			this._orderDate = orderDate;
			this._drgBunho = drgBunho;
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG9040U01GrdOrderListOutRequest();
		}
	}
}