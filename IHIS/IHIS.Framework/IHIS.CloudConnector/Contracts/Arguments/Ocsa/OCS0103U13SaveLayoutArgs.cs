using System;
using ProtoBuf;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U13SaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OCS0103U13SaveLayoutArgs other)
    {
        return Equals(_listItemInfo, other._listItemInfo) && string.Equals(_userId, other._userId) && Equals(_rowState, other._rowState) && string.Equals(_callerId, other._callerId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U13SaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_listItemInfo != null ? _listItemInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_rowState != null ? _rowState.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_callerId != null ? _callerId.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<OCS0103U13GrdOrderListInfo> _listItemInfo = new List<OCS0103U13GrdOrderListInfo>();
		private String _userId;
		private List<DataStringListItemInfo> _rowState = new List<DataStringListItemInfo>();
		private String _callerId;

		public List<OCS0103U13GrdOrderListInfo> ListItemInfo
		{
			get { return this._listItemInfo; }
			set { this._listItemInfo = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public List<DataStringListItemInfo> RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public String CallerId
		{
			get { return this._callerId; }
			set { this._callerId = value; }
		}

		public OCS0103U13SaveLayoutArgs() { }

		public OCS0103U13SaveLayoutArgs(List<OCS0103U13GrdOrderListInfo> listItemInfo, String userId, List<DataStringListItemInfo> rowState, String callerId)
		{
			this._listItemInfo = listItemInfo;
			this._userId = userId;
			this._rowState = rowState;
			this._callerId = callerId;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.OCS0103U13SaveLayoutRequest();
		}
	}
}