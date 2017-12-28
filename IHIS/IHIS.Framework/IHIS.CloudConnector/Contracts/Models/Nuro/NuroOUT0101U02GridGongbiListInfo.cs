using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroOUT0101U02GridGongbiListInfo
	{
		private String _startDate;
		private String _bunho;
		private String _budamjaBunho;
		private String _gongbiCode;
		private String _sugubjaBunho;
		private String _endDate;
		private String _remark;
		private String _lastCheckDate;
		private String _gongbiName;
		private String _retrieveYn;
		private String _oldStartDate;
		private String _endYn;
		private String _dataRowState;

		public String StartDate
		{
			get { return this._startDate; }
			set { this._startDate = value; }
		}

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String BudamjaBunho
		{
			get { return this._budamjaBunho; }
			set { this._budamjaBunho = value; }
		}

		public String GongbiCode
		{
			get { return this._gongbiCode; }
			set { this._gongbiCode = value; }
		}

		public String SugubjaBunho
		{
			get { return this._sugubjaBunho; }
			set { this._sugubjaBunho = value; }
		}

		public String EndDate
		{
			get { return this._endDate; }
			set { this._endDate = value; }
		}

		public String Remark
		{
			get { return this._remark; }
			set { this._remark = value; }
		}

		public String LastCheckDate
		{
			get { return this._lastCheckDate; }
			set { this._lastCheckDate = value; }
		}

		public String GongbiName
		{
			get { return this._gongbiName; }
			set { this._gongbiName = value; }
		}

		public String RetrieveYn
		{
			get { return this._retrieveYn; }
			set { this._retrieveYn = value; }
		}

		public String OldStartDate
		{
			get { return this._oldStartDate; }
			set { this._oldStartDate = value; }
		}

		public String EndYn
		{
			get { return this._endYn; }
			set { this._endYn = value; }
		}

		public String DataRowState
		{
			get { return this._dataRowState; }
			set { this._dataRowState = value; }
		}

		public NuroOUT0101U02GridGongbiListInfo() { }

		public NuroOUT0101U02GridGongbiListInfo(String startDate, String bunho, String budamjaBunho, String gongbiCode, String sugubjaBunho, String endDate, String remark, String lastCheckDate, String gongbiName, String retrieveYn, String oldStartDate, String endYn, String dataRowState)
		{
			this._startDate = startDate;
			this._bunho = bunho;
			this._budamjaBunho = budamjaBunho;
			this._gongbiCode = gongbiCode;
			this._sugubjaBunho = sugubjaBunho;
			this._endDate = endDate;
			this._remark = remark;
			this._lastCheckDate = lastCheckDate;
			this._gongbiName = gongbiName;
			this._retrieveYn = retrieveYn;
			this._oldStartDate = oldStartDate;
			this._endYn = endYn;
			this._dataRowState = dataRowState;
		}

	}
}