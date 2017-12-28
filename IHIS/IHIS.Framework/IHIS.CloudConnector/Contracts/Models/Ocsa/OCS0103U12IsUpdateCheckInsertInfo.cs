using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U12IsUpdateCheckInsertInfo
	{
		private String _bunho;
		private String _pkocs1024;
		private String _suryang;
		private String _dv;
		private String _dvTime;
		private String _nalsu;

		public String Bunho
		{
			get { return this._bunho; }
			set { this._bunho = value; }
		}

		public String Pkocs1024
		{
			get { return this._pkocs1024; }
			set { this._pkocs1024 = value; }
		}

		public String Suryang
		{
			get { return this._suryang; }
			set { this._suryang = value; }
		}

		public String Dv
		{
			get { return this._dv; }
			set { this._dv = value; }
		}

		public String DvTime
		{
			get { return this._dvTime; }
			set { this._dvTime = value; }
		}

		public String Nalsu
		{
			get { return this._nalsu; }
			set { this._nalsu = value; }
		}

		public OCS0103U12IsUpdateCheckInsertInfo() { }

		public OCS0103U12IsUpdateCheckInsertInfo(String bunho, String pkocs1024, String suryang, String dv, String dvTime, String nalsu)
		{
			this._bunho = bunho;
			this._pkocs1024 = pkocs1024;
			this._suryang = suryang;
			this._dv = dv;
			this._dvTime = dvTime;
			this._nalsu = nalsu;
		}

	}
}