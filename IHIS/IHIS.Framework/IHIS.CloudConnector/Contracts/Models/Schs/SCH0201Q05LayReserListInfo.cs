using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SCH0201Q05LayReserListInfo
	{
		private String _pksch0201;
		private String _inOutGubun;
		private String _fkocs;
		private String _bunho;
		private String _gwa;
		private String _gumsaja;
		private String _hangmogCode;
		private String _jundalTable;
		private String _jundalPart;
		private String _reserDate;
		private String _reserTime;
		private String _inputDate;
		private String _inputId;
		private String _suname;
		private String _reserYn;
		private String _cancelYn;
		private String _actingDate;
		private String _hopeDate;
		private String _comments;
		private String _hangmogName;
		private String _jundalPartName;
		private String _gwaName;
		private String _hoDong1;
		private String _sex;
		private String _age;
		private String _birth;
		private String _inputGwa;
		private String _doctorName;
		private String _updName;

		public String Pksch0201
		{
			get { return this._pksch0201; }
			set { this._pksch0201 = value; }
		}

		public String InOutGubun
		{
			get { return this._inOutGubun; }
			set { this._inOutGubun = value; }
		}

		public String Fkocs
		{
			get { return this._fkocs; }
			set { this._fkocs = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String Gumsaja
		{
			get { return this._gumsaja; }
			set { this._gumsaja = value; }
		}

		public String HangmogCode
		{
			get { return this._hangmogCode; }
			set { this._hangmogCode = value; }
		}

		public String JundalTable
		{
			get { return this._jundalTable; }
			set { this._jundalTable = value; }
		}

		public String JundalPart
		{
			get { return this._jundalPart; }
			set { this._jundalPart = value; }
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

		public String InputDate
		{
			get { return this._inputDate; }
			set { this._inputDate = value; }
		}

		public String InputId
		{
			get { return this._inputId; }
			set { this._inputId = value; }
		}

		public String Suname
		{
			get { return this._suname; }
			set { this._suname = value; }
		}

		public String ReserYn
		{
			get { return this._reserYn; }
			set { this._reserYn = value; }
		}

		public String CancelYn
		{
			get { return this._cancelYn; }
			set { this._cancelYn = value; }
		}

		public String ActingDate
		{
			get { return this._actingDate; }
			set { this._actingDate = value; }
		}

		public String HopeDate
		{
			get { return this._hopeDate; }
			set { this._hopeDate = value; }
		}

		public String Comments
		{
			get { return this._comments; }
			set { this._comments = value; }
		}

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public String JundalPartName
		{
			get { return this._jundalPartName; }
			set { this._jundalPartName = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String HoDong1
		{
			get { return this._hoDong1; }
			set { this._hoDong1 = value; }
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

		public String Birth
		{
			get { return this._birth; }
			set { this._birth = value; }
		}

		public String InputGwa
		{
			get { return this._inputGwa; }
			set { this._inputGwa = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String UpdName
		{
			get { return this._updName; }
			set { this._updName = value; }
		}

		public SCH0201Q05LayReserListInfo() { }

		public SCH0201Q05LayReserListInfo(String pksch0201, String inOutGubun, String fkocs, String bunho, String gwa, String gumsaja, String hangmogCode, String jundalTable, String jundalPart, String reserDate, String reserTime, String inputDate, String inputId, String suname, String reserYn, String cancelYn, String actingDate, String hopeDate, String comments, String hangmogName, String jundalPartName, String gwaName, String hoDong1, String sex, String age, String birth, String inputGwa, String doctorName, String updName)
		{
			this._pksch0201 = pksch0201;
			this._inOutGubun = inOutGubun;
			this._fkocs = fkocs;
			this._bunho = bunho;
			this._gwa = gwa;
			this._gumsaja = gumsaja;
			this._hangmogCode = hangmogCode;
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._reserDate = reserDate;
			this._reserTime = reserTime;
			this._inputDate = inputDate;
			this._inputId = inputId;
			this._suname = suname;
			this._reserYn = reserYn;
			this._cancelYn = cancelYn;
			this._actingDate = actingDate;
			this._hopeDate = hopeDate;
			this._comments = comments;
			this._hangmogName = hangmogName;
			this._jundalPartName = jundalPartName;
			this._gwaName = gwaName;
			this._hoDong1 = hoDong1;
			this._sex = sex;
			this._age = age;
			this._birth = birth;
			this._inputGwa = inputGwa;
			this._doctorName = doctorName;
			this._updName = updName;
		}

	}
}