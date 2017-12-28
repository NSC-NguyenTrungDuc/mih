using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0103U12IsUpdateCheckSelectInfo
	{
		private String _suryang;
		private String _dv;
		private String _dvTime;
		private String _nalsu;

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

		public OCS0103U12IsUpdateCheckSelectInfo() { }

		public OCS0103U12IsUpdateCheckSelectInfo(String suryang, String dv, String dvTime, String nalsu)
		{
			this._suryang = suryang;
			this._dv = dv;
			this._dvTime = dvTime;
			this._nalsu = nalsu;
		}

	}
}