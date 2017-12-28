using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OCSAPPROVEGrdOrderInfo = IHIS.CloudConnector.Contracts.Models.Ocsa.OCSAPPROVEGrdOrderInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCSAPPROVESaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OCSAPPROVESaveLayoutArgs other)
    {
        return string.Equals(_userId, other._userId) && string.Equals(_selectedIogubun, other._selectedIogubun) && Equals(_grdList, other._grdList);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCSAPPROVESaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_selectedIogubun != null ? _selectedIogubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_grdList != null ? _grdList.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<OCSAPPROVEGrdOrderInfo> _grdList = new List<OCSAPPROVEGrdOrderInfo>();
		private String _userId;
		private String _selectedIogubun;

		public List<OCSAPPROVEGrdOrderInfo> GrdList
		{
			get { return this._grdList; }
			set { this._grdList = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String SelectedIogubun
		{
			get { return this._selectedIogubun; }
			set { this._selectedIogubun = value; }
		}

		public OCSAPPROVESaveLayoutArgs() { }

		public OCSAPPROVESaveLayoutArgs(List<OCSAPPROVEGrdOrderInfo> grdList, String userId, String selectedIogubun)
		{
			this._grdList = grdList;
			this._userId = userId;
			this._selectedIogubun = selectedIogubun;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCSAPPROVESaveLayoutRequest();
		}
	}
}