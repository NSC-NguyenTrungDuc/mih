using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SCH3001U00GrdSCH0002Info
	{
		private String _jundalTable;
		private String _jundalPart;
		private String _gumsaja;
		private String _hangmogCode;
		private String _hangmogName;
		private String _gumsaTime;
		private String _dataRowState;

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

		public String HangmogName
		{
			get { return this._hangmogName; }
			set { this._hangmogName = value; }
		}

		public String GumsaTime
		{
			get { return this._gumsaTime; }
			set { this._gumsaTime = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public SCH3001U00GrdSCH0002Info() { }

		public SCH3001U00GrdSCH0002Info(String jundalTable, String jundalPart, String gumsaja, String hangmogCode, String hangmogName, String gumsaTime, String dataRowState)
		{
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._gumsaja = gumsaja;
			this._hangmogCode = hangmogCode;
			this._hangmogName = hangmogName;
			this._gumsaTime = gumsaTime;
			this._dataRowState = dataRowState;
		}

	}
}