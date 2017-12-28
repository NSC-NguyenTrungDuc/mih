using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuri
{
    [Serializable]
	public class NUR1016U00GrdNUR1016ListItemInfo
	{
		private String _pknur1016;
		private String _bunho;
		private String _allergyGubun;
		private String _allergyInfo;
		private String _startDate;
		private String _endDate;
		private String _endSayu;
		private String _inputText;
		private String _yValue;
		private String _rowState;

		public String Pknur1016
		{
			get { return this._pknur1016; }
			set { this._pknur1016 = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String AllergyGubun
		{
			get { return this._allergyGubun; }
			set { this._allergyGubun = value; }
		}

		public String AllergyInfo
		{
			get { return this._allergyInfo; }
			set { this._allergyInfo = value; }
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

		public String EndSayu
		{
			get { return this._endSayu; }
			set { this._endSayu = value; }
		}

		public String InputText
		{
			get { return this._inputText; }
			set { this._inputText = value; }
		}

		public String YValue
		{
			get { return this._yValue; }
			set { this._yValue = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public NUR1016U00GrdNUR1016ListItemInfo() { }

		public NUR1016U00GrdNUR1016ListItemInfo(String pknur1016, String bunho, String allergyGubun, String allergyInfo, String startDate, String endDate, String endSayu, String inputText, String yValue, String rowState)
		{
			this._pknur1016 = pknur1016;
			this._bunho = bunho;
			this._allergyGubun = allergyGubun;
			this._allergyInfo = allergyInfo;
			this._startDate = startDate;
			this._endDate = endDate;
			this._endSayu = endSayu;
			this._inputText = inputText;
			this._yValue = yValue;
			this._rowState = rowState;
		}

	}
}