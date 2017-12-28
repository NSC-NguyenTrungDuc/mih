using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG0120U00Grd0120Item3Info
	{
		private String _bunryu1Name;
		private String _bogyongCode;
		private String _bogyongName;
		private String _dv;
		private String _banghyang;
		private String _buwi;
		private String _chiryo;

		public String Bunryu1Name
		{
			get { return this._bunryu1Name; }
			set { this._bunryu1Name = value; }
		}

		public String BogyongCode
		{
			get { return this._bogyongCode; }
			set { this._bogyongCode = value; }
		}

		public String BogyongName
		{
			get { return this._bogyongName; }
			set { this._bogyongName = value; }
		}

		public String Dv
		{
			get { return this._dv; }
			set { this._dv = value; }
		}

		public String Banghyang
		{
			get { return this._banghyang; }
			set { this._banghyang = value; }
		}

		public String Buwi
		{
			get { return this._buwi; }
			set { this._buwi = value; }
		}

		public String Chiryo
		{
			get { return this._chiryo; }
			set { this._chiryo = value; }
		}

		public DRG0120U00Grd0120Item3Info() { }

		public DRG0120U00Grd0120Item3Info(String bunryu1Name, String bogyongCode, String bogyongName, String dv, String banghyang, String buwi, String chiryo)
		{
			this._bunryu1Name = bunryu1Name;
			this._bogyongCode = bogyongCode;
			this._bogyongName = bogyongName;
			this._dv = dv;
			this._banghyang = banghyang;
			this._buwi = buwi;
			this._chiryo = chiryo;
		}

	}
}