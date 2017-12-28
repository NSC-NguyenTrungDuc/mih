using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U12ProtectGroupControlArgs : IContractArgs
	{
    protected bool Equals(OCS0103U12ProtectGroupControlArgs other)
    {
        return string.Equals(_bunho, other._bunho) && string.Equals(_groupSer, other._groupSer) && string.Equals(_orderDate, other._orderDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12ProtectGroupControlArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_groupSer != null ? _groupSer.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _bunho;
		private String _groupSer;
		private String _orderDate;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String GroupSer
		{
			get { return this._groupSer; }
			set { this._groupSer = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public OCS0103U12ProtectGroupControlArgs() { }

		public OCS0103U12ProtectGroupControlArgs(String bunho, String groupSer, String orderDate)
		{
			this._bunho = bunho;
			this._groupSer = groupSer;
			this._orderDate = orderDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12ProtectGroupControlRequest();
		}
	}
}