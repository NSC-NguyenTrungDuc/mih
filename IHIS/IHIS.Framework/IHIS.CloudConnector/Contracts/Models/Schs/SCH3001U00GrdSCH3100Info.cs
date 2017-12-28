using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SCH3001U00GrdSCH3100Info
	{
		private String _jundalTable;
		private String _jundalPart;
		private String _gumsaja;
		private String _reserDate;
		private String _reserYn;
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

		public String ReserDate
		{
			get { return this._reserDate; }
			set { this._reserDate = value; }
		}

		public String ReserYn
		{
			get { return this._reserYn; }
			set { this._reserYn = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public SCH3001U00GrdSCH3100Info() { }

		public SCH3001U00GrdSCH3100Info(String jundalTable, String jundalPart, String gumsaja, String reserDate, String reserYn, String dataRowState)
		{
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._gumsaja = gumsaja;
			this._reserDate = reserDate;
			this._reserYn = reserYn;
			this._dataRowState = dataRowState;
		}

	}
}