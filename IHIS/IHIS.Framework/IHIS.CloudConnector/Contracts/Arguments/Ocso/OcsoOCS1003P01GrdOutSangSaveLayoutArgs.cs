using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OcsoOCS1003P01GridOutSangInfo = IHIS.CloudConnector.Contracts.Models.Ocso.OcsoOCS1003P01GridOutSangInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OcsoOCS1003P01GrdOutSangSaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OcsoOCS1003P01GrdOutSangSaveLayoutArgs other)
    {
        return Equals(_grdOutSangList, other._grdOutSangList) && string.Equals(_userId, other._userId);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OcsoOCS1003P01GrdOutSangSaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((_grdOutSangList != null ? _grdOutSangList.GetHashCode() : 0)*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
        }
    }

    private List<OcsoOCS1003P01GridOutSangInfo> _grdOutSangList = new List<OcsoOCS1003P01GridOutSangInfo>();
		private String _userId;

		public List<OcsoOCS1003P01GridOutSangInfo> GrdOutSangList
		{
			get { return this._grdOutSangList; }
			set { this._grdOutSangList = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public OcsoOCS1003P01GrdOutSangSaveLayoutArgs() { }

		public OcsoOCS1003P01GrdOutSangSaveLayoutArgs(List<OcsoOCS1003P01GridOutSangInfo> grdOutSangList, String userId)
		{
			this._grdOutSangList = grdOutSangList;
			this._userId = userId;
		}

		public IExtensible GetRequestInstance()
		{
			return new OcsoOCS1003P01GrdOutSangSaveLayoutRequest();
		}
	}
}