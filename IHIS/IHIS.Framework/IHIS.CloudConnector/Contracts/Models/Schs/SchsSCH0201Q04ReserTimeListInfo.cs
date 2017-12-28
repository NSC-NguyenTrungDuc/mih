using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SchsSCH0201Q04ReserTimeListInfo
	{
		private String _hangmogCode;
		private String _hangmogName;
		private String _reserDate;
		private String _reserTime;
		private String _suname;
		private String _inputId;
		private String _inOutGubun;
		private String _inputGwa;
		private String _sex;
		private String _age;
		private String _actingDate;
		private String _comments;
		private String _bunho;
		private String _doctor;
		private String _updName;

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String ReserTime
		{
			get { return this._reserTime; }
			set { this._reserTime = value; }
		}

		public String Suname
		{
			get { return this._suname; }
			set { this._suname = value; }
		}

		public String InputId
		{
			get { return this._inputId; }
			set { this._inputId = value; }
		}

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String InputGwa
		{
			get { return this._inputGwa; }
			set { this._inputGwa = value; }
		}

		public String Sex
		{
			get { return this._sex; }
			set { this._sex = value; }
		}

		public String Age
		{
			get { return this._age; }
			set { this._age = value; }
		}

		public String ActingDate
		{
			get { return this._actingDate; }
			set { this._actingDate = value; }
		}

		public String Comments
		{
			get { return this._comments; }
			set { this._comments = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String UpdName
		{
			get { return this._updName; }
			set { this._updName = value; }
		}

		public SchsSCH0201Q04ReserTimeListInfo() { }

		public SchsSCH0201Q04ReserTimeListInfo(String hangmogCode, String hangmogName, String reserDate, String reserTime, String suname, String inputId, String inOutGubun, String inputGwa, String sex, String age, String actingDate, String comments, String bunho, String doctor, String updName)
		{
			this._hangmogCode = hangmogCode;
			this._hangmogName = hangmogName;
			this._reserDate = reserDate;
			this._reserTime = reserTime;
			this._suname = suname;
			this._inputId = inputId;
			this._inOutGubun = inOutGubun;
			this._inputGwa = inputGwa;
			this._sex = sex;
			this._age = age;
			this._actingDate = actingDate;
			this._comments = comments;
			this._bunho = bunho;
			this._doctor = doctor;
			this._updName = updName;
		}

	}
}