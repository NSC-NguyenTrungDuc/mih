using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
	public class DRG0120U00Grd0120Item2Info
	{
		private String _bunryu1Name;
		private String _bogyongCode;
		private String _bogyongName;
		private String _dv;
		private String _bogyongGubun;
		private String _donbogYn;
		private String _afWake;
		private String _morning;
		private String _afternoon;
		private String _evening;
		private String _night;

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

		public String BogyongGubun
		{
			get { return this._bogyongGubun; }
			set { this._bogyongGubun = value; }
		}

		public String DonbogYn
		{
			get { return this._donbogYn; }
			set { this._donbogYn = value; }
		}

		public String AfWake
		{
			get { return this._afWake; }
			set { this._afWake = value; }
		}

		public String Morning
		{
			get { return this._morning; }
			set { this._morning = value; }
		}

		public String Afternoon
		{
			get { return this._afternoon; }
			set { this._afternoon = value; }
		}

		public String Evening
		{
			get { return this._evening; }
			set { this._evening = value; }
		}

		public String Night
		{
			get { return this._night; }
			set { this._night = value; }
		}

		public DRG0120U00Grd0120Item2Info() { }

		public DRG0120U00Grd0120Item2Info(String bunryu1Name, String bogyongCode, String bogyongName, String dv, String bogyongGubun, String donbogYn, String afWake, String morning, String afternoon, String evening, String night)
		{
			this._bunryu1Name = bunryu1Name;
			this._bogyongCode = bogyongCode;
			this._bogyongName = bogyongName;
			this._dv = dv;
			this._bogyongGubun = bogyongGubun;
			this._donbogYn = donbogYn;
			this._afWake = afWake;
			this._morning = morning;
			this._afternoon = afternoon;
			this._evening = evening;
			this._night = night;
		}

	}
}