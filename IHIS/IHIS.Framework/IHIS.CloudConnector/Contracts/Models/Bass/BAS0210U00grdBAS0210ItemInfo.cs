using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
	public class BAS0210U00grdBAS0210ItemInfo
	{
		private String _gubun;
		private String _gubunName;
		private String _retrieveYn;
		private String _startDate;
		private String _endDate;
		private String _johapGubun;
		private String _johapName;
		private String _gonbiYn;
		private String _validationCheck;
		private String _dataRowState;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String GubunName
		{
			get { return this._gubunName; }
			set { this._gubunName = value; }
		}

		public String RetrieveYn
		{
			get { return this._retrieveYn; }
			set { this._retrieveYn = value; }
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

		public String JohapGubun
		{
			get { return this._johapGubun; }
			set { this._johapGubun = value; }
		}

		public String JohapName
		{
			get { return this._johapName; }
			set { this._johapName = value; }
		}

		public String GonbiYn
		{
			get { return this._gonbiYn; }
			set { this._gonbiYn = value; }
		}

		public String ValidationCheck
		{
			get { return this._validationCheck; }
			set { this._validationCheck = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public BAS0210U00grdBAS0210ItemInfo() { }

		public BAS0210U00grdBAS0210ItemInfo(String gubun, String gubunName, String retrieveYn, String startDate, String endDate, String johapGubun, String johapName, String gonbiYn, String validationCheck, String dataRowState)
		{
			this._gubun = gubun;
			this._gubunName = gubunName;
			this._retrieveYn = retrieveYn;
			this._startDate = startDate;
			this._endDate = endDate;
			this._johapGubun = johapGubun;
			this._johapName = johapName;
			this._gonbiYn = gonbiYn;
			this._validationCheck = validationCheck;
			this._dataRowState = dataRowState;
		}

	}
}