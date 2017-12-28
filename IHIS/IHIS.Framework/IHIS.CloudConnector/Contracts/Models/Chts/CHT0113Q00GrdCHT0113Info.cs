using System;

namespace IHIS.CloudConnector.Contracts.Models.Chts
{
    [Serializable]
	public class CHT0113Q00GrdCHT0113Info
	{
		private String _disabilityCode;
		private String _disabilityName;
		private String _disabilityKanaName;
		private String _startDate;
		private String _endDate;
		private String _deleteYn;
		private String _pkcht0113;
		private String _n;

		public String DisabilityCode
		{
			get { return this._disabilityCode; }
			set { this._disabilityCode = value; }
		}

		public String DisabilityName
		{
			get { return this._disabilityName; }
			set { this._disabilityName = value; }
		}

		public String DisabilityKanaName
		{
			get { return this._disabilityKanaName; }
			set { this._disabilityKanaName = value; }
		}

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String EndDate
		{
			get { return this._endDate; }
			set { this._endDate = value; }
		}

		public String DeleteYn
		{
			get { return this._deleteYn; }
			set { this._deleteYn = value; }
		}

		public String Pkcht0113
		{
			get { return this._pkcht0113; }
			set { this._pkcht0113 = value; }
		}

		public String N
		{
			get { return this._n; }
			set { this._n = value; }
		}

		public CHT0113Q00GrdCHT0113Info() { }

		public CHT0113Q00GrdCHT0113Info(String disabilityCode, String disabilityName, String disabilityKanaName, String startDate, String endDate, String deleteYn, String pkcht0113, String n)
		{
			this._disabilityCode = disabilityCode;
			this._disabilityName = disabilityName;
			this._disabilityKanaName = disabilityKanaName;
			this._startDate = startDate;
			this._endDate = endDate;
			this._deleteYn = deleteYn;
			this._pkcht0113 = pkcht0113;
			this._n = n;
		}

	}
}