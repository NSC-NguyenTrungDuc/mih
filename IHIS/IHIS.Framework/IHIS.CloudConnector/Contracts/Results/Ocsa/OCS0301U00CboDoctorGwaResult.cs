using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
	public class OCS0301U00CboDoctorGwaResult : AbstractContractResult
	{
		private String _gwaInfo;
		private String _userInfo;
		private String _userGubun;
		private List<ComboListItemInfo> _doctorGwaCb = new List<ComboListItemInfo>();

		public String GwaInfo
		{
			get { return this._gwaInfo; }
			set { this._gwaInfo = value; }
		}

		public String UserInfo
		{
			get { return this._userInfo; }
			set { this._userInfo = value; }
		}

		public String UserGubun
		{
			get { return this._userGubun; }
			set { this._userGubun = value; }
		}

		public List<ComboListItemInfo> DoctorGwaCb
		{
			get { return this._doctorGwaCb; }
			set { this._doctorGwaCb = value; }
		}

		public OCS0301U00CboDoctorGwaResult() { }

	}
}