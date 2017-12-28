using System;
using IHIS.CloudConnector.Messaging;
using ProtoBuf;
using ComboDataSourceInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.ComboDataSourceInfo;
using GetUserOptionInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.GetUserOptionInfo;
using LoadColumnCodeNameInfo = IHIS.CloudConnector.Contracts.Models.Ocs.Lib.LoadColumnCodeNameInfo;

namespace IHIS.CloudConnector.Contracts.Arguments.Ocsa
{[Serializable]
	public class OCS0103U11InitializeScreenArgs : IContractArgs
	{
    protected bool Equals(OCS0103U11InitializeScreenArgs other)
    {
        return Equals(_codeInfo, other._codeInfo) && Equals(_userOptionInfo, other._userOptionInfo) && Equals(_orderGubunInfo, other._orderGubunInfo) && Equals(_suryangInfo, other._suryangInfo) && Equals(_nalsuInfo, other._nalsuInfo) && string.Equals(_orderMode, other._orderMode) && string.Equals(_userGubun, other._userGubun) && string.Equals(_doctor, other._doctor) && string.Equals(_memb, other._memb) && string.Equals(_doctorId, other._doctorId) && string.Equals(_userId, other._userId) && string.Equals(_inputTab, other._inputTab);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OCS0103U11InitializeScreenArgs) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (_codeInfo != null ? _codeInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userOptionInfo != null ? _userOptionInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderGubunInfo != null ? _orderGubunInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_suryangInfo != null ? _suryangInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_nalsuInfo != null ? _nalsuInfo.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_orderMode != null ? _orderMode.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userGubun != null ? _userGubun.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctor != null ? _doctor.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_memb != null ? _memb.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_doctorId != null ? _doctorId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_userId != null ? _userId.GetHashCode() : 0);
            hashCode = (hashCode*397) ^ (_inputTab != null ? _inputTab.GetHashCode() : 0);
            return hashCode;
        }
    }

    private LoadColumnCodeNameInfo _codeInfo;
		private GetUserOptionInfo _userOptionInfo;
		private ComboDataSourceInfo _orderGubunInfo;
		private ComboDataSourceInfo _suryangInfo;
		private ComboDataSourceInfo _nalsuInfo;
		private String _orderMode;
		private String _userGubun;
		private String _doctor;
		private String _memb;
		private String _doctorId;
		private String _userId;
		private String _inputTab;

		public LoadColumnCodeNameInfo CodeInfo
		{
			get { return this._codeInfo; }
			set { this._codeInfo = value; }
		}

		public GetUserOptionInfo UserOptionInfo
		{
			get { return this._userOptionInfo; }
			set { this._userOptionInfo = value; }
		}

		public ComboDataSourceInfo OrderGubunInfo
		{
			get { return this._orderGubunInfo; }
			set { this._orderGubunInfo = value; }
		}

		public ComboDataSourceInfo SuryangInfo
		{
			get { return this._suryangInfo; }
			set { this._suryangInfo = value; }
		}

		public ComboDataSourceInfo NalsuInfo
		{
			get { return this._nalsuInfo; }
			set { this._nalsuInfo = value; }
		}

		public String OrderMode
		{
			get { return this._orderMode; }
			set { this._orderMode = value; }
		}

		public String UserGubun
		{
			get { return this._userGubun; }
			set { this._userGubun = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String Memb
		{
			get { return this._memb; }
			set { this._memb = value; }
		}

		public String DoctorId
		{
			get { return this._doctorId; }
			set { this._doctorId = value; }
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

		public OCS0103U11InitializeScreenArgs() { }

		public OCS0103U11InitializeScreenArgs(LoadColumnCodeNameInfo codeInfo, GetUserOptionInfo userOptionInfo, ComboDataSourceInfo orderGubunInfo, ComboDataSourceInfo suryangInfo, ComboDataSourceInfo nalsuInfo, String orderMode, String userGubun, String doctor, String memb, String doctorId, String userId, String inputTab)
		{
			this._codeInfo = codeInfo;
			this._userOptionInfo = userOptionInfo;
			this._orderGubunInfo = orderGubunInfo;
			this._suryangInfo = suryangInfo;
			this._nalsuInfo = nalsuInfo;
			this._orderMode = orderMode;
			this._userGubun = userGubun;
			this._doctor = doctor;
			this._memb = memb;
			this._doctorId = doctorId;
			this._userId = userId;
			this._inputTab = inputTab;
		}

		public IExtensible GetRequestInstance()
		{
			return new OCS0103U11InitializeScreenRequest();
		}
	}
}