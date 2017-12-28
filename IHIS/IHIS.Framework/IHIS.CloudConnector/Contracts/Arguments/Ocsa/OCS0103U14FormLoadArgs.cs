using System;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U14FormLoadArgs : IContractArgs
	{
    protected bool Equals(OCS0103U14FormLoadArgs other)
    {
        return Equals(_userOptInfo, other._userOptInfo) && string.Equals(_mOrderMode, other._mOrderMode) && Equals(_colCodeNameInfo, other._colCodeNameInfo) && Equals(_gwaDoctorCodeInfo, other._gwaDoctorCodeInfo) && Equals(_usedTabInfo, other._usedTabInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U14FormLoadArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_userOptInfo != null ? _userOptInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_mOrderMode != null ? _mOrderMode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_colCodeNameInfo != null ? _colCodeNameInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwaDoctorCodeInfo != null ? _gwaDoctorCodeInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_usedTabInfo != null ? _usedTabInfo.GetHashCode() : 0);
            return hashCode;
        }
    }

    private GetUserOptionInfo _userOptInfo;
		private String _mOrderMode;
		private LoadColumnCodeNameInfo _colCodeNameInfo;
		private GetMainGwaDoctorCodeInfo _gwaDoctorCodeInfo;
		private LoadOftenUsedTabInfo _usedTabInfo;

		public GetUserOptionInfo UserOptInfo
		{
			get { return this._userOptInfo; }
			set { this._userOptInfo = value; }
		}

		public String MOrderMode
		{
			get { return this._mOrderMode; }
			set { this._mOrderMode = value; }
		}

		public LoadColumnCodeNameInfo ColCodeNameInfo
		{
			get { return this._colCodeNameInfo; }
			set { this._colCodeNameInfo = value; }
		}

		public GetMainGwaDoctorCodeInfo GwaDoctorCodeInfo
		{
			get { return this._gwaDoctorCodeInfo; }
			set { this._gwaDoctorCodeInfo = value; }
		}

		public LoadOftenUsedTabInfo UsedTabInfo
		{
			get { return this._usedTabInfo; }
			set { this._usedTabInfo = value; }
		}

		public OCS0103U14FormLoadArgs() { }

		public OCS0103U14FormLoadArgs(GetUserOptionInfo userOptInfo, String mOrderMode, LoadColumnCodeNameInfo colCodeNameInfo, GetMainGwaDoctorCodeInfo gwaDoctorCodeInfo, LoadOftenUsedTabInfo usedTabInfo)
		{
			this._userOptInfo = userOptInfo;
			this._mOrderMode = mOrderMode;
			this._colCodeNameInfo = colCodeNameInfo;
			this._gwaDoctorCodeInfo = gwaDoctorCodeInfo;
			this._usedTabInfo = usedTabInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.OCS0103U14FormLoadRequest();
		}
	}
}