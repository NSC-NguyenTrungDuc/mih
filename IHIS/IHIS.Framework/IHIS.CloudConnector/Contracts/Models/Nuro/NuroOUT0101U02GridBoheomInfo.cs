using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    [Serializable]
	public class NuroOUT0101U02GridBoheomInfo
	{
		private String _startDate;
		private String _bunho;
		private String _suname;
		private String _gubun1;
		private String _gubunName1;
		private String _johap;
		private String _johapName;
		private String _tel;
		private String _gaein;
		private String _gaeinNo;
		private String _boninGubun;
		private String _boninGubunName;
		private String _piname;
		private String _lastCheckDate;
		private String _endDate;
		private String _johapGubun;
		private String _oldGubun;
		private String _retrieveYn;
		private String _oldStartDate;
		private String _chuidukDate;
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

		public String Suname
		{
			get { return this._suname; }
			set { this._suname = value; }
		}

		public String Gubun1
		{
			get { return this._gubun1; }
			set { this._gubun1 = value; }
		}

		public String GubunName1
		{
			get { return this._gubunName1; }
			set { this._gubunName1 = value; }
		}

		public String Johap
		{
			get { return this._johap; }
			set { this._johap = value; }
		}

		public String JohapName
		{
			get { return this._johapName; }
			set { this._johapName = value; }
		}

		public String Tel
		{
			get { return this._tel; }
			set { this._tel = value; }
		}

		public String Gaein
		{
			get { return this._gaein; }
			set { this._gaein = value; }
		}

		public String GaeinNo
		{
			get { return this._gaeinNo; }
			set { this._gaeinNo = value; }
		}

		public String BoninGubun
		{
			get { return this._boninGubun; }
			set { this._boninGubun = value; }
		}

		public String BoninGubunName
		{
			get { return this._boninGubunName; }
			set { this._boninGubunName = value; }
		}

		public String Piname
		{
			get { return this._piname; }
			set { this._piname = value; }
		}

		public String LastCheckDate
		{
			get { return this._lastCheckDate; }
			set { this._lastCheckDate = value; }
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

		public String OldGubun
		{
			get { return this._oldGubun; }
			set { this._oldGubun = value; }
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

		public String ChuidukDate
		{
			get { return this._chuidukDate; }
			set { this._chuidukDate = value; }
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

		public NuroOUT0101U02GridBoheomInfo() { }

		public NuroOUT0101U02GridBoheomInfo(String startDate, String bunho, String suname, String gubun1, String gubunName1, String johap, String johapName, String tel, String gaein, String gaeinNo, String boninGubun, String boninGubunName, String piname, String lastCheckDate, String endDate, String johapGubun, String oldGubun, String retrieveYn, String oldStartDate, String chuidukDate, String endYn, String dataRowState)
		{
			this._startDate = startDate;
			this._bunho = bunho;
			this._suname = suname;
			this._gubun1 = gubun1;
			this._gubunName1 = gubunName1;
			this._johap = johap;
			this._johapName = johapName;
			this._tel = tel;
			this._gaein = gaein;
			this._gaeinNo = gaeinNo;
			this._boninGubun = boninGubun;
			this._boninGubunName = boninGubunName;
			this._piname = piname;
			this._lastCheckDate = lastCheckDate;
			this._endDate = endDate;
			this._johapGubun = johapGubun;
			this._oldGubun = oldGubun;
			this._retrieveYn = retrieveYn;
			this._oldStartDate = oldStartDate;
			this._chuidukDate = chuidukDate;
			this._endYn = endYn;
			this._dataRowState = dataRowState;
		}

	}
}