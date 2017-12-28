using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class Ocs0131U01Grd0131ListItemInfo
	{
		private String _codeType;
		private String _codeTypeName;
		private String _adminGubun;
		private String _ment;
		private String _choiceUser;
		private String _userId;
		private String _dataRowState;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String CodeTypeName
		{
			get { return this._codeTypeName; }
			set { this._codeTypeName = value; }
		}

		public String AdminGubun
		{
			get { return this._adminGubun; }
			set { this._adminGubun = value; }
		}

		public String Ment
		{
			get { return this._ment; }
			set { this._ment = value; }
		}

		public String ChoiceUser
		{
			get { return this._choiceUser; }
			set { this._choiceUser = value; }
		}

		public String UserId
		{
			get { return this._userId; }
			set { this._userId = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public Ocs0131U01Grd0131ListItemInfo() { }

		public Ocs0131U01Grd0131ListItemInfo(String codeType, String codeTypeName, String adminGubun, String ment, String choiceUser, String userId, String dataRowState)
		{
			this._codeType = codeType;
			this._codeTypeName = codeTypeName;
			this._adminGubun = adminGubun;
			this._ment = ment;
			this._choiceUser = choiceUser;
			this._userId = userId;
			this._dataRowState = dataRowState;
		}

	}
}