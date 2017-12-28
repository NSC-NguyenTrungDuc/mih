using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SchsSCH0201U99ReserListInfo
	{
		private String _naewonDate;
		private String _jinryoPreTime;
		private String _gwaName;
		private String _doctorName;

		public String NaewonDate
		{
			get { return this._naewonDate; }
			set { this._naewonDate = value; }
		}

		public String JinryoPreTime
		{
			get { return this._jinryoPreTime; }
			set { this._jinryoPreTime = value; }
		}

		public String GwaName
		{
			get { return this._gwaName; }
			set { this._gwaName = value; }
		}

		public String DoctorName
		{
			get { return this._doctorName; }
			set { this._doctorName = value; }
		}

		public SchsSCH0201U99ReserListInfo() { }

		public SchsSCH0201U99ReserListInfo(String naewonDate, String jinryoPreTime, String gwaName, String doctorName)
		{
			this._naewonDate = naewonDate;
			this._jinryoPreTime = jinryoPreTime;
			this._gwaName = gwaName;
			this._doctorName = doctorName;
		}

	}
}