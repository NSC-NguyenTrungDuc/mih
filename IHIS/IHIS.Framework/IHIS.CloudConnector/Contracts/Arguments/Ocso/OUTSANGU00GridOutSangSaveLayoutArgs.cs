using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using OUTSANGU00InitializeListItemInfo = IHIS.CloudConnector.Contracts.Models.Ocso.OUTSANGU00InitializeListItemInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocso
{[Serializable]
	public class OUTSANGU00GridOutSangSaveLayoutArgs : IContractArgs
	{
    protected bool Equals(OUTSANGU00GridOutSangSaveLayoutArgs other)
    {
        return Equals(_gridOutSangInfo, other._gridOutSangInfo) && string.Equals(_userId, other._userId) && string.Equals(_bunho, other._bunho);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OUTSANGU00GridOutSangSaveLayoutArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_gridOutSangInfo != null ? _gridOutSangInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            return hashCode;
        }
    }

    private List<OUTSANGU00InitializeListItemInfo> _gridOutSangInfo = new List<OUTSANGU00InitializeListItemInfo>();
		private String _userId;
		private String _bunho;

		public List<OUTSANGU00InitializeListItemInfo> GridOutSangInfo
		{
			get { return this._gridOutSangInfo; }
			set { this._gridOutSangInfo = value; }
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

		public OUTSANGU00GridOutSangSaveLayoutArgs() { }

		public OUTSANGU00GridOutSangSaveLayoutArgs(List<OUTSANGU00InitializeListItemInfo> gridOutSangInfo, String userId, String bunho)
		{
			this._gridOutSangInfo = gridOutSangInfo;
			this._userId = userId;
			this._bunho = bunho;
		}

		public IExtensible GetRequestInstance()
		{
			return new OUTSANGU00GridOutSangSaveLayoutRequest();
		}
	}
}