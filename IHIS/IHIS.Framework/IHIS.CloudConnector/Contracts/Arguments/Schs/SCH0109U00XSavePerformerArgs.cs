using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using SCH0109U00GrdDetailInfo = IHIS.CloudConnector.Contracts.Models.Schs.SCH0109U00GrdDetailInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Schs
{[Serializable]
	public class SCH0109U00XSavePerformerArgs : IContractArgs
	{
    protected bool Equals(SCH0109U00XSavePerformerArgs other)
    {
        return Equals(_grdDetailList, other._grdDetailList) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SCH0109U00XSavePerformerArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_grdDetailList != null ? _grdDetailList.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
        }
    }

    private List<SCH0109U00GrdDetailInfo> _grdDetailList = new List<SCH0109U00GrdDetailInfo>();
		private String _userId;

		public List<SCH0109U00GrdDetailInfo> GrdDetailList
		{
			get { return this._grdDetailList; }
			set { this._grdDetailList = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public SCH0109U00XSavePerformerArgs() { }

		public SCH0109U00XSavePerformerArgs(List<SCH0109U00GrdDetailInfo> grdDetailList, String userId)
		{
			this._grdDetailList = grdDetailList;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new SCH0109U00XSavePerformerRequest();
		}
	}
}