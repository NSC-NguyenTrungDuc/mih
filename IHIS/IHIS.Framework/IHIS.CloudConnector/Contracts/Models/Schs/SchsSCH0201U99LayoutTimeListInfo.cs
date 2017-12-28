using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SchsSCH0201U99LayoutTimeListInfo
	{
		private String _reserDate;
		private String _fromTime;
		private String _bunho;
		private String _suname;
		private String _hangmogCode;
		private String _hangmogName;
		private String _gwa;
		private String _doctorName;
		private String _actYn;

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String FromTime
		{
			get { return this._fromTime; }
			set { this._fromTime = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Suname
		{
			get { return this._suname; }
			set { this._suname = value; }
		}

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

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public String ActYn
		{
			get { return this._actYn; }
			set { this._actYn = value; }
		}

		public SchsSCH0201U99LayoutTimeListInfo() { }

		public SchsSCH0201U99LayoutTimeListInfo(String reserDate, String fromTime, String bunho, String suname, String hangmogCode, String hangmogName, String gwa, String doctorName, String actYn)
		{
			this._reserDate = reserDate;
			this._fromTime = fromTime;
			this._bunho = bunho;
			this._suname = suname;
			this._hangmogCode = hangmogCode;
			this._hangmogName = hangmogName;
			this._gwa = gwa;
			this._doctorName = doctorName;
			this._actYn = actYn;
		}

	}
}