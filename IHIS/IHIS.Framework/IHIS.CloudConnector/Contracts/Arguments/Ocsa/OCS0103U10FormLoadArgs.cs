using System;
using ProtoBuf;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U10FormLoadArgs : IContractArgs
	{
    protected bool Equals(OCS0103U10FormLoadArgs other)
    {
        return Equals(_generalDispYn, other._generalDispYn) && Equals(_sentouSearchYn, other._sentouSearchYn) && string.Equals(_orderMode, other._orderMode) && string.Equals(_bunho, other._bunho) && string.Equals(_pkinp1001, other._pkinp1001) && string.Equals(_inputTab, other._inputTab) && string.Equals(_memb, other._memb) && Equals(_usedTabInfo, other._usedTabInfo) && _isCheckDrgTime.Equals(other._isCheckDrgTime) && Equals(_codeNameInfo, other._codeNameInfo) && Equals(_gwaDoctorCodeInfo, other._gwaDoctorCodeInfo);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U10FormLoadArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_generalDispYn != null ? _generalDispYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_sentouSearchYn != null ? _sentouSearchYn.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderMode != null ? _orderMode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_bunho != null ? _bunho.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_pkinp1001 != null ? _pkinp1001.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_memb != null ? _memb.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_usedTabInfo != null ? _usedTabInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ _isCheckDrgTime.GetHashCode();
            hashCode = (hashCode*397) ^ (_codeNameInfo != null ? _codeNameInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_gwaDoctorCodeInfo != null ? _gwaDoctorCodeInfo.GetHashCode() : 0);
            return hashCode;
        }
    }

    private GetUserOptionInfo _generalDispYn;
		private GetUserOptionInfo _sentouSearchYn;
		private String _orderMode;
		private String _bunho;
		private String _pkinp1001;
		private String _inputTab;
		private String _memb;
		private LoadOftenUsedTabInfo _usedTabInfo;
		private Boolean _isCheckDrgTime;
		private LoadColumnCodeNameInfo _codeNameInfo;
		private GetMainGwaDoctorCodeInfo _gwaDoctorCodeInfo;

		public GetUserOptionInfo GeneralDispYn
		{
			get { return this._generalDispYn; }
			set { this._generalDispYn = value; }
		}

		public GetUserOptionInfo SentouSearchYn
		{
			get { return this._sentouSearchYn; }
			set { this._sentouSearchYn = value; }
		}

		public String OrderMode
		{
			get { return this._orderMode; }
			set { this._orderMode = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Pkinp1001
		{
			get { return this._pkinp1001; }
			set { this._pkinp1001 = value; }
		}

		public String InputTab
		{
			get { return this._inputTab; }
			set { this._inputTab = value; }
		}

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public LoadOftenUsedTabInfo UsedTabInfo
		{
			get { return this._usedTabInfo; }
			set { this._usedTabInfo = value; }
		}

		public Boolean IsCheckDrgTime
		{
			get { return this._isCheckDrgTime; }
			set { this._isCheckDrgTime = value; }
		}

		public LoadColumnCodeNameInfo CodeNameInfo
		{
			get { return this._codeNameInfo; }
			set { this._codeNameInfo = value; }
		}

		public GetMainGwaDoctorCodeInfo GwaDoctorCodeInfo
		{
			get { return this._gwaDoctorCodeInfo; }
			set { this._gwaDoctorCodeInfo = value; }
		}

		public OCS0103U10FormLoadArgs() { }

		public OCS0103U10FormLoadArgs(GetUserOptionInfo generalDispYn, GetUserOptionInfo sentouSearchYn, String orderMode, String bunho, String pkinp1001, String inputTab, String memb, LoadOftenUsedTabInfo usedTabInfo, Boolean isCheckDrgTime, LoadColumnCodeNameInfo codeNameInfo, GetMainGwaDoctorCodeInfo gwaDoctorCodeInfo)
		{
			this._generalDispYn = generalDispYn;
			this._sentouSearchYn = sentouSearchYn;
			this._orderMode = orderMode;
			this._bunho = bunho;
			this._pkinp1001 = pkinp1001;
			this._inputTab = inputTab;
			this._memb = memb;
			this._usedTabInfo = usedTabInfo;
			this._isCheckDrgTime = isCheckDrgTime;
			this._codeNameInfo = codeNameInfo;
			this._gwaDoctorCodeInfo = gwaDoctorCodeInfo;
		}

		public IExtensible GetRequestInstance()
		{
			return new IHIS.CloudConnector.Messaging.OCS0103U10FormLoadRequest();
		}
	}
}