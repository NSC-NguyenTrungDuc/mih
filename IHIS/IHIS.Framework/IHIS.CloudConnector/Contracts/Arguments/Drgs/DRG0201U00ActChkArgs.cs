using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DRG0201U00ActChkArgs : IContractArgs
	{
        protected bool Equals(DRG0201U00ActChkArgs other)
        {
            return string.Equals(_orderDate, other._orderDate) && string.Equals(_drgBunho, other._drgBunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DRG0201U00ActChkArgs) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_orderDate != null ? _orderDate.GetHashCode() : 0)*397) ^ (_drgBunho != null ? _drgBunho.GetHashCode() : 0);
            }
        }

        private String _orderDate;
		private String _drgBunho;

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

		public DRG0201U00ActChkArgs() { }

		public DRG0201U00ActChkArgs(String orderDate, String drgBunho)
		{
			this._orderDate = orderDate;
			this._drgBunho = drgBunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DRG0201U00ActChkRequest();
		}
	}
}