using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U13PrOcsApplyNdayOrderArgs : IContractArgs
	{
    protected bool Equals(OCS0103U13PrOcsApplyNdayOrderArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U13PrOcsApplyNdayOrderArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_bunho != null ? _bunho.GetHashCode() : 0)*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
        }
    }

    private String _bunho;
		private String _orderDate;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public OCS0103U13PrOcsApplyNdayOrderArgs() { }

		public OCS0103U13PrOcsApplyNdayOrderArgs(String bunho, String orderDate)
		{
			this._bunho = bunho;
			this._orderDate = orderDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U13PrOcsApplyNdayOrderRequest();
		}
	}
}