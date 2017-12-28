using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuri
{
    [Serializable]
	public class NUR1017U00GrdNUR1017ListItemInfo
	{
		private String _infeCode;
		private String _bunho;
		private String _startDate;
		private String _endDate;
		private String _infeJaeryo;
		private String _endSayu;
		private String _inputText;
		private String _yValue;
		private String _pknur1017;
		private String _rowState;

		public String InfeCode
		{
			get { return this._infeCode; }
			set { this._infeCode = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
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

		public String InfeJaeryo
		{
			get { return this._infeJaeryo; }
			set { this._infeJaeryo = value; }
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

		public String Pknur1017
		{
			get { return this._pknur1017; }
			set { this._pknur1017 = value; }
		}

		public String RowState
		{
			get { return this._rowState; }
			set { this._rowState = value; }
		}

		public NUR1017U00GrdNUR1017ListItemInfo() { }

		public NUR1017U00GrdNUR1017ListItemInfo(String infeCode, String bunho, String startDate, String endDate, String infeJaeryo, String endSayu, String inputText, String yValue, String pknur1017, String rowState)
		{
			this._infeCode = infeCode;
			this._bunho = bunho;
			this._startDate = startDate;
			this._endDate = endDate;
			this._infeJaeryo = infeJaeryo;
			this._endSayu = endSayu;
			this._inputText = inputText;
			this._yValue = yValue;
			this._pknur1017 = pknur1017;
			this._rowState = rowState;
		}

	}
}