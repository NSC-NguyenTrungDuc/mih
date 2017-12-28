using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U12SetTabWonnaeDrugArgs : IContractArgs
	{
    protected bool Equals(OCS0103U12SetTabWonnaeDrugArgs other)
    {
        return string.Equals(_yakKijunCode, other._yakKijunCode) && string.Equals(_hangmogCode, other._hangmogCode) && string.Equals(_orderDate, other._orderDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U12SetTabWonnaeDrugArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_yakKijunCode != null ? _yakKijunCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _yakKijunCode;
		private String _hangmogCode;
		private String _orderDate;

		public String YakKijunCode
		{
			get { return this._yakKijunCode; }
			set { this._yakKijunCode = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public OCS0103U12SetTabWonnaeDrugArgs() { }

		public OCS0103U12SetTabWonnaeDrugArgs(String yakKijunCode, String hangmogCode, String orderDate)
		{
			this._yakKijunCode = yakKijunCode;
			this._hangmogCode = hangmogCode;
			this._orderDate = orderDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U12SetTabWonnaeDrugRequest();
		}
	}
}