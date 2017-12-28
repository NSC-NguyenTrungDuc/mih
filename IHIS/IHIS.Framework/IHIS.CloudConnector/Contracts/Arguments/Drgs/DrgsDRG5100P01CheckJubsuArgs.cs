using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Drgs
{
    [Serializable]
	public class DrgsDRG5100P01CheckJubsuArgs : IContractArgs
	{
        protected bool Equals(DrgsDRG5100P01CheckJubsuArgs other)
        {
            return string.Equals(_orderDate, other._orderDate) && string.Equals(_drgBunho, other._drgBunho);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DrgsDRG5100P01CheckJubsuArgs) obj);
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

		public DrgsDRG5100P01CheckJubsuArgs() { }

		public DrgsDRG5100P01CheckJubsuArgs(String orderDate, String drgBunho)
		{
			this._orderDate = orderDate;
			this._drgBunho = drgBunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new DrgsDRG5100P01CheckJubsuRequest();
		}
	}
}