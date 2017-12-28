using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0131U00GrdOCS0131Info
	{
		private String _codeType;
		private String _codeTypeName;
		private String _ment;
		private String _choiceUser;
		private String _userId;
		private String _dataRowSate;

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

		public String DataRowSate
		{
			get { return this._dataRowSate; }
			set { this._dataRowSate = value; }
		}

		public OCS0131U00GrdOCS0131Info() { }

		public OCS0131U00GrdOCS0131Info(String codeType, String codeTypeName, String ment, String choiceUser, String userId, String dataRowSate)
		{
			this._codeType = codeType;
			this._codeTypeName = codeTypeName;
			this._ment = ment;
			this._choiceUser = choiceUser;
			this._userId = userId;
			this._dataRowSate = dataRowSate;
		}

	}
}