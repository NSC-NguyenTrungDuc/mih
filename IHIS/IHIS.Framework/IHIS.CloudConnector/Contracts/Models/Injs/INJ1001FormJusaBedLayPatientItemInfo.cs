using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class INJ1001FormJusaBedLayPatientItemInfo
	{
		private String _codeType;
		private String _code;
		private String _codeName;
		private String _suname;
		private String _sex;

		public String CodeType
		{
			get { return this._codeType; }
			set { this._codeType = value; }
		}

		public String Code
		{
			get { return this._code; }
			set { this._code = value; }
		}

		public String CodeName
		{
			get { return this._codeName; }
			set { this._codeName = value; }
		}

		public String Suname
		{
			get { return this._suname; }
			set { this._suname = value; }
		}

		public String Sex
		{
			get { return this._sex; }
			set { this._sex = value; }
		}

		public INJ1001FormJusaBedLayPatientItemInfo() { }

		public INJ1001FormJusaBedLayPatientItemInfo(String codeType, String code, String codeName, String suname, String sex)
		{
			this._codeType = codeType;
			this._code = code;
			this._codeName = codeName;
			this._suname = suname;
			this._sex = sex;
		}

	}
}