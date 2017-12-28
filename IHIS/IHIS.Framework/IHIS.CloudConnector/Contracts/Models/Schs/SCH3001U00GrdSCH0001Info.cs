using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
	public class SCH3001U00GrdSCH0001Info
	{
		private String _jundalTable;
		private String _jundalPart;
		private String _gumsaja;
		private String _gumsajaName;
		private String _jundalPartName;
		private String _gwaGubun;
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

		public String GumsajaName
		{
			get { return this._gumsajaName; }
			set { this._gumsajaName = value; }
		}

		public String JundalPartName
		{
			get { return this._jundalPartName; }
			set { this._jundalPartName = value; }
		}

		public String GwaGubun
		{
			get { return this._gwaGubun; }
			set { this._gwaGubun = value; }
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

		public SCH3001U00GrdSCH0001Info() { }

		public SCH3001U00GrdSCH0001Info(String jundalTable, String jundalPart, String gumsaja, String gumsajaName, String jundalPartName, String gwaGubun, String gumsaTime, String dataRowState)
		{
			this._jundalTable = jundalTable;
			this._jundalPart = jundalPart;
			this._gumsaja = gumsaja;
			this._gumsajaName = gumsajaName;
			this._jundalPartName = jundalPartName;
			this._gwaGubun = gwaGubun;
			this._gumsaTime = gumsaTime;
			this._dataRowState = dataRowState;
		}

	}
}