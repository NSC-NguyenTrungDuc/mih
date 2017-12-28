using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using GetMainGwaDoctorCodeInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.GetMainGwaDoctorCodeInfo;
using LoadColumnCodeNameInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.LoadColumnCodeNameInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{
    [Serializable]
	public class OCS0103U18InitializeScreenArgs : IContractArgs
	{
    protected bool Equals(OCS0103U18InitializeScreenArgs other)
    {
        return string.Equals(_mOrderMode, other._mOrderMode) && Equals(_colCodeName, other._colCodeName) && Equals(_gwaDoctorCode, other._gwaDoctorCode) && string.Equals(_userId, other._userId) && string.Equals(_inputTab, other._inputTab);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U18InitializeScreenArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_mOrderMode != null ? _mOrderMode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_colCodeName != null ? _colCodeName.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwaDoctorCode != null ? _gwaDoctorCode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            return hashCode;
        }
    }

    private String _mOrderMode;
		private LoadColumnCodeNameInfo _colCodeName;
		private GetMainGwaDoctorCodeInfo _gwaDoctorCode;
		private String _userId;
		private String _inputTab;

		public String MOrderMode
		{
			get { return this._mOrderMode; }
			set { this._mOrderMode = value; }
		}

		public LoadColumnCodeNameInfo ColCodeName
		{
			get { return this._colCodeName; }
			set { this._colCodeName = value; }
		}

		public GetMainGwaDoctorCodeInfo GwaDoctorCode
		{
			get { return this._gwaDoctorCode; }
			set { this._gwaDoctorCode = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public OCS0103U18InitializeScreenArgs() { }

		public OCS0103U18InitializeScreenArgs(String mOrderMode, LoadColumnCodeNameInfo colCodeName, GetMainGwaDoctorCodeInfo gwaDoctorCode, String userId, String inputTab)
		{
			this._mOrderMode = mOrderMode;
			this._colCodeName = colCodeName;
			this._gwaDoctorCode = gwaDoctorCode;
			this._userId = userId;
			this._inputTab = inputTab;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U18InitializeScreenRequest();
		}
	}
}