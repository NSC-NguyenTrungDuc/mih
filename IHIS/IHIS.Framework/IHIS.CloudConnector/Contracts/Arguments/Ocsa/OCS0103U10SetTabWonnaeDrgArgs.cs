using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U10SetTabWonnaeDrgArgs : IContractArgs
	{
    protected bool Equals(OCS0103U10SetTabWonnaeDrgArgs other)
    {
        return string.Equals(_yakKijunCode, other._yakKijunCode) && string.Equals(_orderDate, other._orderDate) && string.Equals(_inputTab, other._inputTab) && string.Equals(_hangmogCode, other._hangmogCode);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U10SetTabWonnaeDrgArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_yakKijunCode != null ? _yakKijunCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_hangmogCode != null ? _hangmogCode.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _yakKijunCode;
		private String _orderDate;
		private String _inputTab;
		private String _hangmogCode;

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

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public OCS0103U10SetTabWonnaeDrgArgs() { }

		public OCS0103U10SetTabWonnaeDrgArgs(String yakKijunCode, String orderDate, String inputTab, String hangmogCode)
		{
			this._yakKijunCode = yakKijunCode;
			this._orderDate = orderDate;
			this._inputTab = inputTab;
			this._hangmogCode = hangmogCode;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U10SetTabWonnaeDrgRequest();
		}
	}
}