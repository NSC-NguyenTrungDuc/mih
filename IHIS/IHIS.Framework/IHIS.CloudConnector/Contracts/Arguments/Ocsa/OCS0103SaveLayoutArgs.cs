using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OCS0103U13GrdOrderListInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0103U13GrdOrderListInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103SaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OCS0103SaveLayoutArgs other)
    {
        return Equals(_infoList, other._infoList) && string.Equals(_userId, other._userId) && string.Equals(_bunho, other._bunho) && string.Equals(_orderDate, other._orderDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_infoList != null ? _infoList.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderDate != null ? _orderDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<OCS0103U13GrdOrderListInfo> _infoList = new List<OCS0103U13GrdOrderListInfo>();
		private String _userId;
		private String _bunho;
		private String _orderDate;

		public List<OCS0103U13GrdOrderListInfo> InfoList
		{
			get { return this._infoList; }
			set { this._infoList = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

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

		public OCS0103SaveLayoutArgs() { }

		public OCS0103SaveLayoutArgs(List<OCS0103U13GrdOrderListInfo> infoList, String userId, String bunho, String orderDate)
		{
			this._infoList = infoList;
			this._userId = userId;
			this._bunho = bunho;
			this._orderDate = orderDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103SaveLayoutRequest();
		}
	}
}