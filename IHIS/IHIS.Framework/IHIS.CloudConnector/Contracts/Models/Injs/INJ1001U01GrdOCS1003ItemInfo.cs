using System;

namespace IHIS.CloudConnector.Contracts.Models.Injs
{
    [Serializable]
	public class INJ1001U01GrdOCS1003ItemInfo
	{
		private String _reserDate;
		private String _orderDate;
		private String _actingDate;
		private String _gwa;
		private String _gwaName;
		private String _doctor;
		private String _doctorName;

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String OrderDate
		{
			get { return this._orderDate; }
			set { this._orderDate = value; }
		}

		public String ActingDate
		{
			get { return this._actingDate; }
			set { this._actingDate = value; }
		}

		public String Gwa
		{
			get { return this._gwa; }
			set { this._gwa = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String Doctor
		{
			get { return this._doctor; }
			set { this._doctor = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public INJ1001U01GrdOCS1003ItemInfo() { }

		public INJ1001U01GrdOCS1003ItemInfo(String reserDate, String orderDate, String actingDate, String gwa, String gwaName, String doctor, String doctorName)
		{
			this._reserDate = reserDate;
			this._orderDate = orderDate;
			this._actingDate = actingDate;
			this._gwa = gwa;
			this._gwaName = gwaName;
			this._doctor = doctor;
			this._doctorName = doctorName;
		}

	}
}