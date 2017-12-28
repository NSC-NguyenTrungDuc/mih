using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class InjsINJ1001U01ActorListItemInfo
	{
		private String _userId;
		private String _userNm;
		private String _deptCode;

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String UserNm
		{
			get { return this._userNm; }
			set { this._userNm = value; }
		}

		public String DeptCode
		{
			get { return this._deptCode; }
			set { this._deptCode = value; }
		}

		public InjsINJ1001U01ActorListItemInfo() { }

		public InjsINJ1001U01ActorListItemInfo(String userId, String userNm, String deptCode)
		{
			this._userId = userId;
			this._userNm = userNm;
			this._deptCode = deptCode;
		}

	}
}