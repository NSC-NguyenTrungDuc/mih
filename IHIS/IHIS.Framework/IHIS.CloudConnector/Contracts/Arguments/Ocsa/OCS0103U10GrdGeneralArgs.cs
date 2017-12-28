using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U10GrdGeneralArgs : IContractArgs
	{
    protected bool Equals(OCS0103U10GrdGeneralArgs other)
    {
        return string.Equals(_filter, other._filter) && string.Equals(_yakKijunCode, other._yakKijunCode) && string.Equals(_orderDate, other._orderDate) && string.Equals(_hangmogCode, other._hangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U10GrdGeneralArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_filter != null ? _filter.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_yakKijunCode != null ? _yakKijunCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _filter;
		private String _yakKijunCode;
		private String _orderDate;
		private String _hangmogCode;

		public String Filter
		{
			get { return this._filter; }
			set { this._filter = value; }
		}

		public String YakKijunCode
		{
			get { return this._yakKijunCode; }
			set { this._yakKijunCode = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public OCS0103U10GrdGeneralArgs() { }

		public OCS0103U10GrdGeneralArgs(String filter, String yakKijunCode, String orderDate, String hangmogCode)
		{
			this._filter = filter;
			this._yakKijunCode = yakKijunCode;
			this._orderDate = orderDate;
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U10GrdGeneralRequest();
		}
	}
}