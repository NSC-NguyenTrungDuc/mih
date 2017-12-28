using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
	public class OCS0208Q00GrdOCS0208Info
	{
		private String _gubun;
		private String _bogyongCode;
		private String _banghyang;
		private String _bogyongName;
		private String _donbogYn;
		private String _dv;
		private String _soryKey;
		private String _userYn;
		private String _ioGubun;

		public String Gubun
		{
			get { return this._gubun; }
			set { this._gubun = value; }
		}

		public String BogyongCode
		{
			get { return this._bogyongCode; }
			set { this._bogyongCode = value; }
		}

		public String Banghyang
		{
			get { return this._banghyang; }
			set { this._banghyang = value; }
		}

		public String BogyongName
		{
			get { return this._bogyongName; }
			set { this._bogyongName = value; }
		}

		public String DonbogYn
		{
			get { return this._donbogYn; }
			set { this._donbogYn = value; }
		}

		public String Dv
		{
			get { return this._dv; }
			set { this._dv = value; }
		}

		public String SoryKey
		{
			get { return this._soryKey; }
			set { this._soryKey = value; }
		}

		public String UserYn
		{
			get { return this._userYn; }
			set { this._userYn = value; }
		}

		public String IoGubun
		{
			get { return this._ioGubun; }
			set { this._ioGubun = value; }
		}

		public OCS0208Q00GrdOCS0208Info() { }

		public OCS0208Q00GrdOCS0208Info(String gubun, String bogyongCode, String banghyang, String bogyongName, String donbogYn, String dv, String soryKey, String userYn, String ioGubun)
		{
			this._gubun = gubun;
			this._bogyongCode = bogyongCode;
			this._banghyang = banghyang;
			this._bogyongName = bogyongName;
			this._donbogYn = donbogYn;
			this._dv = dv;
			this._soryKey = soryKey;
			this._userYn = userYn;
			this._ioGubun = ioGubun;
		}

	}
}