using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OCS1003P01LayDeletedDataListItemInfo = IHIS.CloudConnector.Contracts.Models.Ocso.OCS1003P01LayDeletedDataListItemInfo;
using OCS1003P01LaySaveLayoutListItemInfo = IHIS.CloudConnector.Contracts.Models.Ocso.OCS1003P01LaySaveLayoutListItemInfo;
using OcsoOCS1003P01GridOutSangInfo = IHIS.CloudConnector.Contracts.Models.Ocso.OcsoOCS1003P01GridOutSangInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OCS1003P01SaveLayOutArgs : IContractArgs
	{
    protected bool Equals(OCS1003P01SaveLayOutArgs other)
    {
        return Equals(_grdOutSangList, other._grdOutSangList) && Equals(_layDeleteList, other._layDeleteList) && Equals(_laySaveList, other._laySaveList) && string.Equals(_userId, other._userId) && string.Equals(_naewonKey, other._naewonKey) && string.Equals(_naewonDate, other._naewonDate);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS1003P01SaveLayOutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_grdOutSangList != null ? _grdOutSangList.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_layDeleteList != null ? _layDeleteList.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_laySaveList != null ? _laySaveList.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonKey != null ? _naewonKey.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_naewonDate != null ? _naewonDate.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<OcsoOCS1003P01GridOutSangInfo> _grdOutSangList = new List<OcsoOCS1003P01GridOutSangInfo>();
		private List<OCS1003P01LayDeletedDataListItemInfo> _layDeleteList = new List<OCS1003P01LayDeletedDataListItemInfo>();
		private List<OCS1003P01LaySaveLayoutListItemInfo> _laySaveList = new List<OCS1003P01LaySaveLayoutListItemInfo>();
		private String _userId;
		private String _naewonKey;
		private String _naewonDate;

		public List<OcsoOCS1003P01GridOutSangInfo> GrdOutSangList
		{
			get { return this._grdOutSangList; }
			set { this._grdOutSangList = value; }
		}

		public List<OCS1003P01LayDeletedDataListItemInfo> LayDeleteList
		{
			get { return this._layDeleteList; }
			set { this._layDeleteList = value; }
		}

		public List<OCS1003P01LaySaveLayoutListItemInfo> LaySaveList
		{
			get { return this._laySaveList; }
			set { this._laySaveList = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String NaewonKey
		{
			get { return this._naewonKey; }
			set { this._naewonKey = value; }
		}

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public OCS1003P01SaveLayOutArgs() { }

		public OCS1003P01SaveLayOutArgs(List<OcsoOCS1003P01GridOutSangInfo> grdOutSangList, List<OCS1003P01LayDeletedDataListItemInfo> layDeleteList, List<OCS1003P01LaySaveLayoutListItemInfo> laySaveList, String userId, String naewonKey, String naewonDate)
		{
			this._grdOutSangList = grdOutSangList;
			this._layDeleteList = layDeleteList;
			this._laySaveList = laySaveList;
			this._userId = userId;
			this._naewonKey = naewonKey;
			this._naewonDate = naewonDate;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS1003P01SaveLayOutRequest();
		}
	}
}